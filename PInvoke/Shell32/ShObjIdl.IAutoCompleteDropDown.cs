using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes methods that allow clients to reset or query the display state of the autocomplete drop-down list, which contains
		/// possible completions to a string entered by the user in an edit control.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iautocompletedropdown
		[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IAutoCompleteDropDown")]
		[ComImport, Guid("3CD141F4-3C6A-11d2-BCAA-00C04FD929DB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IAutoCompleteDropDown
		{
			/// <summary>Gets the current display status of the autocomplete drop-down list.</summary>
			/// <param name="pdwFlags">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// A pointer to a value indicating whether the autocomplete drop-down list is currently displayed. This parameter can be
			/// <c>NULL</c> on entry if this information is not needed. The following values are recognized as the target of this pointer.
			/// </para>
			/// <para>(0x0000)</para>
			/// <para>The list is not visible.</para>
			/// <para>ACDD_VISIBLE (0x0001)</para>
			/// <para>The list is visible.</para>
			/// </param>
			/// <param name="ppwszString">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// A pointer to a buffer containing the first select item in the drop-down list, if the value pointed to by pdwFlags is
			/// <c>ACDD_VISIBLE</c>. This value can be <c>NULL</c> on entry if this information is not needed.
			/// </para>
			/// <para>If pdwFlags is zero on exit, then this value will be <c>NULL</c>.</para>
			/// <para>
			/// If this value is not <c>NULL</c> on exit, the buffer it points to must be freed using CoTaskMemFree when it is no longer needed.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iautocompletedropdown-getdropdownstatus HRESULT
			// GetDropDownStatus( DWORD *pdwFlags, LPWSTR *ppwszString );
			void GetDropDownStatus(ref uint pdwFlags, out string ppwszString);

			/// <summary>Forces the autocomplete object to refresh its list of suggestions when the list is visible.</summary>
			/// <remarks>
			/// The drop-down list is always rebuilt before it is displayed, so there is no reason to use this method unless the drop-down
			/// list is currently visible.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iautocompletedropdown-resetenumerator HRESULT ResetEnumerator();
			void ResetEnumerator();
		}
	}
}