using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a property store.
		/// </summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>Use this interface when initializing a handler for OpenSearch result sets, which are returned as RSS or Atom feeds.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iinitializewithpropertystore
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IInitializeWithPropertyStore")]
		[ComImport, Guid("C3E12EB5-7D8D-44f8-B6DD-0E77B34D6DE4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IInitializeWithPropertyStore
		{
			/// <summary>Initializes a handler with an IPropertyStore.</summary>
			/// <param name="pps">
			/// <para>Type: <c>IPropertyStore*</c></para>
			/// <para>A pointer to an IPropertyStore.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// This method supports initializing handlers for use with OpenSearch result sets, which are returned from web services as RSS
			/// or Atom feeds.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iinitializewithpropertystore-initialize
			// HRESULT Initialize( IPropertyStore *pps );
			[PreserveSig]
			HRESULT Initialize([In] IPropertyStore pps);
		}
	}
}