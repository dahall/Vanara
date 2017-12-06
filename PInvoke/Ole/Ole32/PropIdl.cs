using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// The PropVariantClear function frees all elements that can be freed in a given PROPVARIANT structure. For complex elements with known element
		/// pointers, the underlying elements are freed prior to freeing the containing element.
		/// </summary>
		/// <param name="pvar">
		/// A pointer to an initialized PROPVARIANT structure for which any deallocatable elements are to be freed. On return, all zeroes are written to the
		/// PROPVARIANT structure.
		/// </param>
		/// <returns>
		/// <list type="definition">
		/// <item><term>S_OK</term><definition>The VT types are recognized and all items that can be freed have been freed.</definition></item>
		/// <item><term>STG_E_INVALID_PARAMETER</term><definition>The variant has an unknown VT type.</definition></item>
		/// </list>
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity]
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Propidl.h", MSDNShortId = "aa380073")]
		public static extern HRESULT PropVariantClear([In, Out] PROPVARIANT pvar);

		/// <summary>The PropVariantCopy function copies the contents of one PROPVARIANT structure to another.</summary>
		/// <param name="pDst">Pointer to an uninitialized PROPVARIANT structure that receives the copy.</param>
		/// <param name="pSrc">Pointer to the PROPVARIANT structure to be copied.</param>
		/// <returns>
		/// <list type="definition">
		/// <item><term>S_OK</term><definition>The VT types are recognized and all items that can be freed have been freed.</definition></item>
		/// <item><term>STG_E_INVALID_PARAMETER</term><definition>The variant has an unknown VT type.</definition></item>
		/// </list>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true)]
		[PInvokeData("Propidl.h", MSDNShortId = "aa380192")]
		public static extern HRESULT PropVariantCopy([In, Out] PROPVARIANT pDst, [In] PROPVARIANT pSrc);
	}
}