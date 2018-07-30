using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// A function that the property sheet handler calls to add a page to the property sheet. The function takes a property sheet handle
		/// returned by the CreatePropertySheetPage function and the lParam parameter passed to that method.
		/// </summary>
		/// <param name="hPropSheetPage">A property sheet handle returned by the CreatePropertySheetPage function.</param>
		/// <param name="lParam">The lParam parameter passed to the CreatePropertySheetPage function.</param>
		/// <returns></returns>
		[PInvokeData("Shobjidl.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate bool LPFNSVADDPROPSHEETPAGE(IntPtr hPropSheetPage, IntPtr lParam);

		/// <summary>Used by IShellPropSheetExt::ReplacePage.</summary>
		[PInvokeData("Shobjidl.h")]
		public enum EXPPS
		{
			/// <summary>Undocumented.</summary>
			EXPPS_FILETYPES = 0x00000001,
		}

		/// <summary>Exposes methods that allow a property sheet handler to add or replace pages in the property sheet displayed for a file object.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellpropsheetext
		[PInvokeData("shobjidl_core.h", MSDNShortId = "1671ad3e-c131-4de0-a213-b22c9966bae2")]
		[ComImport, Guid("000214E9-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellPropSheetExt
		{
			/// <summary>
			/// Adds one or more pages to a property sheet that the Shell displays for a file object. The Shell calls this method for each
			/// property sheet handler registered to the file type.
			/// </summary>
			/// <param name="pfnAddPage">
			/// A pointer to a function that the property sheet handler calls to add a page to the property sheet. The function takes a
			/// property sheet handle returned by the CreatePropertySheetPage function and the lParam parameter passed to this method.
			/// </param>
			/// <param name="lParam">Handler-specific data to pass to the function pointed to by pfnAddPage.</param>
			/// <returns>
			/// If successful, returns a one-based index to specify the page that should be initially displayed. See Remarks for more information.
			/// </returns>
			/// <remarks>
			/// For each page that the property sheet handler needs to add to a property sheet, the handler fills a PROPSHEETPAGE structure,
			/// calls the CreatePropertySheetPage function, and then calls the function pointed to by pfnAddPage.
			/// <para>
			/// You can request through your implementation that a particular property sheet page be displayed first, instead of the default
			/// page. To do so, return the one-based index of the desired page relative to the pages you added. For example, if you added
			/// three property sheet pages, A, B, and C, and you want B to be the selected page, then the return value should be 2. Note that
			/// this return value is only a request. The property sheet might still display the default page.
			/// </para>
			/// </remarks>
			uint AddPages([In] LPFNSVADDPROPSHEETPAGE pfnAddPage, [In] IntPtr lParam);

			/// <summary>Replaces a page in a property sheet for a Control Panel object.</summary>
			/// <param name="uPageID">
			/// Not used.
			/// <para><c>Microsoft Windows XP and earlier:</c> A type EXPPS identifier of the page to replace.</para>
			/// </param>
			/// <param name="pfnReplaceWith">
			/// A pointer to a function that the property sheet handler calls to replace a page to the property sheet. The function takes a
			/// property sheet handle returned by the CreatePropertySheetPage function and the lParam parameter passed to this method.
			/// </param>
			/// <param name="lParam">The parameter to pass to the function specified by the pfnReplacePage parameter.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			/// <remarks>
			/// To replace a page, a property sheet handler fills a PROPSHEETPAGE structure, calls CreatePropertySheetPage, and then calls
			/// the function specified by pfnReplacePage.
			/// </remarks>
			HRESULT ReplacePage([In] EXPPS uPageID, [In] LPFNSVADDPROPSHEETPAGE pfnReplaceWith, [In] IntPtr lParam);
		}
	}
}