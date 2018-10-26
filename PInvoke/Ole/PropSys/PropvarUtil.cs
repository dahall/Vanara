using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

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

			/// <summary>
			/// When comparing strings, use CompareStringEx with LOCALE_NAME_USER_DEFAULT and SORT_DIGITSASNUMBERS. This corresponds to the
			/// linguistically correct order for UI lists.
			/// </summary>
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
		/// <para>Frees the memory and references used by an array of PROPVARIANT structures stored in an array.</para>
		/// </summary>
		/// <param name="rgPropVar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>Array of PROPVARIANT structures to free.</para>
		/// </param>
		/// <param name="cVars">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the array specified by rgPropVar.</para>
		/// </param>
		/// <returns>
		/// <para>No return value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function releases the memory and references held by each structure in the array before setting the structures to zero.
		/// </para>
		/// <para>This function performs the same action as FreePropVariantArray, but <c>FreePropVariantArray</c> returns an <c>HRESULT</c>.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use ClearPropVariantArray</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-clearpropvariantarray PSSTDAPI_(void)
		// ClearPropVariantArray( PROPVARIANT *rgPropVar, UINT cVars );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "e8d7f951-8a9e-441b-9fa7-bf21cf08c8ac")]
		public static extern HRESULT ClearPropVariantArray([In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PROPVARIANT[] rgPropVar, uint cVars);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure from a specified Boolean vector.</summary>
		/// <param name="prgf">
		/// Pointer to the Boolean vector used to initialize the structure. If this parameter is NULL, the elements pointed to by the
		/// cabool.pElems structure member are initialized with VARIANT_FALSE.
		/// </param>
		/// <param name="cElems">The number of vector elements.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762288")]
		public static extern HRESULT InitPropVariantFromBooleanVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.Bool)] bool[] prgf, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure using the contents of a buffer.</summary>
		/// <param name="pv">Pointer to the buffer.</param>
		/// <param name="cb">The length of the buffer, in bytes.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762289")]
		public static extern HRESULT InitPropVariantFromBuffer([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U1)] byte[] pv, uint cb, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a class identifier (CLSID).</summary>
		/// <param name="clsid">Reference to the CLSID.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762290")]
		public static extern HRESULT InitPropVariantFromCLSID(in Guid clsid, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of double values.</summary>
		/// <param name="prgn">
		/// Pointer to a double vector. If this value is NULL, the elements pointed to by the cadbl.pElems structure member are initialized
		/// with 0.0.
		/// </param>
		/// <param name="cElems">The number of vector elements.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762292")]
		public static extern HRESULT InitPropVariantFromDoubleVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.R8)] double[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on information stored in a <see cref="FILETIME"/> structure.</summary>
		/// <param name="pftIn">Pointer to the date and time as a <see cref="FILETIME"/> structure.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762293")]
		public static extern HRESULT InitPropVariantFromFileTime(in FILETIME pftIn, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure from a specified vector of <see cref="FILETIME"/> values.</summary>
		/// <param name="prgft">
		/// Pointer to the date and time as a <see cref="FILETIME"/> vector. If this value is NULL, the elements pointed to by the
		/// cafiletime.pElems structure member is initialized with (FILETIME)0.
		/// </param>
		/// <param name="cElems">The number of vector elements.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762294")]
		public static extern HRESULT InitPropVariantFromFileTimeVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] FILETIME[] prgft, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// <para>Initializes a PROPVARIANT structure based on a <c>GUID</c>. The structure is initialized as VT_LPWSTR.</para>
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Reference to the source <c>GUID</c>.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>When this function returns, contains the initialized PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_LPWSTR PROPVARIANT, which formats the GUID in a form similar to .</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use <c>InitPropVariantFromGUIDAsString</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-initpropvariantfromguidasstring PSSTDAPI
		// InitPropVariantFromGUIDAsString( REFGUID guid, PROPVARIANT *ppropvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "bcc343f7-741f-4cdd-bd2f-ae4786faab0e")]
		public static extern HRESULT InitPropVariantFromGUIDAsString(in Guid guid, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of 16-bit integer values.</summary>
		/// <param name="prgn">Pointer to a source vector of SHORT values. If this parameter is NULL, the vector is initialized with zeros.</param>
		/// <param name="cElems">The number of elements in the vector.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762298")]
		public static extern HRESULT InitPropVariantFromInt16Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I2)] short[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of 32-bit integer values.</summary>
		/// <param name="prgn">Pointer to a source vector of LONG values. If this parameter is NULL, the vector is initialized with zeros.</param>
		/// <param name="cElems">The number of elements in the vector.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762300")]
		public static extern HRESULT InitPropVariantFromInt32Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I4)] int[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified vector of 64-bit integer values.</summary>
		/// <param name="prgn">
		/// Pointer to a source vector of LONGLONG values. If this parameter is NULL, the vector is initialized with zeros.
		/// </param>
		/// <param name="cElems">The number of elements in the vector.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762302")]
		public static extern HRESULT InitPropVariantFromInt64Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.I8)] long[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified <see cref="PROPVARIANT"/> vector element.</summary>
		/// <remarks>
		/// This function extracts a single value from the source <see cref="PROPVARIANT"/> structure and uses that value to initialize the
		/// output <c>PROPVARIANT</c> structure. The calling application must use <see cref="PropVariantClear"/> to free the
		/// <c>PROPVARIANT</c> referred to by ppropvar when it is no longer needed.
		/// <para>
		/// If the source <c>PROPVARIANT</c> is a vector or array, iElem must be less than the number of elements in the vector or array.
		/// </para>
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

		/// <summary>
		/// <para>Initializes a PROPVARIANT structure based on a string resource embedded in an executable file.</para>
		/// </summary>
		/// <param name="hinst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>Handle to an instance of the module whose executable file contains the string resource.</para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Integer identifier of the string to be loaded.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>When this function returns, contains the initialized PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function creates a VT_LPWSTR propvariant. If the specified resource does not exist, it initializes the PROPVARIANT with an
		/// empty string. Resource strings longer than 1024 characters are truncated and null-terminated.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitPropVariantFromResource.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-initpropvariantfromresource PSSTDAPI
		// InitPropVariantFromResource( HINSTANCE hinst, UINT id, PROPVARIANT *ppropvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "c958f823-f820-4b0b-86ed-84ad18befbd1")]
		public static extern HRESULT InitPropVariantFromResource(HINSTANCE hinst, uint id, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// <para>
		/// Initializes a PROPVARIANT structure from a specified string. The string is parsed as a semi-colon delimited list (for example: "A;B;C").
		/// </para>
		/// </summary>
		/// <param name="psz">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>Pointer to a buffer that contains the source Unicode string.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>When this function returns, contains the initialized PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Creates a VT_VECTOR | VT_LPWSTR propvariant. It parses the source string as a semicolon list of values. The string "a; b; c"
		/// creates a vector with three values. Leading and trailing whitespace are removed, and empty values are omitted.
		/// </para>
		/// <para>If psz is <c>NULL</c> or contains no values, the PROPVARIANT structure is initialized as VT_EMPTY.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitPropVariantFromStringAsVector.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-initpropvariantfromstringasvector PSSTDAPI
		// InitPropVariantFromStringAsVector( PCWSTR psz, PROPVARIANT *ppropvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "fc48f2e0-ce4a-4f48-a624-202def4bcff0")]
		public static extern HRESULT InitPropVariantFromStringAsVector([MarshalAs(UnmanagedType.LPWStr)] string psz, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified string vector.</summary>
		/// <param name="prgsz">Pointer to a buffer that contains the source string vector.</param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgsz"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762307")]
		public static extern HRESULT InitPropVariantFromStringVector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.LPWStr)] string[] prgsz, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>
		/// <para>Initializes a PROPVARIANT structure based on a string stored in a STRRET structure.</para>
		/// </summary>
		/// <param name="pstrret">
		/// <para>Type: <c>STRRET*</c></para>
		/// <para>Pointer to a STRRET structure that contains the string.</para>
		/// </param>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>PIDL of the item whose details are being retrieved.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c>PROPVARIANT*</c></para>
		/// <para>When this function returns, contains the initialized PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_LPWSTR propvariant.</para>
		/// <para><c>Note</c> This function frees the memory used for the STRRET contents.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitPropVariantFromStrRet.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-initpropvariantfromstrret PSSTDAPI
		// InitPropVariantFromStrRet( STRRET *pstrret, PCUITEMID_CHILD pidl, PROPVARIANT *ppropvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "5c02e2ee-14c2-4966-83e7-16dfbf81b879")]
		public static extern HRESULT InitPropVariantFromStrRet(IntPtr pstrret, IntPtr pidl, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a specified string vector.</summary>
		/// <param name="prgn">The PRGN.</param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgn"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762310")]
		public static extern HRESULT InitPropVariantFromUInt16Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U2)] ushort[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a vector of 32-bit unsigned integer values.</summary>
		/// <param name="prgn">
		/// Pointer to a source vector of ULONG values. If this parameter is NULL, the <see cref="PROPVARIANT"/> is initialized with zeros.
		/// </param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgn"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762312")]
		public static extern HRESULT InitPropVariantFromUInt32Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U4)] uint[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a <see cref="PROPVARIANT"/> structure based on a vector of 64-bit unsigned integer values.</summary>
		/// <param name="prgn">
		/// Pointer to a source vector of ULONGLONG values. If this parameter is NULL, the <see cref="PROPVARIANT"/> is initialized with zeros.
		/// </param>
		/// <param name="cElems">The number of vector elements in <paramref name="prgn"/>.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762314")]
		public static extern HRESULT InitPropVariantFromUInt64Vector([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.U8)] ulong[] prgn, uint cElems, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Initializes a vector element in a <see cref="PROPVARIANT"/> structure with a value stored in another PROPVARIANT.</summary>
		/// <param name="propvarSingle">Reference to the source <see cref="PROPVARIANT"/> structure that contains a single value.</param>
		/// <param name="ppropvarVector">When this function returns, contains the initialized <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>
		/// Returns S_OK if successful, or a standard COM error value otherwise. If the requested coercion is not possible, an error is returned.
		/// </returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb762315")]
		public static extern HRESULT InitPropVariantVectorFromPropVariant([In] PROPVARIANT propvarSingle, [Out] PROPVARIANT ppropvarVector);

		/// <summary>Coerces a value stored as a <see cref="PROPVARIANT"/> structure to an equivalent value of a different variant type.</summary>
		/// <param name="ppropvarDest">
		/// A pointer to a <see cref="PROPVARIANT"/> structure that, when this function returns successfully, receives the coerced value and
		/// its new type.
		/// </param>
		/// <param name="propvarSrc">
		/// A reference to the source <see cref="PROPVARIANT"/> structure that contains the value expressed as its original type.
		/// </param>
		/// <param name="flags">Reserved, must be 0.</param>
		/// <param name="vt">Specifies the new type for the value. See the tables below for recognized type names.</param>
		/// <returns>
		/// Returns S_OK if successful, or a standard COM error value otherwise. If the requested coercion is not possible, an error is returned.
		/// </returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776514")]
		public static extern HRESULT PropVariantChangeType([Out] PROPVARIANT ppropvarDest, [In] PROPVARIANT propvarSrc, PROPVAR_CHANGE_FLAGS flags, VARTYPE vt);

		/// <summary>Compares two <see cref="PROPVARIANT"/> structures, based on default comparison units and settings.</summary>
		/// <param name="propvar1">Reference to the first <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="propvar2">Reference to the second <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>Returns 1 if propvar1 is greater than propvar2</description>
		/// </item>
		/// <item>
		/// <description>Returns 0 if propvar1 equals propvar2</description>
		/// </item>
		/// <item>
		/// <description>Returns -1 if propvar1 is less than propvar2</description>
		/// </item>
		/// </list>
		/// </returns>
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776516")]
		public static int PropVariantCompare(PROPVARIANT propvar1, PROPVARIANT propvar2)
		{
			return PropVariantCompareEx(propvar1, propvar2, PROPVAR_COMPARE_UNIT.PVCU_DEFAULT, PROPVAR_COMPARE_FLAGS.PVCF_DEFAULT);
		}

		/// <summary>Compares two <see cref="PROPVARIANT"/> structures, based on specified comparison units and flags.</summary>
		/// <param name="propvar1">Reference to the first <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="propvar2">Reference to the second <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="unit">Specifies, where appropriate, one of the comparison units defined in PROPVAR_COMPARE_UNIT.</param>
		/// <param name="flags">Specifies one of the following:</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>Returns 1 if propvar1 is greater than propvar2</description>
		/// </item>
		/// <item>
		/// <description>Returns 0 if propvar1 equals propvar2</description>
		/// </item>
		/// <item>
		/// <description>Returns -1 if propvar1 is less than propvar2</description>
		/// </item>
		/// </list>
		/// </returns>
		[DllImport(Lib.PropSys, ExactSpelling = true, PreserveSig = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776517")]
		public static extern int PropVariantCompareEx(PROPVARIANT propvar1, PROPVARIANT propvar2, PROPVAR_COMPARE_UNIT unit, PROPVAR_COMPARE_FLAGS flags);

		/// <summary>
		/// <para>Extracts a single Boolean element from a PROPVARIANT structure of type , , or .</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>A reference to the source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies the vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pfVal">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this function returns, contains the extracted Boolean value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the source PROPVARIANT structure has type , iElem must be 0. Otherwise iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>The following example uses this function to loop through the values in a PROPVARIANT structure.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetbooleanelem PSSTDAPI
		// PropVariantGetBooleanElem( REFPROPVARIANT propvar, ULONG iElem, BOOL *pfVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "830dca70-1777-418d-b3ac-78028411700e")]
		public static extern HRESULT PropVariantGetBooleanElem([In] PROPVARIANT propvar, uint iElem, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

		/// <summary>
		/// <para>Extracts a single <c>double</c> element from a PROPVARIANT structure of type , , or .</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to the source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>DOUBLE*</c></para>
		/// <para>When this function returns, contains the extracted double value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the source PROPVARIANT has type , iElem must be 0. Otherwise iElem must be less than the number of elements in the vector or
		/// array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>The following example uses this function to loop through the values in a PROPVARIANT structure.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetdoubleelem PSSTDAPI
		// PropVariantGetDoubleElem( REFPROPVARIANT propvar, ULONG iElem, DOUBLE *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "387e23df-bfbd-42c0-adef-dc53ba95a9f2")]
		public static extern HRESULT PropVariantGetDoubleElem([In] PROPVARIANT propvar, uint iElem, out double pnVal);

		/// <summary>Retrieves the element count of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <returns>
		/// Returns the element count of a VT_VECTOR or VT_ARRAY value: for single values, returns 1; for empty structures, returns 0.
		/// </returns>
		[DllImport(Lib.PropSys, ExactSpelling = true, PreserveSig = true)]
		[return: MarshalAs(UnmanagedType.I4)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776522")]
		public static extern int PropVariantGetElementCount([In] PROPVARIANT propVar);

		/// <summary>
		/// <para>
		/// Extracts a single FILETIME element from a PROPVARIANT structure of type VT_FILETIME, VT_VECTOR | VT_FILETIME, or VT_ARRAY | VT_FILETIME.
		/// </para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>The source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, this value must be 0.</para>
		/// </param>
		/// <param name="pftVal">
		/// <para>Type: <c>FILETIME*</c></para>
		/// <para>When this function returns, contains the extracted filetime value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the source PROPVARIANT has type VT_FILETIME, iElem must be 0; otherwise, iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example, to be included as part of a larger program, demonstrates how to use PropVariantGetFileTimeElem in an
		/// iteration statement to access the values in PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetfiletimeelem PSSTDAPI
		// PropVariantGetFileTimeElem( REFPROPVARIANT propvar, ULONG iElem, FILETIME *pftVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "e38b16ed-84cb-4444-bfbd-1165595bc9b5")]
		public static extern HRESULT PropVariantGetFileTimeElem([In] PROPVARIANT propvar, uint iElem, out FILETIME pftVal);

		/// <summary>
		/// <para>Extracts a single Int16 element from a PROPVARIANT structure of type VT_I2, VT_VECTOR | VT_I2, or VT_ARRAY | VT_I2.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to the source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The vector or array index; otherwise, this value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>SHORT*</c></para>
		/// <para>When this function returns, contains the extracted Int32 element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for PROPVARIANT structures of the following types.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_I2</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_I2</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_I2</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_I2, iElem must be 0. Otherwise, iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantGetInt16Elem with an
		/// iteration statement to access the values in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetint16elem PSSTDAPI
		// PropVariantGetInt16Elem( REFPROPVARIANT propvar, ULONG iElem, SHORT *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "1dbb6887-81c9-411d-9fce-c9e2f3479a43")]
		public static extern HRESULT PropVariantGetInt16Elem([In] PROPVARIANT propvar, uint iElem, out short pnVal);

		/// <summary>
		/// <para>Extracts a single Int32 element from a PROPVARIANT of type VT_I4, VT_VECTOR | VT_I4, or VT_ARRAY | VT_I4.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to the source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>When this function, contains the extracted Int32 value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for PROPVARIANT structures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_I4</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTTOR | VT_I4</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_I4</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_I4, iElem must be 0. Otherwise, iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example uses this PropVariantGetInt32Elem with an interation statement to access the values in a PROPVARIANT structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetint32elem PSSTDAPI
		// PropVariantGetInt32Elem( REFPROPVARIANT propvar, ULONG iElem, LONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "de7dc6d4-d85a-44cb-8af7-840fd6e68d5c")]
		public static extern HRESULT PropVariantGetInt32Elem([In] PROPVARIANT propvar, uint iElem, out int pnVal);

		/// <summary>
		/// <para>Extracts a single Int64 element from a PROPVARIANT structure of type VT_I8, VT_VECTOR | VT_I8, or VT_ARRAY | VT_I8.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to the source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>LONGLONG*</c></para>
		/// <para>When this function returns, contains the extracted Int64 value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works forPROPVARIANTstructures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_I8</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_I8</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_I8</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_I8, iElem must be 0. Otherwise, iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantGetInt64Elem with an
		/// iteration statement to access the values in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetint64elem PSSTDAPI
		// PropVariantGetInt64Elem( REFPROPVARIANT propvar, ULONG iElem, LONGLONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6dd7212a-587f-4f9e-a2e5-dbd2a9c15a5b")]
		public static extern HRESULT PropVariantGetInt64Elem([In] PROPVARIANT propvar, uint iElem, out long pnVal);

		/// <summary>
		/// <para>
		/// Extracts a single Unicode string element from a PROPVARIANT structure of type VT_LPWSTR, VT_BSTR, VT_VECTOR | VT_LPWSTR,
		/// VT_VECTOR | VT_BSTR, or VT_ARRAY | VT_BSTR.
		/// </para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="ppszVal">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// When this function returns, contains the extracted string value. The calling application is responsible for freeing this string
		/// by calling CoTaskMemFree when it is no longer needed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for PROPVARIANT structures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_LPWSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_BSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_LPWSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_BSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_BSTR</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_LPWSTR or VT_BSTR, iElem must be 0. Otherwise iElem must be less than the number of
		/// elements in the vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>If a BSTR element has a <c>NULL</c> pointer, this function allocates an empty string.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example, to be included as part of a larger program, demonstrates how to use PropVariantGetStringElem with an
		/// iteration statement to access the values in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetstringelem PSSTDAPI
		// PropVariantGetStringElem( REFPROPVARIANT propvar, ULONG iElem, PWSTR *ppszVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6e803d93-5b55-4b73-8e23-a584f5f91969")]
		public static extern HRESULT PropVariantGetStringElem([In] PROPVARIANT propvar, uint iElem, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszVal);

		/// <summary>
		/// <para>
		/// Extracts a single unsigned Int16 element from a PROPVARIANT structure of type VT_U12, VT_VECTOR | VT_U12, or VT_ARRAY | VT_U12.
		/// </para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to the source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>USHORT*</c></para>
		/// <para>When this function returns, contains the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for PROPVARIANT structures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_UI2</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_UI2</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_UI2</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_UI2, iElem must be 0. Otherwise iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantGetUInt16Elem with an
		/// iteration statement to access the values in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetuint16elem PSSTDAPI
		// PropVariantGetUInt16Elem( REFPROPVARIANT propvar, ULONG iElem, USHORT *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "da50e35b-f17f-4de6-b2e7-5a885e2149e5")]
		public static extern HRESULT PropVariantGetUInt16Elem([In] PROPVARIANT propvar, uint iElem, out ushort pnVal);

		/// <summary>
		/// <para>
		/// Extracts a single unsigned Int32 element from a PROPVARIANT structure of type VT_UI4, VT_VECTOR | VT_UI4, or VT_ARRAY | VT_UI4.
		/// </para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>The source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>A vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the extracted unsigned Int32 value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for PROPVARIANT structures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_UI4</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_UI4</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_UI4</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_UI4, iElem must be 0. Otherwise, iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantGetUInt32Elem with an
		/// iteration statement to access the values in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetuint32elem PSSTDAPI
		// PropVariantGetUInt32Elem( REFPROPVARIANT propvar, ULONG iElem, ULONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "b31975b6-d717-4e8d-bf5a-2ade96034031")]
		public static extern HRESULT PropVariantGetUInt32Elem([In] PROPVARIANT propvar, uint iElem, out uint pnVal);

		/// <summary>
		/// <para>
		/// Extracts a single unsigned Int64 element from a PROPVARIANT structure of type VT_UI8, VT_VECTOR | VT_UI8, or VT_ARRAY | VT_UI8.
		/// </para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>The source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The vector or array index; otherwise, iElem must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>ULONGLONG*</c></para>
		/// <para>When this function returns, contains the extracted Int64 value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for PROPVARIANT structures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_UI8</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_UI8</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_UI8</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has type VT_UI8, iElem must be 0. Otherwise iElem must be less than the number of elements in the
		/// vector or array. You can use PropVariantGetElementCount to obtain the number of elements in the vector or array.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantGetUInt64Elem with an
		/// iteration statement to access the values in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvariantgetuint64elem PSSTDAPI
		// PropVariantGetUInt64Elem( REFPROPVARIANT propvar, ULONG iElem, ULONGLONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "35955104-b567-4c4f-850a-0a4778673ce8")]
		public static extern HRESULT PropVariantGetUInt64Elem([In] PROPVARIANT propvar, uint iElem, out ulong pnVal);

		/// <summary>
		/// Extracts a Boolean property value of a <see cref="PROPVARIANT"/> structure. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pfRet">When this function returns, contains the extracted property value if one exists; otherwise, contains FALSE.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776531")]
		public static extern HRESULT PropVariantToBoolean([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.Bool)] out bool pfRet);

		/// <summary>
		/// <para>Extracts a Boolean vector from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgf">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Points to a buffer that contains crgf <c>BOOL</c> values. When this function returns, the buffer has been initialized with pcElem
		/// Boolean elements extracted from the source PROPVARIANT structure.
		/// </para>
		/// </param>
		/// <param name="crgf">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Number of elements in the buffer pointed to by prgf.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of Boolean elements extracted from source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgf values. The buffer pointed to by prgf.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a PROPVARIANT to hold a Boolean vector value with a fixed
		/// number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type VT_VECTOR | VT_BOOL or VT_ARRAY | VT_BOOL, this helper function extracts up to crgf Boolean
		/// values an places them into the buffer pointed to by prgf. If the <c>PROPVARIANT</c> contains more elements than will fit into the
		/// prgf buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToBooleanVector to access a
		/// Boolean vector stored in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttobooleanvector PSSTDAPI
		// PropVariantToBooleanVector( REFPROPVARIANT propvar, BOOL *prgf, ULONG crgf, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "93ccd129-4fa4-40f3-96f3-b87b50414b0a")]
		public static extern HRESULT PropVariantToBooleanVector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.Bool)] bool[] prgf, uint crgf, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated Boolean vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of Boolean values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of Boolean elements extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful, or an error value otherwise. E_INVALIDARG indicates that the <see cref="PROPVARIANT"/> was not of the
		/// appropriate type.
		/// </returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776533")]
		public static extern HRESULT PropVariantToBooleanVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>
		/// Extracts the Boolean property value of a PROPVARIANT structure. If no value exists, then the specified default value is returned.
		/// </para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="fDefault">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Specifies the default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>The extracted Boolean value or the default value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a Boolean value and would like
		/// to use a default value if it does not. For instance, an application that obtains values from a property store can use this to
		/// safely extract the Boolean value for Boolean properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_BOOL</c>, this helper function extracts the Boolean value. Otherwise, it attempts to
		/// convert the value in the <c>PROPVARIANT</c> structure into a Boolean. If the source <c>PROPVARIANT</c> has type <c>VT_EMPTY</c>
		/// or a conversion is not possible, then PropVariantToBooleanWithDefault returns the default provided by fDefault. See
		/// PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToBooleanWithDefault to
		/// access a Boolean value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttobooleanwithdefault PSSTDAPI_(BOOL)
		// PropVariantToBooleanWithDefault( REFPROPVARIANT propvarIn, BOOL fDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "223767a7-a4de-4e7e-ad8b-2a6bdcea0a47")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PropVariantToBooleanWithDefault([In] PROPVARIANT propvarIn, [MarshalAs(UnmanagedType.Bool)] bool fDefault);

		/// <summary>Extracts the BSTR property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pbstrOut">Pointer to the extracted property value if one exists; otherwise, contains an empty string.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776535")]
		public static extern HRESULT PropVariantToBSTR([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.BStr)] out string pbstrOut);

		/// <summary>Extracts the buffer value from a <see cref="PROPVARIANT"/> structure of type VT_VECTOR | VT_UI1 or VT_ARRRAY | VT_UI1.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pv">
		/// Pointer to a buffer of length cb bytes. When this function returns, contains the first cb bytes of the extracted buffer value.
		/// </param>
		/// <param name="cb">The buffer length, in bytes.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776536")]
		public static extern HRESULT PropVariantToBuffer([In] PROPVARIANT propVar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pv, uint cb);

		/// <summary>Extracts double value from a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pdblRet">
		/// When this function returns, contains the extracted property value if one exists; otherwise, contains 0.0.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776538")]
		public static extern HRESULT PropVariantToDouble([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.R8)] out double pdblRet);

		/// <summary>
		/// <para>Extracts a vector of doubles from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>DOUBLE*</c></para>
		/// <para>
		/// Points to a buffer containing crgn DOUBLE values. When this function returns, the buffer has been initialized with pcElem double
		/// elements extracted from the source PROPVARIANT structure.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size in elements of the buffer pointed to by prgn.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of double elements extracted from the source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a double vector value with a
		/// fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type VT_VECTOR | VT_R8 or VT_ARRAY | VT_R8, this helper function extracts up to crgn double values
		/// and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c> contains more elements than will fit into the prgn
		/// buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttodoublevector PSSTDAPI
		// PropVariantToDoubleVector( REFPROPVARIANT propvar, DOUBLE *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "2d90bf96-8a3f-4949-8480-bb75f0deeb2e")]
		public static extern HRESULT PropVariantToDoubleVector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly-allocated double vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of double values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of double elements extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776540")]
		public static extern HRESULT PropVariantToDoubleVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>Extracts a double property value of a PROPVARIANT structure. If no value exists, then the specified default value is returned.</para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="dblDefault">
		/// <para>Type: <c>DOUBLE</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DOUBLE</c></para>
		/// <para>Returns extracted <c>double</c> value, or default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a double value and would like
		/// to use a default value if it does not. For instance, an application obtaining values from a property store can use this to safely
		/// extract the double value for double properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_R8</c>, this helper function extracts the double value. Otherwise, it attempts to
		/// convert the value in the <c>PROPVARIANT</c> structure into a double. If the source <c>PROPVARIANT</c> has type <c>VT_EMPTY</c> or
		/// a conversion is not possible, then PropVariantToDoubleWithDefault will return the default provided by dblDefault. See
		/// PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttodoublewithdefault PSSTDAPI_(DOUBLE)
		// PropVariantToDoubleWithDefault( REFPROPVARIANT propvarIn, DOUBLE dblDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "81584e13-0ef7-47ce-b78f-b4a79712ff1e")]
		public static extern double PropVariantToDoubleWithDefault([In] PROPVARIANT propvarIn, double dblDefault);

		/// <summary>Extracts the <see cref="FILETIME"/> structure from a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pstfOut">Specifies one of the time flags.</param>
		/// <param name="pftOut">When this function returns, contains the extracted <see cref="FILETIME"/> structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776542")]
		public static extern HRESULT PropVariantToFileTime([In] PROPVARIANT propVar, PSTIME_FLAGS pstfOut, out FILETIME pftOut);

		/// <summary>
		/// <para>Extracts data from a PROPVARIANT structure into a FILETIME vector.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgft">
		/// <para>Type: <c>FILETIME*</c></para>
		/// <para>
		/// Points to a buffer containing crgft FILETIME values. When this function returns, the buffer has been initialized with pcElem
		/// FILETIME elements extracted from the source PROPVARIANT structure.
		/// </para>
		/// </param>
		/// <param name="crgft">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size in elements of the buffer pointed to by prgft.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of FILETIME elements extracted from the source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgft.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a filetime vector value with a
		/// fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type VT_VECTOR | VT_FILETIME, this helper function extracts up to crgft FILETIME values and places
		/// them into the buffer pointed to by prgft. If the <c>PROPVARIANT</c> contains more elements than will fit into the prgft buffer,
		/// this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>The output FILETIMEs will use the same time zone as the source FILETIMEs.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToFileTimeVector to access
		/// a FILETIME vector value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttofiletimevector PSSTDAPI
		// PropVariantToFileTimeVector( REFPROPVARIANT propvar, FILETIME *prgft, ULONG crgft, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "ef665f50-3f3b-47db-9133-490305da5341")]
		public static extern HRESULT PropVariantToFileTimeVector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] FILETIME[] prgft, uint crgft, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly-allocated <see cref="FILETIME"/> vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of <see cref="FILETIME"/> values extracted from the source <see
		/// cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of <see cref="FILETIME"/> elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776544")]
		public static extern HRESULT PropVariantToFileTimeVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts a GUID value from a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pguid">When this function returns, contains the extracted property value if one exists.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776545")]
		public static extern HRESULT PropVariantToGUID([In] PROPVARIANT propVar, out Guid pguid);

		/// <summary>Extracts an Int16 property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="piRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776546")]
		public static extern HRESULT PropVariantToInt16([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.I2)] out short piRet);

		/// <summary>
		/// <para>Extracts a vector of <c>Int16</c> values from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>SHORT*</c></para>
		/// <para>
		/// Points to a buffer containing crgn SHORT values. When this function returns, the buffer has been initialized with pcElem SHORT
		/// elements extracted from the source PROPVARIANT structure.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgn in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>Int16</c> elements extracted from source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgn.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ThePROPVARIANTwas not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an <c>Int16</c> vector value
		/// with a fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type VT_VECTOR | VT_I2 or VT_ARRAY | VT_I2, this helper function extracts up to crgn Int16 values
		/// and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c> contains more elements than will fit into the prgn
		/// buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttoint16vector PSSTDAPI
		// PropVariantToInt16Vector( REFPROPVARIANT propvar, SHORT *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "33240552-7caa-4114-aad6-7341551b1fbe")]
		public static extern HRESULT PropVariantToInt16Vector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] short[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated Int16 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of Int16 values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of Int16 elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776548")]
		public static extern HRESULT PropVariantToInt16VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>
		/// Extracts the Int16 property value of a PROPVARIANT structure. If no value currently exists, then specified default value is returned.
		/// </para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="iDefault">
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Returns the extracted <c>short</c> value, or default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an <c>Int16</c> value and
		/// would like to use a default value if it does not. For instance, an application obtaining values from a property store can use
		/// this to safely extract the <c>SHORT</c> value for <c>Int16</c> properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_I2</c>, this helper function extracts the <c>Int16</c> value. Otherwise, it attempts to
		/// convert the value in the <c>PROPVARIANT</c> structure into a <c>SHORT</c>. If the source <c>PROPVARIANT</c> has type
		/// <c>VT_EMPTY</c> or a conversion is not possible, then PropVariantToInt16WithDefault will return the default provided by iDefault.
		/// See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttoint16withdefault PSSTDAPI_(SHORT)
		// PropVariantToInt16WithDefault( REFPROPVARIANT propvarIn, SHORT iDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "51221281-6e06-49f4-83c0-7330f2a6d67e")]
		public static extern short PropVariantToInt16WithDefault([In] PROPVARIANT propvarIn, short iDefault);

		/// <summary>Extracts an Int32 property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="plRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776550")]
		public static extern HRESULT PropVariantToInt32([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.I4)] out int plRet);

		/// <summary>
		/// <para>Extracts a vector of <c>long</c> values from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>
		/// Points to a buffer containing crgn <c>LONG</c> values. When this function returns, the buffer has been initialized with pcElem
		/// <c>LONG</c> elements extracted from the source PROPVARIANT.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgn in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>LONG</c> elements extracted from source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgn.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of <c>LONG</c>
		/// values with a fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_VECTOR</c> | <c>VT_I4</c> or <c>VT_ARRAY</c> | <c>VT_I4</c>, this helper function
		/// extracts up to crgn <c>LONG</c> values and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c> contains
		/// more elements than will fit into the prgn buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToInt32Vector to access an
		/// Int32 vector value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttoint32vector PSSTDAPI
		// PropVariantToInt32Vector( REFPROPVARIANT propvar, LONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "771fa1d7-c648-49d4-a6a2-5aa23f8c20b7")]
		public static extern HRESULT PropVariantToInt32Vector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated Int32 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of Int32 values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of Int32 elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776552")]
		public static extern HRESULT PropVariantToInt32VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>
		/// Extracts an <c>Int32</c> value from a PROPVARIANT structure. If no value currently exists, then the specified default value is returned.
		/// </para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="lDefault">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies a default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Returns extracted <c>LONG</c> value, or default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a <c>LONG</c> value and would
		/// like to use a default value if it does not. For instance, an application obtaining values from a property store can use this to
		/// safely extract the <c>LONG</c> value for <c>Int32</c> properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_I4</c>, this helper function extracts the <c>LONG</c> value. Otherwise, it attempts to
		/// convert the value in the <c>PROPVARIANT</c> structure into a <c>LONG</c>. If the source <c>PROPVARIANT</c> has type
		/// <c>VT_EMPTY</c> or a conversion is not possible, then PropVariantToInt32WithDefault will return the default provided by lDefault.
		/// See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToInt32WithDefault to
		/// access a <c>LONG</c> value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttoint32withdefault PSSTDAPI_(LONG)
		// PropVariantToInt32WithDefault( REFPROPVARIANT propvarIn, LONG lDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "1d014cad-a9a5-4a58-855e-21c6d3ba6dcd")]
		public static extern int PropVariantToInt32WithDefault([In] PROPVARIANT propvarIn, int lDefault);

		/// <summary>Extracts an Int64 property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pllRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776554")]
		public static extern HRESULT PropVariantToInt64([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.I8)] out long pllRet);

		/// <summary>
		/// <para>Extracts data from a PROPVARIANT structure into an <c>Int64</c> vector.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>LONGLONG*</c></para>
		/// <para>
		/// Points to a buffer containing crgn <c>LONGLONG</c> values. When this function returns, the buffer has been initialized with
		/// pcElem <c>LONGLONG</c> elements extracted from the source PROPVARIANT.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgn in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>LONGLONG</c> values extracted from the source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgn.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of <c>LONGLONG</c>
		/// values with a fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_VECTOR</c> | <c>VT_I8</c> or <c>VT_ARRAY</c> | <c>VT_I8</c>, this helper function
		/// extracts up to crgn <c>LONGLONG</c> values and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c> contains
		/// more elements than will fit into the prgn buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToInt64Vector to access an
		/// Int64 vector value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttoint64vector PSSTDAPI
		// PropVariantToInt64Vector( REFPROPVARIANT propvar, LONGLONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "cda5589a-726f-4e43-aec4-bb7a7ca62b1a")]
		public static extern HRESULT PropVariantToInt64Vector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated Int64 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of Int64 values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of Int64 elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776557")]
		public static extern HRESULT PropVariantToInt64VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>
		/// Extracts the <c>Int64</c> property value of a PROPVARIANT structure. If no value exists, then specified default value is returned.
		/// </para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="llDefault">
		/// <para>Type: <c>LONGLONG</c></para>
		/// <para>Specifies a default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LONGLONG</c></para>
		/// <para>Returns the extracted <c>LONGLONG</c> value, or default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a <c>LONGLONG</c> value and
		/// would like to use a default value if it does not. For instance, an application obtaining values from a property store can use
		/// this to safely extract the <c>LONGLONG</c> value for Int64 properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_I8</c>, this helper function extracts the <c>LONGLONG</c> value. Otherwise, it attempts
		/// to convert the value in the <c>PROPVARIANT</c> structure into a <c>LONGLONG</c>. If the source <c>PROPVARIANT</c> has type
		/// <c>VT_EMPTY</c> or a conversion is not possible, then PropVariantToInt64WithDefault will return the default provided by
		/// llDefault. See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToInt64WithDefault to
		/// access a <c>LONGLONG</c> value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttoint64withdefault PSSTDAPI_(LONGLONG)
		// PropVariantToInt64WithDefault( REFPROPVARIANT propvarIn, LONGLONG llDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6a051235-3e32-40d3-a17e-efc571592dae")]
		public static extern long PropVariantToInt64WithDefault([In] PROPVARIANT propvarIn, long llDefault);

		/// <summary>
		/// <para>Extracts a string value from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="psz">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>
		/// Points to a string buffer. When this function returns, the buffer is initialized with a <c>NULL</c> terminated Unicode string value.
		/// </para>
		/// </param>
		/// <param name="cch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the buffer pointed to by psz, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The value was extracted and the result buffer was NULL terminated.</term>
		/// </item>
		/// <item>
		/// <term>STRSAFE_E_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The copy operation failed due to insufficient buffer space. The destination buffer contains a truncated, null-terminated version
		/// of the intended result. In situations where truncation is acceptable, this may not necessarily be seen as a failure condition.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Some other error value</term>
		/// <term>The extraction failed for some other reason.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a string value. For instance,
		/// an application obtaining values from a property store can use this to safely extract a string value for string properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type VT_LPWSTR or <c>VT_BSTR</c>, this function extracts the string and places it into the provided
		/// buffer. Otherwise, it attempts to convert the value in the <c>PROPVARIANT</c> structure into a string. If a conversion is not
		/// possible, PropVariantToString will return a failure code and set psz to '\0'. See PropVariantChangeType for a list of possible
		/// conversions. Of note, <c>VT_EMPTY</c> is successfully converted to "".
		/// </para>
		/// <para>
		/// In addition to the terminating <c>NULL</c>, at most cch-1 characters are written into the buffer pointed to by psz. If the value
		/// in the source PROPVARIANT is longer than will fit into the buffer, a truncated <c>NULL</c> Terminated copy of the string is
		/// written to the buffer and this function returns <c>STRSAFE_E_INSUFFICIENT_BUFFER</c>. The resulting string will always be
		/// <c>NULL</c> terminated.
		/// </para>
		/// <para>In addition to the conversions provided by PropVariantChangeType, the following special cases apply to PropVariantToString.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Vector-valued PROPVARIANTs are converted to strings by separating each element with using "; ". For example, PropVariantToString
		/// converts a vector of 3 integers, {3, 1, 4}, to the string "3; 1; 4". The semicolon is independent of the current locale.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// VT_BLOB, VT_STREAM, VT_STREAMED_OBJECT, and VT_UNKNOWN values are converted to strings using an unsupported encoding. It is not
		/// possible to decode strings created in this way and the format may change in the future.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToString to access a string
		/// value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttostring PSSTDAPI PropVariantToString(
		// REFPROPVARIANT propvar, PWSTR psz, UINT cch );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "d545dc12-a780-4d95-8660-13b3f65725f9")]
		public static extern HRESULT PropVariantToString([In] PROPVARIANT propvar, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder psz, uint cch);

		/// <summary>Extracts a string property value from a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="ppszOut">When this function returns, contains a pointer to the extracted property value if one exists.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776560")]
		public static extern HRESULT PropVariantToStringAlloc([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszOut);

		/// <summary>
		/// <para>Extracts a vector of strings from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgsz">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>
		/// Pointer to a vector of string pointers. When this function returns, the buffer has been initialized with pcElem elements pointing
		/// to newly allocated strings containing the data extracted from the source PROPVARIANT.
		/// </para>
		/// </param>
		/// <param name="crgsz">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgsz, in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of strings extracted from source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The sourcePROPVARIANTcontained more than crgsz values. The buffer pointed to by prgsz.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ThePROPVARIANTwas not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of string values
		/// with a fixed number of elements.
		/// </para>
		/// <para>This function works for the following PROPVARIANT types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_VECTOR | VT_LPWSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_BSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_BSTR</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has a supported type, this helper function extracts up to crgsz string values and places an allocated
		/// copy of each into the buffer pointed to by prgsz. If the <c>PROPVARIANT</c> contains more elements than will fit into the prgsz
		/// buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>
		/// Since each string in pointed to by the output buffer has been newly allocated, the calling application is responsible for using
		/// CoTaskMemFree to free each string in the output buffer when they are no longer needed.
		/// </para>
		/// <para>
		/// If a <c>BSTR</c> in the source PROPVARIANT is <c>NULL</c>, it is converted to a newly allocated string containing "" in the output.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttostringvector PSSTDAPI
		// PropVariantToStringVector( REFPROPVARIANT propvar, PWSTR *prgsz, ULONG crgsz, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6618ee02-1939-4c9c-8690-a8cd5d668cdb")]
		public static extern HRESULT PropVariantToStringVector([In] PROPVARIANT propvar, IntPtr prgsz, uint crgsz, out uint pcElem);

		/// <summary>
		/// <para>Extracts a vector of strings from a PROPVARIANT structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="crgsz">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of strings requested.</para>
		/// </param>
		/// <param name="prgsz">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>When this function returns, the array of strings containing the data extracted from the source PROPVARIANT.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The sourcePROPVARIANTcontained more than crgsz values. The buffer pointed to by prgsz.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>ThePROPVARIANTwas not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of string values
		/// with a fixed number of elements.
		/// </para>
		/// <para>This function works for the following PROPVARIANT types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_VECTOR | VT_LPWSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_VECTOR | VT_BSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | VT_BSTR</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the source PROPVARIANT has a supported type, this helper function extracts up to crgsz string values and places an allocated
		/// copy of each into the buffer pointed to by prgsz. If the <c>PROPVARIANT</c> contains more elements than will fit into the prgsz
		/// buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>
		/// Since each string in pointed to by the output buffer has been newly allocated, the calling application is responsible for using
		/// CoTaskMemFree to free each string in the output buffer when they are no longer needed.
		/// </para>
		/// <para>
		/// If a <c>BSTR</c> in the source PROPVARIANT is <c>NULL</c>, it is converted to a newly allocated string containing "" in the output.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		public static HRESULT PropVariantToStringVector([In] PROPVARIANT propvar, uint crgsz, out string[] prgsz)
		{
			SafeCoTaskMemHandle ptr = new SafeCoTaskMemHandle(IntPtr.Size * (int)crgsz);
			HRESULT hr = PropVariantToStringVector(propvar, (IntPtr)ptr, crgsz, out uint cnt);
			prgsz = new string[0];
			if (hr.Failed)
			{
				return hr;
			}

			prgsz = ptr.ToEnumerable<IntPtr>((int)cnt).Select(p => ((SafeCoTaskMemHandle)p).ToString(-1)).ToArray();
			return hr;
		}

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated strings in a newly allocated vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of strings extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of string elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776562")]
		public static extern HRESULT PropVariantToStringVectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// Extracts the string property value of a <see cref="PROPVARIANT"/> structure. If no value exists, then the specified default value
		/// is returned.
		/// </summary>
		/// <param name="propvarIn">Reference to a source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pszDefault">Pointer to a default Unicode string value, for use where no value currently exists. May be NULL.</param>
		/// <returns>Returns string value or the default.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776563")]
		public static extern string PropVariantToStringWithDefault([In] PROPVARIANT propvarIn, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDefault);

		/// <summary>
		/// <para>Extracts a string from a PROPVARIANT structure and places it into a STRRET structure.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="pstrret">
		/// <para>Type: <c>STRRET*</c></para>
		/// <para>
		/// Points to the STRRET structure. When this function returns, the structure has been initialized to contain a copy of the extracted string.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in applications that wish to convert a string value in a PROPVARIANT structure into a STRRET
		/// structure. For instance, an application implementing IShellFolder::GetDisplayNameOf may find this function useful.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type VT_LPWSTR or VT_BSTR, this function extracts the string and places it into the STRRET
		/// structure. Otherwise, it attempts to convert the value in the <c>PROPVARIANT</c> structure into a string. If a conversion is not
		/// possible, PropVariantToString will return a failure code. See PropVariantChangeType for a list of possible conversions. Of note,
		/// VT_EMPTY is successfully converted to "".
		/// </para>
		/// <para>In addition to the conversions provided by PropVariantChangeType, the following special cases apply to PropVariantToString.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Vector-valued PROPVARIANTs are converted to strings by separating each element with using "; ". For example, PropVariantToString
		/// converts a vector of 3 integers, {3, 1, 4}, to the string "3; 1; 4". The semicolon is independent of the current locale.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// VT_BLOB, VT_STREAM, VT_STREAMED_OBJECT, and VT_UNKNOWN values are converted to strings using an unsupported encoding. It is not
		/// possible to decode strings created in this way and the format may change in the future.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the extraction is successful, the function will initialize uType member of the STRRET structure with STRRET_WSTR and set the
		/// pOleStr member of that structure to point to an allocated copy of the string. The calling application is responsible for using
		/// CoTaskMemFree or StrRetToStr to free this string when it is no longer needed.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToString to access a string
		/// value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttostrret PSSTDAPI PropVariantToStrRet(
		// REFPROPVARIANT propvar, STRRET *pstrret );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "a1a33606-172d-4ee7-98c9-ffec8eed98bf")]
		public static extern HRESULT PropVariantToStrRet([In] PROPVARIANT propvar, IntPtr pstrret);

		/// <summary>Extracts a UInt16 property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="puiRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776565")]
		public static extern HRESULT PropVariantToUInt16([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.U2)] out ushort puiRet);

		/// <summary>
		/// <para>Extracts data from a PROPVARIANT structure into an <c>unsigned short</c> vector.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>USHORT*</c></para>
		/// <para>
		/// Points to a buffer containing crgn <c>unsigned short</c> values. When this function returns, the buffer has been initialized with
		/// pcElem <c>unsigned short</c> elements extracted from the source PROPVARIANT.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgn in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>unsigned short</c> values extracted from the source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgn.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of <c>unsigned
		/// short</c> values with a fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_VECTOR</c> | <c>VT_UI2</c> or <c>VT_ARRAY</c> | <c>VT_UI2</c>, this helper function
		/// extracts up to crgn <c>unsigned short</c> values and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c>
		/// contains more elements than will fit into the prgn buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToUInt16Vector to access an
		/// <c>unsigned short</c> vector value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttouint16vector PSSTDAPI
		// PropVariantToUInt16Vector( REFPROPVARIANT propvar, USHORT *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "34fe404c-cef6-47d9-9eaf-8ab151bd4726")]
		public static extern HRESULT PropVariantToUInt16Vector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ushort[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated UInt16 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of UInt16 values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of UInt16 elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776567")]
		public static extern HRESULT PropVariantToUInt16VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>
		/// Extracts an <c>unsigned short</c> value from a PROPVARIANT structure. If no value exists, then the specified default value is returned.
		/// </para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="uiDefault">
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Specifies a default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>unsigned short</c></para>
		/// <para>Returns extracted <c>unsigned short</c> value, or default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a <c>unsigned short</c> value.
		/// For instance, an application obtaining values from a property store can use this to safely extract the <c>unsigned short</c>
		/// value for UInt16 properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_UI2</c>, this helper function extracts the <c>unsigned short</c> value. Otherwise, it
		/// attempts to convert the value in the <c>PROPVARIANT</c> structure into a <c>unsigned short</c>. If a conversion is not possible,
		/// PropVariantToUInt16 will return a failure code and set puiRet to 0. See PropVariantChangeType for a list of possible conversions.
		/// Of note, <c>VT_EMPTY</c> is successfully converted to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToUInt16 to access a
		/// <c>unsigned short</c> value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttouint16withdefault PSSTDAPI_(USHORT)
		// PropVariantToUInt16WithDefault( REFPROPVARIANT propvarIn, USHORT uiDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "4346cef2-5e43-47bf-9bfb-0ede923872fd")]
		public static extern ushort PropVariantToUInt16WithDefault([In] PROPVARIANT propvarIn, ushort uiDefault);

		/// <summary>Extracts a UInt32 property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pulRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776569")]
		public static extern HRESULT PropVariantToUInt32([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.U4)] out uint pulRet);

		/// <summary>
		/// <para>Extracts data from a PROPVARIANT structure into an <c>ULONG</c> vector.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// Points to a buffer containing crgn <c>ULONG</c> values. When this function returns, the buffer has been initialized with pcElem
		/// <c>ULONG</c> elements extracted from the source PROPVARIANT.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgn, in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>ULONG</c> values extracted from the source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgn is too small.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of <c>ULONG</c>
		/// values with a fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_VECTOR</c> | <c>VT_UI4</c> or <c>VT_ARRAY</c> | <c>VT_UI4</c>, this helper function
		/// extracts up to crgn <c>ULONG</c> values and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c> contains
		/// more elements than will fit into the prgn buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToUInt32Vector to access a
		/// <c>ULONG</c> vector value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttouint32vector PSSTDAPI
		// PropVariantToUInt32Vector( REFPROPVARIANT propvar, ULONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "721a2f67-dfd1-4d95-8290-4457b8954a02")]
		public static extern HRESULT PropVariantToUInt32Vector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated UInt32 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of UInt32 values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of UInt32 elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776571")]
		public static extern HRESULT PropVariantToUInt32VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>Extracts a <c>ULONG</c> value from a PROPVARIANT structure. If no value exists, then a specified default value is returned.</para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="ulDefault">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies a default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Returns extracted <c>ULONG</c> value, or default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a <c>ULONG</c> value and would
		/// like to use a default value if it does not. For instance, an application obtaining values from a property store can use this to
		/// safely extract the <c>ULONG</c> value for <c>UInt32</c> properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_UI4</c>, this helper function extracts the <c>ULONG</c> value. Otherwise, it attempts to
		/// convert the value in the <c>PROPVARIANT</c> structure into a <c>ULONG</c>. If the source <c>PROPVARIANT</c> has type
		/// <c>VT_EMPTY</c> or a conversion is not possible, then PropVariantToUInt32WithDefault will return the default provided by
		/// ulDefault. See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToUInt32WithDefault to
		/// access a <c>ULONG</c> value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttouint32withdefault PSSTDAPI_(ULONG)
		// PropVariantToUInt32WithDefault( REFPROPVARIANT propvarIn, ULONG ulDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "8ace8c3f-fea2-4b20-9e0b-3abfbd569b54")]
		public static extern uint PropVariantToUInt32WithDefault([In] PROPVARIANT propvarIn, uint ulDefault);

		/// <summary>Extracts a UInt64 property value of a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pullRet">When this function returns, contains the extracted property value if one exists; otherwise, 0.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776573")]
		public static extern HRESULT PropVariantToUInt64([In] PROPVARIANT propVar, [MarshalAs(UnmanagedType.U8)] out ulong pullRet);

		/// <summary>
		/// <para>Extracts data from a PROPVARIANT structure into a <c>ULONGLONG</c> vector.</para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>ULONGLONG*</c></para>
		/// <para>
		/// Points to a buffer containing crgn <c>ULONGLONG</c> values. When this function returns, the buffer has been initialized with
		/// pcElem <c>ULONGLONG</c> elements extracted from the source PROPVARIANT.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of the buffer pointed to by prgn, in elements.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>ULONGLONG</c> values extracted from the source PROPVARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Returns S_OK if successful, or an error value otherwise.</term>
		/// </item>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source PROPVARIANT contained more than crgn values. The buffer pointed to by prgn.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The PROPVARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold an vector of <c>ULONGLONG</c>
		/// values with a fixed number of elements.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_VECTOR</c> | <c>VT_UI8</c> or <c>VT_ARRAY</c> | <c>VT_UI8</c>, this helper function
		/// extracts up to crgn <c>ULONGLONG</c> values and places them into the buffer pointed to by prgn. If the <c>PROPVARIANT</c>
		/// contains more elements than will fit into the prgn buffer, this function returns an error and sets pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToUInt64Vector to access a
		/// <c>ULONGLONG</c> vector value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttouint64vector PSSTDAPI
		// PropVariantToUInt64Vector( REFPROPVARIANT propvar, ULONGLONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "596c7a35-6645-4f66-b924-b71278778776")]
		public static extern HRESULT PropVariantToUInt64Vector([In] PROPVARIANT propvar, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a <see cref="PROPVARIANT"/> structure into a newly allocated UInt64 vector.</summary>
		/// <param name="propVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pprgf">
		/// When this function returns, contains a pointer to a vector of UInt64 values extracted from the source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <param name="pcElem">
		/// When this function returns, contains the count of UInt64 elements extracted from source <see cref="PROPVARIANT"/> structure.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776575")]
		public static extern HRESULT PropVariantToUInt64VectorAlloc([In] PROPVARIANT propVar, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>
		/// <para>
		/// Extracts <c>ULONGLONG</c> value from a PROPVARIANT structure. If no value exists, then the specified default value is returned.
		/// </para>
		/// </summary>
		/// <param name="propvarIn">
		/// <para>Type: <c>REFPROPVARIANT</c></para>
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="ullDefault">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>Specifies a default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>Returns the extracted unsigned <c>LONGLONG</c> value, or a default.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used in places where the calling application expects a PROPVARIANT to hold a <c>ULONGLONG</c> value and
		/// would like to use a default value if it does not. For instance, an application obtaining values from a property store can use
		/// this to safely extract the <c>ULONGLONG</c> value for <c>UInt64</c> properties.
		/// </para>
		/// <para>
		/// If the source PROPVARIANT has type <c>VT_UI8</c>, this helper function extracts the <c>ULONGLONG</c> value. Otherwise, it
		/// attempts to convert the value in the <c>PROPVARIANT</c> structure into a <c>ULONGLONG</c>. If the source <c>PROPVARIANT</c> has
		/// type <c>VT_EMPTY</c> or a conversion is not possible, then PropVariantToUInt64WithDefault will return the default provided by
		/// ullDefault. See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use PropVariantToUInt64WithDefault to
		/// access a <c>ULONGLONG</c> value in a PROPVARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propvarutil/nf-propvarutil-propvarianttouint64withdefault
		// PSSTDAPI_(ULONGLONG) PropVariantToUInt64WithDefault( REFPROPVARIANT propvarIn, ULONGLONG ullDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "8ca0e25e-6a3f-41ff-9a4a-7cca9a02d07c")]
		public static extern ulong PropVariantToUInt64WithDefault([In] PROPVARIANT propvarIn, ulong ullDefault);

		/// <summary>Converts the contents of a <see cref="PROPVARIANT"/> structure to a VARIANT structure.</summary>
		/// <param name="pPropVar">Reference to the source <see cref="PROPVARIANT"/> structure.</param>
		/// <param name="pVar">Pointer to a VARIANT structure. When this function returns, the VARIANT contains the converted information.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776577")]
		public static extern HRESULT PropVariantToVariant([In] PROPVARIANT pPropVar, IntPtr pVar);

		/// <summary>
		/// <para>
		/// Extracts data from a PROPVARIANT structure into a Windows Runtime property value. Note that in some cases more than one
		/// PROPVARIANT type maps to a single Windows Runtime property type.
		/// </para>
		/// </summary>
		/// <param name="propvar">
		/// <para>Reference to a source PROPVARIANT structure.</para>
		/// </param>
		/// <param name="riid">
		/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_IPropertyValue (defined in Windows.Foundation.h).</para>
		/// </param>
		/// <param name="ppv">
		/// <para>
		/// When this method returns successfully, contains the interface pointer requested in riid. This is typically an IPropertyValue
		/// pointer. If the call fails, this value is <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// We recommend that you use the IID_PPV_ARGS macro, defined in Objbase.h, to package the riid and ppv parameters. This macro
		/// provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a coding
		/// error in riid that could lead to unexpected results.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propsys/nf-propsys-propvarianttowinrtpropertyvalue PSSTDAPI
		// PropVariantToWinRTPropertyValue( REFPROPVARIANT propvar, REFIID riid, void **ppv );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "38DD3673-17FD-4F2A-BA58-A1A9983B92BF")]
		public static extern HRESULT PropVariantToWinRTPropertyValue([In] PROPVARIANT propvar, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Deserializes a specified <c>SERIALIZEDPROPERTYVALUE</c> structure, creating a <c>PROPVARIANT</c> structure.</summary>
		/// <param name="pprop">
		/// <para>Type: <c>const <c>SERIALIZEDPROPERTYVALUE</c>*</c></para>
		/// <para>Pointer to a <c>SERIALIZEDPROPERTYVALUE</c> structure.</para>
		/// </param>
		/// <param name="cbMax">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The size of the <c>SERIALIZEDPROPERTYVALUE</c> structure, in bytes.</para>
		/// </param>
		/// <param name="ppropvar">
		/// <para>Type: <c><c>PROPVARIANT</c>*</c></para>
		/// <para>Pointer to the resulting <c>PROPVARIANT</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT StgDeserializePropVariant( _In_ const SERIALIZEDPROPERTYVALUE *pprop, _In_ ULONG cbMax, _Out_ PROPVARIANT *ppropvar); https://msdn.microsoft.com/en-us/library/windows/desktop/bb776578(v=vs.85).aspx
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776578")]
		public static extern HRESULT StgDeserializePropVariant([In] IntPtr pprop, [In] uint cbMax, [In, Out] PROPVARIANT ppropvar);

		/// <summary>Serializes a specified <c>PROPVARIANT</c> structure, creating a <c>SERIALIZEDPROPERTYVALUE</c> structure.</summary>
		/// <param name="ppropvar">
		/// <para>Type: <c>const <c>PROPVARIANT</c>*</c></para>
		/// <para>A constant pointer to the source <c>PROPVARIANT</c> structure.</para>
		/// </param>
		/// <param name="ppProp">
		/// <para>Type: <c><c>SERIALIZEDPROPERTYVALUE</c>**</c></para>
		/// <para>The address of a pointer to the <c>SERIALIZEDPROPERTYVALUE</c> structure.</para>
		/// </param>
		/// <param name="pcb">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>A pointer to the value representing the size of the <c>SERIALIZEDPROPERTYVALUE</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT StgSerializePropVariant( _In_ const PROPVARIANT *ppropvar, _Out_ SERIALIZEDPROPERTYVALUE **ppProp, _Out_ ULONG *pcb); https://msdn.microsoft.com/en-us/library/windows/desktop/bb776579(v=vs.85).aspx
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776579")]
		public static extern HRESULT StgSerializePropVariant([In] PROPVARIANT ppropvar, out SafeCoTaskMemHandle ppProp, out uint pcb);

		/// <summary>Copies the contents of a VARIANT structure to a <see cref="PROPVARIANT"/> structure.</summary>
		/// <param name="pVar">Pointer to a source VARIANT structure.</param>
		/// <param name="pPropVar">
		/// Pointer to a <see cref="PROPVARIANT"/> structure. When this function returns, the <see cref="PROPVARIANT"/> contains the
		/// converted information.
		/// </param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[DllImport(Lib.PropSys, ExactSpelling = true)]
		[PInvokeData("Propvarutil.h", MSDNShortId = "bb776616")]
		public static extern HRESULT VariantToPropVariant([In] IntPtr pVar, [In, Out] PROPVARIANT pPropVar);
	}
}