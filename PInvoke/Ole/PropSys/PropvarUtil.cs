using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;
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

		/// <summary>Frees the memory and references used by an array of VARIANT structures stored in an array.</summary>
		/// <param name="pvars">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>Array of VARIANT structures to free.</para>
		/// </param>
		/// <param name="cvars">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the array specified by pvars.</para>
		/// </param>
		/// <returns>No return value.</returns>
		/// <remarks>
		/// <para>
		/// This function releases the memory and references held by each structure in the array before it sets the structures to zero.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use ClearVariantArray</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-clearvariantarray PSSTDAPI_(void) ClearVariantArray(
		// VARIANT *pvars, UINT cvars );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "8126392e-d86c-420c-9f0d-ca7cb97030b0")]
		public static extern void ClearVariantArray([In, Out] VARIANT[] pvars, uint cvars);

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

		/// <summary>Initializes the property variant from string.</summary>
		/// <param name="psz">Pointer to a buffer that contains the source Unicode string.</param>
		/// <param name="ppropvar">When this function returns, contains the initialized PROPVARIANT structure.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("propvarutil.h", MSDNShortId = "cee95d17-532d-8e34-a392-a04778f9bc00")]
		public static HRESULT InitPropVariantFromString(string psz, [In, Out] PROPVARIANT ppropvar)
		{
			PropVariantClear(ppropvar);
			if (psz is null) return HRESULT.E_INVALIDARG;
			ppropvar._ptr = Marshal.StringToCoTaskMemUni(psz);
			ppropvar.vt = VARTYPE.VT_LPWSTR;
			return HRESULT.S_OK;
		}

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

		/// <summary>Initializes a VARIANT structure from an array of Boolean values.</summary>
		/// <param name="prgf">
		/// <para>Type: <c>const BOOL*</c></para>
		/// <para>Pointer to source array of Boolean values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_BOOL variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromBooleanArray.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfrombooleanarray PSSTDAPI
		// InitVariantFromBooleanArray( const BOOL *prgf, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "50780131-c0ed-443b-86e8-deb996a5c98e")]
		public static extern HRESULT InitVariantFromBooleanArray([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool, SizeParamIndex = 1)] bool[] prgf, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with the contents of a buffer.</summary>
		/// <param name="pv">
		/// <para>Type: <c>const VOID*</c></para>
		/// <para>Pointer to the source buffer.</para>
		/// </param>
		/// <param name="cb">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The length of the buffer, in bytes.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_UI1 variant..</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromBuffer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfrombuffer PSSTDAPI
		// InitVariantFromBuffer( const void *pv, UINT cb, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "4dd28a13-2161-4258-a32f-57e5bd8ce091")]
		public static extern HRESULT InitVariantFromBuffer([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, uint cb, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of values of type DOUBLE.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const DOUBLE*</c></para>
		/// <para>Pointer to the source array of DOUBLE values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_R8 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromDoubleArray.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromdoublearray PSSTDAPI
		// InitVariantFromDoubleArray( const DOUBLE *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "781b6999-4551-499d-ba37-0a7e05fc6eab")]
		public static extern HRESULT InitVariantFromDoubleArray([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] prgn, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with the contents of a FILETIME structure.</summary>
		/// <param name="pft">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>Pointer to date and time information stored in a FILETIME structure.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_DATE variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromFileTime.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromfiletime PSSTDAPI
		// InitVariantFromFileTime( const FILETIME *pft, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "cd61a268-ef73-4dd3-98d4-9811922d01f4")]
		public static extern HRESULT InitVariantFromFileTime(in FILETIME pft, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of FILETIME structures.</summary>
		/// <param name="prgft">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>Pointer to an array of FILETIME structures.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgft.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_DATE variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromFileTimeArray.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromfiletimearray PSSTDAPI
		// InitVariantFromFileTimeArray( const FILETIME *prgft, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "d1b25aec-f302-4d39-93c1-0fcb2d7dbf45")]
		public static extern HRESULT InitVariantFromFileTimeArray([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] FILETIME[] prgft, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure based on a <c>GUID</c>. The structure is initialized as a <c>VT_BSTR</c> type.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Reference to the source <c>GUID</c>.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_BSTR variant, formatting the GUID in a form similar to .</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use <c>InitVariantFromGUIDAsString</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromguidasstring PSSTDAPI
		// InitVariantFromGUIDAsString( REFGUID guid, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "2a78257a-a8ce-45e8-aea2-dfa9f380528a")]
		public static extern HRESULT InitVariantFromGUIDAsString(in Guid guid, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of 16-bit integer values.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const SHORT*</c></para>
		/// <para>Pointer to the source array of <c>SHORT</c> values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_I2 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromInt16Array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromint16array PSSTDAPI
		// InitVariantFromInt16Array( const SHORT *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6aeca46e-96b5-42cb-b5db-2c1e3152d629")]
		public static extern HRESULT InitVariantFromInt16Array([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] short[] prgn, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of 32-bit integer values.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const LONG*</c></para>
		/// <para>Pointer to the source array of <c>LONG</c> values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_I4 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromInt32Array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromint32array PSSTDAPI
		// InitVariantFromInt32Array( const LONG *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "0805d510-ee9c-4f10-978d-c34d572488f9")]
		public static extern HRESULT InitVariantFromInt32Array([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] prgn, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of 64-bit integer values.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const LONGLONG*</c></para>
		/// <para>Pointer to the source array of <c>LONGLONG</c> values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// <para>The number of array elements.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_I8 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromInt64Array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromint64array PSSTDAPI
		// InitVariantFromInt64Array( const LONGLONG *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "18e9c804-b5e4-4abe-adcd-eaa402c6c94a")]
		public static extern HRESULT InitVariantFromInt64Array([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] prgn, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure based on a string resource imbedded in an executable file.</summary>
		/// <param name="hinst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>Handle to an instance of the module whose executable file contains the string resource.</para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Integer identifier of the string to be loaded.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Creates a VT_BSTR variant. If the resource does not exist, this function initializes the VARIANT as VT_EMPTY and returns a
		/// failure code.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromResource.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromresource PSSTDAPI
		// InitVariantFromResource( HINSTANCE hinst, UINT id, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "ae309a04-7b21-46ef-b481-2593dc162e19")]
		public static extern HRESULT InitVariantFromResource(HINSTANCE hinst, uint id, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of strings.</summary>
		/// <param name="prgsz">
		/// <para>Type: <c>PCWSTR*</c></para>
		/// <para>Pointer to an array of strings.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgsz.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_BSTR variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromStringArray.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromstringarray PSSTDAPI
		// InitVariantFromStringArray( PCWSTR *prgsz, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "f46cfc71-9e27-4ba1-8a32-5b279b628732")]
		public static extern HRESULT InitVariantFromStringArray([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1, ArraySubType = UnmanagedType.LPWStr)] string[] prgsz, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of unsigned 16-bit integer values.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const USHORT*</c></para>
		/// <para>Pointer to the source array of <c>USHORT</c> values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_UI2 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromUInt16Array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromuint16array PSSTDAPI
		// InitVariantFromUInt16Array( const USHORT *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "57fe1dd2-48a5-486e-a2cb-53cf0b8f96b0")]
		public static extern HRESULT InitVariantFromUInt16Array([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] prgn, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of unsigned 32-bit integer values.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const ULONG*</c></para>
		/// <para>Pointer to the source array of <c>ULONG</c> values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_UI4 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromUInt32Array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromuint32array PSSTDAPI
		// InitVariantFromUInt32Array( const ULONG *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "b08e61bc-8b76-4baf-acf7-9eb97e521b65")]
		public static extern HRESULT InitVariantFromUInt32Array([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] prgn, uint cElems, out VARIANT pvar);

		/// <summary>Initializes a VARIANT structure with an array of unsigned 64-bit integer values.</summary>
		/// <param name="prgn">
		/// <para>Type: <c>const ULONGLONG*</c></para>
		/// <para>Pointer to the source array of <c>ULONGLONG</c> values.</para>
		/// </param>
		/// <param name="cElems">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the array pointed to by prgn.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Creates a VT_ARRAY | VT_UI8 variant.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromUInt64Array.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromuint64array PSSTDAPI
		// InitVariantFromUInt64Array( const ULONGLONG *prgn, ULONG cElems, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "67886e29-c3dd-4bfd-b53f-761c16daaf63")]
		public static extern HRESULT InitVariantFromUInt64Array([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ulong[] prgn, uint cElems, ref object pvar);

		/// <summary>Initializes a VARIANT structure with a value stored in another <c>VARIANT</c> structure.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to the source VARIANT structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Index of one of the source VARIANT structure elements.</para>
		/// </param>
		/// <param name="pvar">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>When this function returns, contains the initialized VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function works for VARIANT structures of the following types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>VT_BSTR</term>
		/// </item>
		/// <item>
		/// <term>VT_BOOL</term>
		/// </item>
		/// <item>
		/// <term>VT_I2</term>
		/// </item>
		/// <item>
		/// <term>VT_I4</term>
		/// </item>
		/// <item>
		/// <term>VT_I8</term>
		/// </item>
		/// <item>
		/// <term>VT_U12</term>
		/// </item>
		/// <item>
		/// <term>VT_U14</term>
		/// </item>
		/// <item>
		/// <term>VT_U18</term>
		/// </item>
		/// <item>
		/// <term>VT_DATE</term>
		/// </item>
		/// <item>
		/// <term>VT_ARRAY | (any one of VT_BSTR, VT_BOOL, VT_I2, VT_I4, VT_I8, VT_U12, VT_U14, VT_U18, VT_DATE)</term>
		/// </item>
		/// </list>
		/// <para>Additional types may be supported in the future.</para>
		/// <para>
		/// This function extracts a single value from the source VARIANT structure and uses that value to initialize the output
		/// <c>VARIANT</c> structure. The calling application must use VariantClear to free the <c>VARIANT</c> referred to by pvar when it is
		/// no longer needed.
		/// </para>
		/// <para>If the source VARIANT is an array, iElem must be less than the number of elements in the array.</para>
		/// <para>If the source VARIANT has a single value, iElem must be 0.</para>
		/// <para>If the source VARIANT is empty, this function always returns an error code.</para>
		/// <para>You can use VariantGetElementCount to obtain the number of elements in the array or array.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromVariantArrayElem in an
		/// iteration statement to access the values in a VARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromvariantarrayelem PSSTDAPI
		// InitVariantFromVariantArrayElem( REFVARIANT varIn, ULONG iElem, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "531731a5-7a13-49be-8512-5cf25c96ee35")]
		public static extern HRESULT InitVariantFromVariantArrayElem(in VARIANT varIn, uint iElem, out VARIANT pvar);

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
		/// When this function returns, contains a pointer to a vector of <see cref="FILETIME"/> values extracted from the source
		/// <see cref="PROPVARIANT"/> structure.
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
		public static HRESULT PropVariantToStringVector([In] PROPVARIANT propvar, out string[] prgsz)
		{
			var ve = (VarEnum)((int)propvar.vt & 0x0FFF);
			if ((!propvar.vt.HasFlag(VARTYPE.VT_VECTOR) || ve != VarEnum.VT_LPWSTR && ve != VarEnum.VT_BSTR) && (!propvar.vt.HasFlag(VARTYPE.VT_ARRAY) || ve != VarEnum.VT_BSTR))
				throw new ArgumentException("Unsupported element type.", nameof(propvar));
			HRESULT hr = PropVariantToStringVectorAlloc(propvar, out var ptr, out uint cnt);
			if (hr.Failed)
			{
				prgsz = new string[0];
				return hr;
			}
			prgsz = new string[(int)cnt];
			var sptrs = ptr.ToArray<IntPtr>((int)cnt);
			for (int i = 0; i < cnt; i++)
			{
				prgsz[i] = Marshal.PtrToStringUni(sptrs[i]);
				Marshal.FreeCoTaskMem(sptrs[i]);
			}
			ptr.Dispose();
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

		/// <summary>Compares two variant structures, based on default comparison rules.</summary>
		/// <param name="var1">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a first variant structure.</para>
		/// </param>
		/// <param name="var2">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a second variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>INT</c></para>
		/// <list type="bullet">
		/// <item>
		/// <term>Returns 1 if var1 is greater than var2</term>
		/// </item>
		/// <item>
		/// <term>Returns 0 if var1 equals var2</term>
		/// </item>
		/// <item>
		/// <term>Returns -1 if var1 is less than var2</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Note</c> This function does not support the comparison of different VARIANT types. If the types named in var1 and var2 are
		/// different, the results are undefined and should be ignored. Calling applications should ensure that they are comparing two of the
		/// same type before they call this function. The PropVariantChangeType function can be used to convert the two structures to the
		/// same type.
		/// </para>
		/// <para>By default, VT_NULL / VT_EMPTY / 0-element vectors are considered to be less than any other vartype.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantcompare PSSTDAPI_(int) VariantCompare(
		// REFVARIANT var1, REFVARIANT var2 );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "45aed78c-1614-4aad-a930-c44615546d6f")]
		public static extern int VariantCompare(in VARIANT var1, in VARIANT var2);

		/// <summary>Extracts a single Boolean element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pfVal">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetbooleanelem PSSTDAPI
		// VariantGetBooleanElem( REFVARIANT var, ULONG iElem, BOOL *pfVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "d21ad8cc-5919-4582-a593-64bd98a82a89")]
		public static extern HRESULT VariantGetBooleanElem(in VARIANT var, uint iElem, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

		/// <summary>Extracts one <c>double</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>DOUBLE*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetdoubleelem PSSTDAPI VariantGetDoubleElem(
		// REFVARIANT var, ULONG iElem, DOUBLE *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "cc6cb3a0-ba39-4088-8d72-082f6a4e39d3")]
		public static extern HRESULT VariantGetDoubleElem(in VARIANT var, uint iElem, out double pnVal);

		/// <summary>Retrieves the element count of a variant structure.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Returns the element count for values of type VT_ARRAY; otherwise, returns 1.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetelementcount PSSTDAPI_(ULONG)
		// VariantGetElementCount( REFVARIANT varIn );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "2bf96650-c0c4-4c99-9a04-d36d506b8f68")]
		public static extern uint VariantGetElementCount(in VARIANT varIn);

		/// <summary>Extracts a single <c>Int16</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>SHORT*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetint16elem PSSTDAPI VariantGetInt16Elem(
		// REFVARIANT var, ULONG iElem, SHORT *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "fd572a65-c74c-490e-8cff-aa9ba54da5a1")]
		public static extern HRESULT VariantGetInt16Elem(in VARIANT var, uint iElem, out short pnVal);

		/// <summary>Extracts a single <c>Int32</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetint32elem PSSTDAPI VariantGetInt32Elem(
		// REFVARIANT var, ULONG iElem, LONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "de67face-9284-4e0a-8ea7-d4b6e7c037fc")]
		public static extern HRESULT VariantGetInt32Elem(in VARIANT var, uint iElem, out int pnVal);

		/// <summary>Extracts a single <c>Int64</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>LONGLONG*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetint64elem PSSTDAPI VariantGetInt64Elem(
		// REFVARIANT var, ULONG iElem, LONGLONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "285705d3-3b8e-40ad-abf2-1adc5adda3d8")]
		public static extern HRESULT VariantGetInt64Elem(in VARIANT var, uint iElem, out long pnVal);

		/// <summary>Extracts a single wide string element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies a vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="ppszVal">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>The address of a pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetstringelem PSSTDAPI VariantGetStringElem(
		// REFVARIANT var, ULONG iElem, PWSTR *ppszVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "c4d1a37e-f7d1-4c0e-8d05-93a0153f2878")]
		public static extern HRESULT VariantGetStringElem(in VARIANT var, uint iElem, out StrPtrUni ppszVal);

		/// <summary>Extracts a single unsigned <c>Int16</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies a vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>USHORT*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetuint16elem PSSTDAPI VariantGetUInt16Elem(
		// REFVARIANT var, ULONG iElem, USHORT *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6d2a8b0b-bcd2-4bad-a006-2443eabd7a16")]
		public static extern HRESULT VariantGetUInt16Elem(in VARIANT var, uint iElem, out ushort pnVal);

		/// <summary>Extracts a single unsigned <c>Int32</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetuint32elem PSSTDAPI VariantGetUInt32Elem(
		// REFVARIANT var, ULONG iElem, ULONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "b950d051-2500-4523-8307-5817274878f2")]
		public static extern HRESULT VariantGetUInt32Elem(in VARIANT var, uint iElem, out uint pnVal);

		/// <summary>Extracts a single unsigned <c>Int64</c> element from a variant structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iElem">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies vector or array index; otherwise, value must be 0.</para>
		/// </param>
		/// <param name="pnVal">
		/// <para>Type: <c>ULONGLONG*</c></para>
		/// <para>Pointer to the extracted element value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-variantgetuint64elem PSSTDAPI VariantGetUInt64Elem(
		// REFVARIANT var, ULONG iElem, ULONGLONG *pnVal );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "7fd3c87b-5511-4dbc-b99e-65656a96303e")]
		public static extern HRESULT VariantGetUInt64Elem(in VARIANT var, uint iElem, out ulong pnVal);

		/// <summary>
		/// Extracts the value of a Boolean property from a VARIANT structure. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="pfRet">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this function returns, contains the extracted value if one exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a VARIANT to hold a Boolean value. For instance, an application
		/// that obtains values from a Shell folder can use this function to safely extract the value from one of the folder's Boolean properties.
		/// </para>
		/// <para>If the source VARIANT is of type VT_BOOL, this function extracts the <c>BOOL</c> value.</para>
		/// <para>
		/// If the source VARIANT is not of type VT_BOOL, this function attempts to convert the value in the <c>VARIANT</c> structure into a
		/// <c>BOOL</c>. If a conversion is not possible, VariantToBoolean returns a failure code and sets pfRet to <c>FALSE</c>. See
		/// PropVariantChangeType for a list of possible conversions. Of note, VT_EMPTY is successfully converted to <c>FALSE</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToBoolean to access a
		/// <c>BOOL</c> value in a VARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoboolean PSSTDAPI VariantToBoolean(
		// REFVARIANT varIn, BOOL *pfRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "3ad12c41-e124-45f1-99f1-92790121ad93")]
		public static extern HRESULT VariantToBoolean(in VARIANT varIn, [MarshalAs(UnmanagedType.Bool)] out bool pfRet);

		/// <summary>Extracts an array of Boolean values from a VARIANT structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="prgf">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// Pointer to a buffer that contains crgn Boolean values. When this function returns, the buffer has been initialized with *pcElem
		/// <c>BOOL</c> elements extracted from the source VARIANT structure.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the buffer pointed to by prgf.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// When this function returns, contains a pointer to the count of <c>BOOL</c> elements extracted from the source VARIANT structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise, including the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source VARIANT contained more than crgn values.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The VARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a VARIANT to hold an array that consists of a fixed number of
		/// Boolean values.
		/// </para>
		/// <para>
		/// If the source VARIANT is of type VT_ARRAY | VT_BOOL, this function extracts up to crgn <c>BOOL</c> values and places them into
		/// the buffer pointed to by prgf. If the <c>VARIANT</c> contains more elements than will fit into the prgf buffer, this function
		/// returns an error and sets *pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToBooleanArray to access an
		/// array of <c>BOOL</c> values stored in a VARIANT structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttobooleanarray PSSTDAPI
		// VariantToBooleanArray( REFVARIANT var, BOOL *prgf, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "80a1e7d4-ec11-4b16-ba05-b97f3bbf02d0")]
		public static extern HRESULT VariantToBooleanArray(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.Bool)] bool[] prgf, uint crgn, out uint pcElem);

		/// <summary>Allocates an array of <c>BOOL</c> values then extracts data from a VARIANT structure into that array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="pprgf">
		/// <para>Type: <c>BOOL**</c></para>
		/// <para>When this function returns, contains a pointer to an array of <c>BOOL</c> values extracted from the source VARIANT structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains a pointer to the count of elements extracted from the source VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function is used when the calling application expects a VARIANT to hold an array of <c>BOOL</c> values.</para>
		/// <para>
		/// If the source VARIANT is of type VT_ARRAY | VT_BOOL, this function extracts an array of <c>BOOL</c> values into a newly allocated
		/// array. The calling application is responsible for using CoTaskMemFree to release the array pointed to by pprgf when it is no
		/// longer needed.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToBooleanArrayAlloc to access
		/// an array of <c>BOOL</c> values stored in a VARIANT structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttobooleanarrayalloc PSSTDAPI
		// VariantToBooleanArrayAlloc( REFVARIANT var, BOOL **pprgf, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6a623ee0-d99e-47db-82f9-9008c618a526")]
		public static extern HRESULT VariantToBooleanArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgf, out uint pcElem);

		/// <summary>Extracts a <c>BOOL</c> value from a VARIANT structure. If no value exists, then the specified default value is returned.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="fDefault">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>The default value for use where no extractable value exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns the extracted <c>BOOL</c> value; otherwise, the default value specified in fDefault.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a VARIANT to hold a <c>BOOL</c> value and wants to use a
		/// default value if it does not.
		/// </para>
		/// <para>If the source VARIANT is of type VT_BOOL, this helper extracts the <c>BOOL</c> value.</para>
		/// <para>
		/// If the source VARIANT is not of type VT_BOOL, the function attempts to convert the value in the <c>VARIANT</c> into a <c>BOOL</c>.
		/// </para>
		/// <para>
		/// If the source VARIANT is of type VT_EMPTY or a conversion is not possible, then VariantToBooleanWithDefault returns the default
		/// value provided by fDefault. See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToBooleanWithDefault to access
		/// a <c>BOOL</c> value stored in a VARIANT structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttobooleanwithdefault PSSTDAPI_(BOOL)
		// VariantToBooleanWithDefault( REFVARIANT varIn, BOOL fDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "523c6e75-a51c-4ef7-928c-0d228ab0d337")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VariantToBooleanWithDefault(in VARIANT varIn, [MarshalAs(UnmanagedType.Bool)] bool fDefault);

		/// <summary>Extracts the contents of a buffer stored in a VARIANT structure of type VT_ARRRAY | VT_UI1.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="pv">
		/// <para>Type: <c>VOID*</c></para>
		/// <para>
		/// Pointer to a buffer of length cb bytes. When this function returns, contains the first cb bytes of the extracted buffer value.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the pv buffer, in bytes. The buffer should be the same size as the data to be extracted, or smaller.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Data successfully extracted.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The VARIANT was not of type VT_ARRRAY | VT_UI1.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The VARIANT buffer value had fewer than cb bytes.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is used when the calling application expects a VARIANT to hold a buffer value. The calling application should check
		/// that the value has the expected length before it calls this function.
		/// </para>
		/// <para>
		/// If the source VARIANT has type VT_ARRAY | VT_UI1, this function extracts the first cb bytes from the structure and places them in
		/// the buffer pointed to by pv.
		/// </para>
		/// <para>If the stored value has fewer than cb bytes, then VariantToBuffer fails and the buffer is not modified.</para>
		/// <para>If the value has more than cb bytes, then VariantToBuffer succeeds and truncates the value.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToBuffer to access a structure
		/// that has been stored in a VARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttobuffer PSSTDAPI VariantToBuffer( REFVARIANT
		// varIn, void *pv, UINT cb );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "2d310156-c274-4aaf-aee2-ac311a952889")]
		public static extern HRESULT VariantToBuffer(in VARIANT varIn, byte[] pv, uint cb);

		/// <summary>Extracts a date and time value in Microsoft MS-DOS format from a VARIANT structure.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="pwDate">
		/// <para>Type: <c>WORD*</c></para>
		/// <para>When this function returns, contains the extracted <c>WORD</c> that represents a MS-DOS date.</para>
		/// </param>
		/// <param name="pwTime">
		/// <para>Type: <c>WORD*</c></para>
		/// <para>When this function returns, contains the extracted contains the extracted <c>WORD</c> that represents a MS-DOS time.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function is used when the calling application expects a VARIANT to hold a datetime value.</para>
		/// <para>If the source VARIANT is of type <c>VT_DATE</c>, this function extracts the datetime value.</para>
		/// <para>
		/// If the source VARIANT is not of type <c>VT_DATE</c>, the function attempts to convert the value in the <c>VARIANT</c> structure
		/// into the right format. If a conversion is not possible, VariantToDosDateTime returns a failure code. See PropVariantChangeType
		/// for a list of possible conversions.
		/// </para>
		/// <para>See DosDateTimeToVariantTime for more information about the formats of pwDate, pwTime, and the source datetime value.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToDosDateTime to access a
		/// datetime value in a VARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttodosdatetime PSSTDAPI VariantToDosDateTime(
		// REFVARIANT varIn, WORD *pwDate, WORD *pwTime );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "ebbba4d9-8e97-422d-b52f-67c417f295cc")]
		public static extern HRESULT VariantToDosDateTime(in VARIANT varIn, out ushort pwDate, out ushort pwTime);

		/// <summary>Extracts a <c>DOUBLE</c> value from a VARIANT structure. If no value can be extracted, then a default value is assigned.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="pdblRet">
		/// <para>Type: <c>DOUBLE*</c></para>
		/// <para>When this function returns, contains the extracted value if one exists; otherwise, 0.0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a VARIANT to hold a <c>DOUBLE</c> value. For instance, an
		/// application that obtains values from a Shell folder can use this function to safely extract the value from one of the folder's
		/// properties whose value is stored as a <c>DOUBLE</c>.
		/// </para>
		/// <para>If the source VARIANT is of type VT_R8, this function extracts the <c>DOUBLE</c> value.</para>
		/// <para>
		/// If the source VARIANT is not of type VT_R8, the function attempts to convert the value stored in the <c>VARIANT</c> structure
		/// into a <c>DOUBLE</c>. If a conversion is not possible, VariantToDouble returns a failure code and sets pdblRet to . See
		/// PropVariantChangeType for a list of possible conversions. Of note, VT_EMPTY is successfully converted to 0.0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToDouble to access a
		/// <c>DOUBLE</c> value stored in a VARIANT structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttodouble PSSTDAPI VariantToDouble( REFVARIANT
		// varIn, DOUBLE *pdblRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "7bd756c6-f02a-4cf4-9458-b3304e2da2db")]
		public static extern HRESULT VariantToDouble(in VARIANT varIn, out double pdblRet);

		/// <summary>Extracts an array of <c>DOUBLE</c> values from a VARIANT structure.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>DOUBLE*</c></para>
		/// <para>
		/// Pointer to a buffer that contains crgn <c>DOUBLE</c> values. When this function returns, the buffer has been initialized with
		/// *pcElem <c>DOUBLE</c> elements extracted from the source VARIANT structure.
		/// </para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements in the buffer pointed to by prgn.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains the count of <c>DOUBLE</c> elements extracted from the source VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> if successful, or an error value otherwise, including the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TYPE_E_BUFFERTOOSMALL</term>
		/// <term>The source VARIANT contained more than crgn values.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The VARIANT was not of the appropriate type.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a VARIANT to hold an array that consists of a fixed number of
		/// <c>DOUBLE</c> values.
		/// </para>
		/// <para>
		/// If the source VARIANT has type VT_ARRAY | VT_DOUBLE, this function extracts up to crgn <c>DOUBLE</c> values and places them into
		/// the buffer pointed to by prgn.
		/// </para>
		/// <para>
		/// If the VARIANT contains more elements than will fit into the prgn buffer, this function returns an error and sets *pcElem to 0.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToDoubleArray to access a
		/// <c>DOUBLE</c> array stored in a VARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttodoublearray PSSTDAPI VariantToDoubleArray(
		// REFVARIANT var, DOUBLE *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6830c2e2-d19a-45d5-af15-debfb08548bc")]
		public static extern HRESULT VariantToDoubleArray(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] double[] prgn, uint crgn, out uint pcElem);

		/// <summary>Allocates an array of <c>DOUBLE</c> values then extracts data from a VARIANT structure into that array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>DOUBLE**</c></para>
		/// <para>When this function returns, contains a pointer to an array of <c>DOUBLE</c> values extracted from the source VARIANT structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this function returns, contains a pointer to the count of elements extracted from the source VARIANT structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This helper function is used when the calling application expects a VARIANT to hold an array of <c>DOUBLE</c> values.</para>
		/// <para>
		/// If the source VARIANT is of type VT_ARRAY | VT_R8, this function extracts an array of <c>DOUBLE</c> values into a newly allocated
		/// array. The calling application is responsible for using CoTaskMemFree to release the array pointed to by pprgn when it is no
		/// longer needed.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToDoubleArrayAlloc to access a
		/// <c>DOUBLE</c> array value in a VARIANT.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttodoublearrayalloc PSSTDAPI
		// VariantToDoubleArrayAlloc( REFVARIANT var, DOUBLE **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "334d192e-7f63-47b4-88d4-9361e679cb15")]
		public static extern HRESULT VariantToDoubleArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts a <c>DOUBLE</c> value from a VARIANT structure. If no value exists, then the specified default value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source VARIANT structure.</para>
		/// </param>
		/// <param name="dblDefault">
		/// <para>Type: <c>DOUBLE</c></para>
		/// <para>The default value for use where no extractable value exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DOUBLE</c></para>
		/// <para>Returns the extracted <c>double</c> value; otherwise, the default value specified in dblDefault.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This helper function is used when the calling application expects a VARIANT to hold a <c>DOUBLE</c> value and wants to use a
		/// default value if it does not.
		/// </para>
		/// <para>If the source VARIANT is of type VT_R8, this helper extracts the <c>DOUBLE</c> value.</para>
		/// <para>If the source VARIANT is not of type VT_R8, the function attempts to convert the value in the <c>VARIANT</c> into a <c>DOUBLE</c>.</para>
		/// <para>
		/// If the source VARIANT is of type VT_EMPTY or a conversion is not possible, then VariantToDoubleWithDefault returns the default
		/// value provided by dblDefault. See PropVariantChangeType for a list of possible conversions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example, to be included as part of a larger program, demonstrates how to use VariantToDoubleWithDefault to access a
		/// <c>DOUBLE</c> value stored in a VARIANT structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttodoublewithdefault PSSTDAPI_(DOUBLE)
		// VariantToDoubleWithDefault( REFVARIANT varIn, DOUBLE dblDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "a3e32a30-363d-487e-bdd5-ac2616d6de14")]
		public static extern double VariantToDoubleWithDefault(in VARIANT varIn, double dblDefault);

		/// <summary>Extracts a FILETIME structure from a variant structure.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="stfOut">
		/// <para>Type: <c>PSTIME_FLAGS</c></para>
		/// <para>Specifies one of the following time flags:</para>
		/// <para>PSTF_UTC (0)</para>
		/// <para>Indicates coordinated universal time.</para>
		/// <para>PSTF_LOCAL (1)</para>
		/// <para>Indicates local time.</para>
		/// </param>
		/// <param name="pftOut">
		/// <para>Type: <c>FILETIME*</c></para>
		/// <para>Pointer to the extracted FILETIME structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>stfOut flags override any property description flags.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttofiletime PSSTDAPI VariantToFileTime(
		// REFVARIANT varIn, PSTIME_FLAGS stfOut, FILETIME *pftOut );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "e3094bd1-e641-43d8-8bc5-926c8d5a6ebe")]
		public static extern HRESULT VariantToFileTime(in VARIANT varIn, PSTIME_FLAGS stfOut, out FILETIME pftOut);

		/// <summary>Extracts a <c>GUID</c> property value of a variant structure.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pguid">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Pointer to the extracted property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoguid PSSTDAPI VariantToGUID( REFVARIANT
		// varIn, GUID *pguid );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "1af84b55-da7e-430c-97fe-1c544a40c039")]
		public static extern HRESULT VariantToGUID(in VARIANT varIn, out Guid pguid);

		/// <summary>
		/// Extracts the <c>Int16</c> property value of a variant structure. If no value can be extracted, then a default value is assigned
		/// by this function.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="piRet">
		/// <para>Type: <c>SHORT*</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint16 PSSTDAPI VariantToInt16( REFVARIANT
		// varIn, SHORT *piRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "5a0d22c1-4295-405d-a503-2b9fdd6eaa81")]
		public static extern HRESULT VariantToInt16(in VARIANT varIn, out short piRet);

		/// <summary>Extracts data from a vector structure into an <c>Int16</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>SHORT*</c></para>
		/// <para>Pointer to the <c>Int16</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies <c>Int16</c> array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of <c>Int16</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint16array PSSTDAPI VariantToInt16Array(
		// REFVARIANT var, SHORT *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "dd00d986-acfa-445e-a0f6-0f52860b762b")]
		public static extern HRESULT VariantToInt16Array(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] short[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated <c>Int16</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>SHORT**</c></para>
		/// <para>Pointer to the address of the <c>Int16</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of <c>Int16</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint16arrayalloc PSSTDAPI
		// VariantToInt16ArrayAlloc( REFVARIANT var, SHORT **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "616c9d03-f641-49e3-af95-80ebaea3e8aa")]
		public static extern HRESULT VariantToInt16ArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts an <c>Int16</c> property value of a variant structure. If no value exists, then the specified default value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="iDefault">
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>SHORT</c></para>
		/// <para>Returns the extracted <c>Int16</c> value, or default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint16withdefault PSSTDAPI_(SHORT)
		// VariantToInt16WithDefault( REFVARIANT varIn, SHORT iDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "4d6d0b7d-ae20-456c-9ef4-97fa682ece8b")]
		public static extern short VariantToInt16WithDefault(in VARIANT varIn, short iDefault);

		/// <summary>
		/// Extracts an <c>Int32</c> property value of a variant structure. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="plRet">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint32 PSSTDAPI VariantToInt32( REFVARIANT
		// varIn, LONG *plRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6d2a4b8f-2ec5-4ffd-80b0-6615fdfb2379")]
		public static extern HRESULT VariantToInt32(in VARIANT varIn, out int plRet);

		/// <summary>Extracts data from a vector structure into an <c>Int32</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>Pointer to the <c>Int32</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies <c>Int32</c> array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of <c>Int32</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint32array PSSTDAPI VariantToInt32Array(
		// REFVARIANT var, LONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "9407e400-1621-4d96-b541-579aa3ac7a67")]
		public static extern HRESULT VariantToInt32Array(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated <c>Int32</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>LONG**</c></para>
		/// <para>Pointer to the address of the <c>Int32</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of <c>Int32</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint32arrayalloc PSSTDAPI
		// VariantToInt32ArrayAlloc( REFVARIANT var, LONG **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6010ee34-d7d2-4b8b-a49b-0f2aa88a3b54")]
		public static extern HRESULT VariantToInt32ArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts an <c>Int32</c> property value of a variant structure. If no value exists, then the specified default value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="lDefault">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Returns the extracted Int32 value, or default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint32withdefault PSSTDAPI_(LONG)
		// VariantToInt32WithDefault( REFVARIANT varIn, LONG lDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "fd2d5330-2b31-4dbb-b57b-4ca5579fa03f")]
		public static extern int VariantToInt32WithDefault(in VARIANT varIn, int lDefault);

		/// <summary>
		/// Extracts an <c>Int64</c> property value of a variant structure. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pllRet">
		/// <para>Type: <c>LONGLONG*</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint64 PSSTDAPI VariantToInt64( REFVARIANT
		// varIn, LONGLONG *pllRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "5b8b4f93-dff1-40ef-9f99-c108a0b1bf70")]
		public static extern HRESULT VariantToInt64(in VARIANT varIn, out long pllRet);

		/// <summary>Extracts data from a vector structure into an <c>Int64</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>LONGLONG*</c></para>
		/// <para>Pointer to the Int64 data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies Int64 array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of Int64 elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint64array PSSTDAPI VariantToInt64Array(
		// REFVARIANT var, LONGLONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "936e87e8-8102-4da2-b388-147fab6ec16f")]
		public static extern HRESULT VariantToInt64Array(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated <c>Int64</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>LONGLONG**</c></para>
		/// <para>Pointer to the address of the <c>Int64</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of <c>Int64</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint64arrayalloc PSSTDAPI
		// VariantToInt64ArrayAlloc( REFVARIANT var, LONGLONG **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "15a583bd-fdef-4802-a18b-0a21b9be5448")]
		public static extern HRESULT VariantToInt64ArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts an <c>Int64</c> property value of a variant structure. If no value exists, then the specified default value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="llDefault">
		/// <para>Type: <c>LONGLONG</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LONGLONG</c></para>
		/// <para>Returns extracted <c>Int64</c> value, or default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttoint64withdefault PSSTDAPI_(LONGLONG)
		// VariantToInt64WithDefault( REFVARIANT varIn, LONGLONG llDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "c4a5fc5c-19f9-4313-9d98-a486bfdfb359")]
		public static extern int VariantToInt64WithDefault(in VARIANT varIn, int llDefault);

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

		/// <summary>
		/// Extracts the variant value of a variant structure to a string. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pszBuf">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, empty.</para>
		/// </param>
		/// <param name="cchBuf">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Specifies string length, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttostring PSSTDAPI VariantToString( REFVARIANT
		// varIn, PWSTR pszBuf, UINT cchBuf );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "4850f9b8-8f86-4428-bf3b-f3abdc6047c1")]
		public static extern HRESULT VariantToString(in VARIANT varIn, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszBuf, uint cchBuf);

		/// <summary>
		/// Extracts the variant value of a variant structure to a newly-allocated string. If no value can be extracted, then a default value
		/// is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="ppszBuf">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, empty.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttostringalloc PSSTDAPI VariantToStringAlloc(
		// REFVARIANT varIn, PWSTR *ppszBuf );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "9cd4433c-d8ad-43ef-bdb9-9c1b8d8bea01")]
		public static extern HRESULT VariantToStringAlloc(in VARIANT varIn, [MarshalAs(UnmanagedType.LPWStr)] out string ppszBuf);

		/// <summary>Extracts data from a vector structure into a String array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgsz">
		/// <para>Type: <c>PWSTR*</c></para>
		/// <para>Pointer to the string data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgsz">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies string array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of string elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttostringarray PSSTDAPI VariantToStringArray(
		// REFVARIANT var, PWSTR *prgsz, ULONG crgsz, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "d19b12ad-408c-4502-ad59-49386784bd69")]
		public static extern HRESULT VariantToStringArray(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr)] string[] prgsz, uint crgsz, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated String array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgsz">
		/// <para>Type: <c>PWSTR**</c></para>
		/// <para>The address of a pointer to the string data extracted from source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of string elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttostringarrayalloc PSSTDAPI
		// VariantToStringArrayAlloc( REFVARIANT var, PWSTR **pprgsz, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "2725b824-b26c-4b33-bc18-a6f4c0ef74e6")]
		public static extern HRESULT VariantToStringArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgsz, out uint pcElem);

		/// <summary>
		/// Extracts the string property value of a variant structure. If no value exists, then the specified default value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pszDefault">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>Pointer to the default Unicode string property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>Returns the extracted string value, or default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttostringwithdefault PSSTDAPI_(PCWSTR)
		// VariantToStringWithDefault( REFVARIANT varIn, LPCWSTR pszDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("propvarutil.h", MSDNShortId = "f8ca7844-057f-4e95-a4a9-f03f1d2ad492")]
		public static extern string VariantToStringWithDefault(in VARIANT varIn, string pszDefault);

		/// <summary>
		/// Extracts an unsigned <c>Int16</c> property value of a variant structure. If no value can be extracted, then a default value is
		/// assigned by this function.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="puiRet">
		/// <para>Type: <c>USHORT*</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint16 PSSTDAPI VariantToUInt16( REFVARIANT
		// varIn, USHORT *puiRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "aa88be72-9ea5-4668-a0c5-1ca5320bda00")]
		public static extern HRESULT VariantToUInt16(in VARIANT varIn, out ushort puiRet);

		/// <summary>Extracts data from a vector structure into an unsigned <c>Int16</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>USHORT*</c></para>
		/// <para>Pointer to the unsigned <c>Int16</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies unsigned <c>Int16</c> array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of unsigned <c>Int16</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint16array PSSTDAPI VariantToUInt16Array(
		// REFVARIANT var, USHORT *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "8da12aa7-f54e-4a38-b9bb-0dd019f8823b")]
		public static extern HRESULT VariantToUInt16Array(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ushort[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated unsigned <c>Int16</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>USHORT**</c></para>
		/// <para>Pointer to the address of the unsigned <c>Int16</c> data extracted from the source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of unsigned <c>Int16</c> elements extracted from the source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint16arrayalloc PSSTDAPI
		// VariantToUInt16ArrayAlloc( REFVARIANT var, USHORT **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "59e8d295-3be4-4e9a-a096-ead777d3aa8a")]
		public static extern HRESULT VariantToUInt16ArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts an unsigned <c>Int16</c> property value of a variant structure. If no value exists, then the specified default value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="uiDefault">
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Returns extracted unsigned <c>Int16</c> value, or default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint16withdefault PSSTDAPI_(USHORT)
		// VariantToUInt16WithDefault( REFVARIANT varIn, USHORT uiDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "937d64c3-f5af-4230-b811-6d5883ecaf86")]
		public static extern ushort VariantToUInt16WithDefault(in VARIANT varIn, ushort uiDefault);

		/// <summary>
		/// Extracts unsigned <c>Int32</c> property value of a variant structure. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pulRet">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint32 PSSTDAPI VariantToUInt32( REFVARIANT
		// varIn, ULONG *pulRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "24421477-8930-4c8f-8fee-5d8367123c7e")]
		public static extern HRESULT VariantToUInt32(in VARIANT varIn, out uint pulRet);

		/// <summary>Extracts data from a vector structure into an unsigned <c>Int32</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the unsigned <c>Int32</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies unsigned <c>Int32</c> array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of unsigned <c>Int32</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint32array PSSTDAPI VariantToUInt32Array(
		// REFVARIANT var, ULONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "506a02f8-6390-44a0-9f14-bfc8fb7ad180")]
		public static extern HRESULT VariantToUInt32Array(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated unsigned <c>Int32</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>ULONG**</c></para>
		/// <para>The address of a pointer to the unsigned <c>Int32</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of unsigned <c>Int32</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint32arrayalloc PSSTDAPI
		// VariantToUInt32ArrayAlloc( REFVARIANT var, ULONG **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "4d6cbfc8-fe1c-4bd0-8d29-32bce01d31f8")]
		public static extern HRESULT VariantToUInt32ArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts an unsigned <c>Int32</c> property value of a variant structure. If no value currently exists, then the specified default
		/// value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="ulDefault">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Returns extracted unsigned <c>Int32</c> value, or default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint32withdefault PSSTDAPI_(ULONG)
		// VariantToUInt32WithDefault( REFVARIANT varIn, ULONG ulDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "02ec869b-154e-436a-a9b7-57eff4e958aa")]
		public static extern uint VariantToUInt32WithDefault(in VARIANT varIn, uint ulDefault);

		/// <summary>
		/// Extracts unsigned <c>Int64</c> property value of a variant structure. If no value can be extracted, then a default value is assigned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pullRet">
		/// <para>Type: <c>ULONGLONG*</c></para>
		/// <para>Pointer to the extracted property value if one exists; otherwise, 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint64 PSSTDAPI VariantToUInt64( REFVARIANT
		// varIn, ULONGLONG *pullRet );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "1278f775-8439-4d05-acc9-b5207a3ccba7")]
		public static extern HRESULT VariantToUInt64(in VARIANT varIn, out ulong pullRet);

		/// <summary>Extracts data from a vector structure into an unsigned <c>Int64</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="prgn">
		/// <para>Type: <c>ULONGLONG*</c></para>
		/// <para>Pointer to the unsigned <c>Int64</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="crgn">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies unsigned <c>Int64</c> array size.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of unsigned <c>Int64</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint64array PSSTDAPI VariantToUInt64Array(
		// REFVARIANT var, ULONGLONG *prgn, ULONG crgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "90b39ed2-a8a9-424c-bfd2-90517b9224fd")]
		public static extern HRESULT VariantToUInt64Array(in VARIANT var, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] prgn, uint crgn, out uint pcElem);

		/// <summary>Extracts data from a vector structure into a newly-allocated unsigned <c>Int64</c> array.</summary>
		/// <param name="var">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pprgn">
		/// <para>Type: <c>ULONGLONG**</c></para>
		/// <para>The address of a pointer to the unsigned <c>Int64</c> data extracted from source variant structure.</para>
		/// </param>
		/// <param name="pcElem">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Pointer to the count of unsigned <c>Int64</c> elements extracted from source variant structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint64arrayalloc PSSTDAPI
		// VariantToUInt64ArrayAlloc( REFVARIANT var, ULONGLONG **pprgn, ULONG *pcElem );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "898edef6-a688-4a39-897c-70f29952db49")]
		public static extern HRESULT VariantToUInt64ArrayAlloc(in VARIANT var, out SafeCoTaskMemHandle pprgn, out uint pcElem);

		/// <summary>
		/// Extracts an unsigned <c>Int64</c> property value of a variant structure. If no value currently exists, then the specified default
		/// value is returned.
		/// </summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="ullDefault">
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>Specifies default property value, for use where no value currently exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ULONGLONG</c></para>
		/// <para>Returns the extracted unsigned <c>Int64</c> value, or a default.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttouint64withdefault PSSTDAPI_(ULONGLONG)
		// VariantToUInt64WithDefault( REFVARIANT varIn, ULONGLONG ullDefault );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "6ff75c81-519b-4539-9aa5-c6b39b3e2d94")]
		public static extern ulong VariantToUInt64WithDefault(in VARIANT varIn, ulong ullDefault);

		/// <summary>Copies the content from a Windows runtime property value to a PROPVARIANT structure.</summary>
		/// <param name="punkPropertyValue">
		/// A pointer to the IUnknown interface from which this function can access the contents of a Windows runtime property value by
		/// retrieving and using the Windows::Foundation::IPropertyValue interface.
		/// </param>
		/// <param name="ppropvar">
		/// Pointer to a PROPVARIANT structure. When this function returns, the <c>PROPVARIANT</c> contains the converted info.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-winrtpropertyvaluetopropvariant PSSTDAPI
		// WinRTPropertyValueToPropVariant( IUnknown *punkPropertyValue, PROPVARIANT *ppropvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propsys.h", MSDNShortId = "3D6853B0-0A3F-4ACF-9C93-478688DAE9CF")]
		public static extern HRESULT WinRTPropertyValueToPropVariant([MarshalAs(UnmanagedType.IUnknown)] object punkPropertyValue, PROPVARIANT ppropvar);
	}
}