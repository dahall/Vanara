using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes a method that initializes a handler, such as a property handler, thumbnail handler, or preview handler, with a bind context.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iinitializewithbindctx
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IInitializeWithBindCtx")]
		[ComImport, Guid("71c0d2bc-726d-45cc-a6c0-2e31c1db2159"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IInitializeWithBindCtx
		{
			/// <summary>Initializes a handler with a bind context.</summary>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>Pointer to the IBindCtx object.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iinitializewithbindctx-initialize HRESULT
			// Initialize( IBindCtx *pbc );
			[PreserveSig]
			HRESULT Initialize([In] IBindCtx pbc);
		}
	}
}