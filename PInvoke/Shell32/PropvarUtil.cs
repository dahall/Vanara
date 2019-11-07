using System.Runtime.InteropServices;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Initializes a VARIANT structure with a string stored in a STRRET structure.</summary>
		/// <param name="pstrret">
		/// <para>Type: <c>STRRET*</c></para>
		/// <para>Pointer to a STRRET structure.</para>
		/// </param>
		/// <param name="pidl">
		/// <para>Type: <c>PCUITEMID_CHILD</c></para>
		/// <para>PIDL of the item whose details are being retrieved.</para>
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
		/// <para>Creates a VT_BSTR variant.</para>
		/// <para><c>Note</c> This function frees the resources used for the STRRET contents.</para>
		/// <para>Examples</para>
		/// <para>The following example, to be included as part of a larger program, demonstrates how to use InitVariantFromStrRet.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-initvariantfromstrret PSSTDAPI
		// InitVariantFromStrRet( STRRET *pstrret, PCUITEMID_CHILD pidl, VARIANT *pvar );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "8e9542a9-9ed0-4e44-b9b1-32b31151bd8e")]
		public static extern HRESULT InitVariantFromStrRet(in STRRET pstrret, PIDL pidl, out VARIANT pvar);

		/// <summary>If the source variant is a VT_BSTR, extracts string and places it into a STRRET structure.</summary>
		/// <param name="varIn">
		/// <para>Type: <c>REFVARIANT</c></para>
		/// <para>Reference to a source variant structure.</para>
		/// </param>
		/// <param name="pstrret">
		/// <para>Type: <c>STRRET*</c></para>
		/// <para>Pointer to the extracted string if one exists.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/propvarutil/nf-propvarutil-varianttostrret PSSTDAPI VariantToStrRet( REFVARIANT
		// varIn, STRRET *pstrret );
		[DllImport(Lib.PropSys, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("propvarutil.h", MSDNShortId = "dfc1f52e-58c6-48fd-8da9-1d4d5115912c")]
		public static extern HRESULT VariantToStrRet(in VARIANT varIn, out STRRET pstrret);
	}
}