using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Exposes a method that can be used by an accessibility application.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-iaccessibleobject
		[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IAccessibleObject")]
		[ComImport, Guid("95A391C5-9ED4-4c28-8401-AB9E06719E11"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IAccessibleObject
		{
			/// <summary>
			/// Sets text that is retrieved by IAccessible::get_accName which accessibility tools use to obtain the Name Property of an object.
			/// </summary>
			/// <param name="pszName">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a null-terminated, Unicode string containing the name.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-iaccessibleobject-setaccessiblename HRESULT
			// SetAccessibleName( LPCWSTR pszName );
			[PreserveSig]
			HRESULT SetAccessibleName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
		}
	}
}