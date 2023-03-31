using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Exposes methods that enumerate the contents of a view and receive notification from callback upon enumeration completion. This
	/// interface enables clients of a view to attempt to share the view's list of folder contents.
	/// </summary>
	/// <remarks>
	/// <para>
	/// IFolderView (a folder view) supports presentation of the contents of a folder, and exposes the <c>IEnumerableView</c> through
	/// QueryService on service request SID_EnumerableView. <c>IEnumerableView</c> offers enhanced performance compared to obtaining the
	/// contents of the folder directly from the folder using IEnumIDList (call IShellFolder::EnumObjects to return this interface).
	/// Since the view asked for the contents of the folder in order to display those contents, using <c>IEnumerableView</c> enables a
	/// client to get a copy of the work already done by <c>IFolderView</c>.
	/// </para>
	/// <para>
	/// Typicallly, this enumeration service is compatible with most folders, and is only provided if it is safe to enumerate the
	/// contents of the view. For example, using this service with a folder containing search results is not supported.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ienumerableview
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IEnumerableView")]
	[ComImport, Guid("8C8BF236-1AEC-495f-9894-91D57C3C686F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumerableView
	{
		/// <summary>Sets a callback on the view that is notified when the initial view enumeration is complete.</summary>
		/// <param name="percb">
		/// <para>Type: <c>IEnumReadyCallback*</c></para>
		/// <para>A pointer to the IEnumReadyCallback interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns a success value if successful, or an error value otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ienumerableview-setenumreadycallback HRESULT
		// SetEnumReadyCallback( IEnumReadyCallback *percb );
		[PreserveSig]
		HRESULT SetEnumReadyCallback([In]  IEnumReadyCallback percb);

		/// <summary>Creates an enumerator of ID lists from the contents of the view.</summary>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A PIDL that is relative to the Desktop.</para>
		/// </param>
		/// <param name="dwEnumFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies enumeration flags. See the SHCONTF enumerated type.</para>
		/// </param>
		/// <param name="ppEnumIDList">
		/// <para>Type: <c>IEnumIDList**</c></para>
		/// <para>When this method returns, contains an IEnumIDList interface pointer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns a success value if successful, or an error value otherwise.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ienumerableview-createenumidlistfromcontents HRESULT
		// CreateEnumIDListFromContents( PCIDLIST_ABSOLUTE pidlFolder, DWORD dwEnumFlags, IEnumIDList **ppEnumIDList );
		[PreserveSig]
		HRESULT CreateEnumIDListFromContents([In] PIDL pidlFolder, SHCONTF dwEnumFlags, out IEnumIDList ppEnumIDList);
	}

	/// <summary>
	/// Exposes methods that enable the view to notify the implementer when the enumeration has completed. The view calls this method to
	/// tell the implementer that the enumeration can be retrieved via IEnumerableView::CreateEnumIDListFromContents. The callback
	/// allows the implementer to share the views enumeration.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-ienumreadycallback
	[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IEnumReadyCallback")]
	[ComImport, Guid("61E00D45-8FFF-4e60-924E-6537B61612DD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumReadyCallback
	{
		/// <summary>
		/// Notifies the implementer that the view's item enumeration has completed. This callback interface is provided to the view via SetEnumReadyCallback
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-ienumreadycallback-enumready HRESULT EnumReady();
		[PreserveSig]
		HRESULT EnumReady();
	}
}