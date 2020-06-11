using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Provides a method to update the ITEMIDLIST of the child of an folder object.</summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>Implement this interface for an IShellFolder implementation to update the provided child ITEMIDLIST.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iupdateidlist
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IUpdateIDList")]
		[ComImport, Guid("6589b6d2-5f8d-4b9e-b7e0-23cdd9717d8c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IUpdateIDList
		{
			/// <summary>Updates the provided child ITEMIDLIST based on the parameters specified by the provided IBindCtx.</summary>
			/// <param name="pbc">
			/// <para>Type: <c>IBindCtx*</c></para>
			/// <para>
			/// An IBindCtx interface on a bind context object. Used to specify parameters for updating the child ITEMIDLIST. This value can
			/// be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pidlIn">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>The child ITEMIDLIST.</para>
			/// </param>
			/// <param name="ppidlOut">
			/// <para>Type: <c>PITEMID_CHILD*</c></para>
			/// <para>A pointer to the child ITEMIDLIST relative to the parent folder.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// If pbc is <c>NULL</c> or does not contain any parameters that apply to the current Shell folder, ppidlOut points to the same
			/// ITEMIDLIST as pidlIn.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iupdateidlist-update HRESULT Update(
			// IBindCtx *pbc, PCUITEMID_CHILD pidlIn, PITEMID_CHILD *ppidlOut );
			[PreserveSig]
			HRESULT Update([In, Optional] IBindCtx pbc, [In] PIDL pidlIn, out PIDL ppidlOut);
		}
	}
}