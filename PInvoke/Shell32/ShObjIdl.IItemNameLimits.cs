using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Retrieves a list of valid and invalid characters or the maximum length of a name in the namespace. Use this interface for
		/// validation parsing and translation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iitemnamelimits
		[ComImport, Guid("1df0d7f1-b267-4d28-8b10-12e23202a5c4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IItemNameLimits
		{
			/// <summary>
			/// Loads a string that contains each of the characters that are valid or invalid in the namespace under which it is called.
			/// </summary>
			/// <param name="ppwszValidChars">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// A pointer to a string that contains all valid characters in the namespace. If the namespace provides any invalid characters
			/// in ppwszInvalidChars, then this value returns <c>NULL</c>. See Remarks for more details.
			/// </para>
			/// </param>
			/// <param name="ppwszInvalidChars">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>A pointer to a string that contains all invalid characters in the namespace.</para>
			/// </param>
			/// <remarks>
			/// <para>
			/// As an example, the standard file system returns the string "/:*?"&lt;&gt;|" in ppwszInvalidChars and <c>NULL</c> in ppwszValidChars.
			/// </para>
			/// <para>
			/// Both parameters cannot return non- <c>NULL</c> values, so ppwszValidChars is assigned a value of <c>NULL</c> because of the
			/// non- <c>NULL</c> value
			/// </para>
			/// <para>
			/// in ppwszInvalidChars. It is assumed that when there are specified invalid characters, everything else is valid. Only when
			/// ppwszInvalidChars is <c>NULL</c> does ppwszValidChars contain a list of all valid characters.
			/// </para>
			/// <para>If the method returns a success code, the allocated string must be freed using CoTaskMemFree.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iitemnamelimits-getvalidcharacters HRESULT
			// GetValidCharacters( LPWSTR *ppwszValidChars, LPWSTR *ppwszInvalidChars );
			void GetValidCharacters([MarshalAs(UnmanagedType.LPWStr)] out string ppwszValidChars, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszInvalidChars);

			/// <summary>Returns the maximum number of characters allowed for a particular name in the namespace under which it is called.</summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string containing a name.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>int*</c></para>
			/// <para>A pointer to the maximum number of characters which can be used in the name.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iitemnamelimits-getmaxlength HRESULT
			// GetMaxLength( LPCWSTR pszName, int *piMaxNameLen );
			int GetMaxLength([MarshalAs(UnmanagedType.LPWStr)] string pszName);
		}
	}
}