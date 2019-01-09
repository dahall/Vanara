using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes methods that get and set the parent and the parent's child ID. While <c>IParentAndItem</c> is typically implemented on
		/// IShellItems, it is not specific to IShellItem.
		/// </summary>
		/// <remarks>
		/// The performance improvement using this interface can be noted in comparison with IPersistIDList, an interface that uses absolute
		/// item identifier lists. Subsequent operations on objects that implement <c>IPersistIDList</c> may require
		/// IShellFolder::BindToObject calls, and these calls may impact performance. In the case of IShellItems and participating
		/// IShellFolders that implement <c>IParentAndItem</c>, the parent IShellFolder may already be cached. By implementing
		/// <c>IParentAndItem</c> and then getting/setting the parent <c>IShellFolder</c> directly, the call to
		/// <c>IShellFolder::BindToObject</c> on the item identifier list to retrieve the <c>IShellFolder</c> interface is eliminated.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iparentanditem
		[PInvokeData("shobjidl_core.h", MSDNShortId = "5cca426f-73fb-4b39-8eb0-16c01673c311")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b3a4b685-b685-4805-99d9-5dead2873236")]
		public interface IParentAndItem
		{
			/// <summary>Sets the parent of an item and the parent's child ID.</summary>
			/// <param name="pidlParent">
			/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
			/// <para>A pointer of the parent.</para>
			/// </param>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to the IShellFolder that is the parent.</para>
			/// </param>
			/// <param name="pidlChild">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>A PIDL that is a child relative to psf.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>While IParentAndItem is typically implemented on IShellItems, it is not specific to IShellItem.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iparentanditem-setparentanditem HRESULT
			// SetParentAndItem( PCIDLIST_ABSOLUTE pidlParent, IShellFolder *psf, PCUITEMID_CHILD pidlChild );
			[PreserveSig]
			HRESULT SetParentAndItem([In] PIDL pidlParent, [In] IShellFolder psf, [In] PIDL pidlChild);

			/// <summary>Gets the parent of an item and the parent's child ID.</summary>
			/// <param name="ppidlParent">
			/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
			/// <para>When this method returns, contains the address of a PIDL that specifies the parent.</para>
			/// </param>
			/// <param name="ppsf">
			/// <para>Type: <c>IShellFolder**</c></para>
			/// <para>When this method returns, contains the address of a pointer to the IShellFolder that is the parent.</para>
			/// </param>
			/// <param name="ppidlChild">
			/// <para>Type: <c>PITEMID_CHILD*</c></para>
			/// <para>
			/// When this method returns, contains the address of a child PIDL that identifies the IParentAndItem object relative to that
			/// specified by ppsf.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>While IParentAndItem is typically implemented on IShellItems, it is not specific to IShellItem.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iparentanditem-getparentanditem HRESULT
			// GetParentAndItem( PIDLIST_ABSOLUTE *ppidlParent, IShellFolder **ppsf, PITEMID_CHILD *ppidlChild );
			[PreserveSig]
			HRESULT GetParentAndItem(out PIDL ppidlParent, out IShellFolder ppsf, out PIDL ppidlChild);
		}
	}
}