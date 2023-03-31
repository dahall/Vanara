using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Exposes methods for operations with a file association dialog box or menu.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iassochandler
	[ComImport, Guid("F04061AC-1659-4a3f-A954-775AA57FC083"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAssocHandler
	{
		/// <summary>Retrieves the full path and file name of the executable file associated with the file type.</summary>
		/// <param name="ppsz">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a null-terminated, Unicode string that contains the full path
		/// of the file, including the file name.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-getname HRESULT GetName(
		// LPWSTR *ppsz );
		[PreserveSig]
		HRESULT GetName([MarshalAs(UnmanagedType.LPWStr)] out string ppsz);

		/// <summary>Retrieves the display name of an application.</summary>
		/// <param name="ppsz">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a null-terminated, Unicode string that contains the display
		/// name of the application.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-getuiname HRESULT GetUIName(
		// LPWSTR *ppsz );
		[PreserveSig]
		HRESULT GetUIName([MarshalAs(UnmanagedType.LPWStr)] out string ppsz);

		/// <summary>Retrieves the location of the icon associated with the application.</summary>
		/// <param name="ppszPath">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a null-terminated, Unicode string that contains the path to
		/// the application's icon.
		/// </para>
		/// </param>
		/// <param name="pIndex">
		/// <para>Type: <c>int*</c></para>
		/// <para>When this method returns, contains a pointer to the index of the icon within the resource named in ppszPath.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the icon cannot be found, the function will return the path to the executable, and an icon index of zero.</para>
		/// <para>
		/// For performance reasons, an application may use the Shell image cache to retrieve the icon, rather than loading the icon
		/// directly from the path returned. The path and icon index can be passed directly to Shell_GetCachedImageIndex. One benefit of
		/// this is that the Shell cache can provide a default icon in the event that no icon was available for the application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-geticonlocation HRESULT
		// GetIconLocation( LPWSTR *ppszPath, int *pIndex );
		[PreserveSig]
		HRESULT GetIconLocation([MarshalAs(UnmanagedType.LPWStr)] out string ppszPath, out int pIndex);

		/// <summary>Indicates whether the application is registered as a recommended handler for the queried file type.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if the program is recommended; otherwise, S_FALSE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications that register themselves as handlers for particular file types can specify whether they are recommended
		/// handlers. This has no effect on the actual behavior of the applications when launched. It is simply provided as a hint to
		/// the user and a value that the UI can utilize programmatically, if desired. For example, the Shell's <c>Open With</c> dialog
		/// separates entries into <c>Recommended Programs</c> and <c>Other Programs</c>.
		/// </para>
		/// <para>
		/// Note that program recommendations may change over time. One example is provided when the user chooses an application from
		/// the <c>Other Programs</c> of the <c>Open With</c> dialog to open a particular file type. That may cause the Shell to
		/// "promote" that application to recommended status for that file type. Because the recommended status may change over time,
		/// applications should not cache this value, but query it each time it is needed.
		/// </para>
		/// <para>
		/// If SHAssocEnumHandlers was called with the ASSOC_FILTER_RECOMMENDED flag, then only recommended handlers are returned. If
		/// the ASSOC_FILTER_NONE flag was used, then you must call <c>IAssocHandler::IsRecommended</c> on each IAssocHandler object to
		/// determine whether it is recommended or not.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-isrecommended HRESULT IsRecommended();
		[PreserveSig]
		HRESULT IsRecommended();

		/// <summary>Sets an application as the default application for this file type.</summary>
		/// <param name="pszDescription">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a null-terminated, Unicode string that contains the display name of the application.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-makedefault HRESULT
		// MakeDefault( LPCWSTR pszDescription );
		[PreserveSig]
		HRESULT MakeDefault([MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		/// <summary>Directly invokes the associated handler.</summary>
		/// <param name="pdo">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>
		/// A pointer to an IDataObject that represents the selected item on which to invoke the handler. Note that you should not call
		/// <c>IAssocHandler::Invoke</c> with a selection of multiple items. If you have multiple items, call
		/// IAssocHandler::CreateInvoker instead. See Remarks for more details.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// IAssocHandler objects are typically used to populate an <c>Open With</c> menu. When one of those menu items is selected,
		/// this method is called to launch the chosen application.
		/// </para>
		/// <para>Invoke and CreateInvoker</para>
		/// <para>
		/// The IDataObject used by these methods can represent either a single file or a selection of multiple files. Not all
		/// applications support the multiple file option. The applications that do support that scenario might impose other
		/// restrictions, such as the number of files that can be opened simultaneously, or the acceptable combination of file types.
		/// </para>
		/// <para>
		/// Therefore, an application often must determine whether the handler supports the selection before trying to invoke the
		/// handler. For example, an application might enable a menu item only if it has verified that the selection in question was
		/// supported by that handler.
		/// </para>
		/// <para>
		/// It is generally safe to assume that an application will support invocation on a single item, and in those cases the
		/// application typically calls <c>IAssocHandler::Invoke</c> based on that assumption.
		/// </para>
		/// <para>
		/// For multiple selection scenarios, however, the application should call IAssocHandler::CreateInvoker. That method retrieves
		/// an IAssocHandlerInvoker object that allows the calling application to first check whether the selection is supported
		/// (SupportsSelection), then to invoke the handler (Invoke).
		/// </para>
		/// <para>
		/// <c>IAssocHandler::Invoke</c> can be called on a selection of multiple files, but it is not recommended because of the large
		/// processing load involved and no guarantee that it will succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-invoke HRESULT Invoke(
		// IDataObject *pdo );
		[PreserveSig]
		HRESULT Invoke([In] IDataObject pdo);

		/// <summary>
		/// Retrieves an object that enables the invocation of the associated handler on the current selection. The invoker includes the
		/// ability to verify whether the current selection is supported.
		/// </summary>
		/// <param name="pdo">
		/// <para>Type: <c>IDataObject*</c></para>
		/// <para>
		/// A pointer to an IDataObject that represents the selected item or items on which to invoke the handler. Note that if you have
		/// only a single item, IAssocHandler::Invoke could be the better choice. See Remarks for more details.
		/// </para>
		/// </param>
		/// <param name="ppInvoker">
		/// <para>Type: <c>IAssocHandlerInvoker**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to an IAssocHandlerInvoker object. This object is used to invoke
		/// the menu item after ensuring that the selected items are supported by the associated handler.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// IAssocHandler objects are typically used to populate an <c>Open With</c> menu. When one of those menu items is selected,
		/// this method is called to launch the chosen application.
		/// </para>
		/// <para>Invoke and CreateInvoker</para>
		/// <para>
		/// The IDataObject used by these methods can represent either a single file or it may represent a selection of multiple files.
		/// Not all applications support the multiple files option. Those applications that do support that scenario might impose other
		/// restrictions such as the number of files that can be opened at once, or acceptable combinations of file types.
		/// </para>
		/// <para>
		/// Therefore, an application often must determine whether the handler supports the selection before trying to invoke the
		/// handler. For example, an application might enable a menu item only if it knew that the selection in question was supported
		/// by that handler.
		/// </para>
		/// <para>
		/// It is generally safe to assume that an application will support invocation on a single item; in those cases the application
		/// typically calls IAssocHandler::Invoke.
		/// </para>
		/// <para>
		/// For multiple selection scenarios, the application should call <c>IAssocHandler::CreateInvoker</c>. That method retrieves an
		/// IAssocHandlerInvoker object that allows the calling application to first check whether the selection is supported
		/// (SupportsSelection), then to invoke the handler (Invoke).
		/// </para>
		/// <para>
		/// IAssocHandler::Invoke can be called on a selection of multiple files, but it is not recommended due to the large processing
		/// load involved and no guarantee of success.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandler-createinvoker HRESULT
		// CreateInvoker( IDataObject *pdo, IAssocHandlerInvoker **ppInvoker );
		[PreserveSig]
		HRESULT CreateInvoker([In] IDataObject pdo, out IAssocHandlerInvoker ppInvoker);
	}

	/// <summary>Exposes methods that invoke an associated application handler.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iassochandlerinvoker
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IAssocHandlerInvoker")]
	[ComImport, Guid("92218CAB-ECAA-4335-8133-807FD234C2EE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAssocHandlerInvoker
	{
		/// <summary>Determines whether an invoker supports its selection.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> if this instance supports its selection, or <c>S_FALSE</c> otherwise.</para>
		/// </returns>
		/// <remarks>
		/// For example, this method should return whether an application (as selected from an "Open With" context menu) can <c>Open</c>
		/// a file.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandlerinvoker-supportsselection
		// HRESULT SupportsSelection();
		[PreserveSig]
		HRESULT SupportsSelection();

		/// <summary>Invokes an associated application handler.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// There is no guarantee that a given association handler will support a particular selection, especially if multiple items are
		/// selected. Before attempting to invoke the selection via this method, it is recommended to call IAssocHandlerInvoker::SupportsSelection.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iassochandlerinvoker-invoke HRESULT Invoke();
		[PreserveSig]
		HRESULT Invoke();
	}

	/// <summary>Exposes a method that allows enumeration of a collection of handlers associated with particular file name extensions.</summary>
	/// <remarks>SHAssocEnumHandlers is the usual method of creating an IEnumAssocHandlers pointer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumassochandlers
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IEnumAssocHandlers")]
	[ComImport, Guid("973810ae-9599-4b88-9e4d-6ee98c9552da"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumAssocHandlers
	{
		/// <summary>Retrieves a specified number of elements.</summary>
		/// <param name="celt">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of elements to retrieve.</para>
		/// </param>
		/// <param name="rgelt">
		/// <para>Type: <c>IAssocHandler**</c></para>
		/// <para>
		/// When this method returns, contains the address of an array of IAssocHandler pointers. Each <c>IAssocHandler</c> represents a
		/// single handler.
		/// </para>
		/// </param>
		/// <param name="pceltFetched">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>When this method returns, contains a pointer to the number of elements retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ienumassochandlers-next HRESULT Next( ULONG
		// celt, IAssocHandler **rgelt, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IAssocHandler[] rgelt, out uint pceltFetched);
	}
}