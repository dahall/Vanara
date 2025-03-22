using System.Diagnostics.CodeAnalysis;
using System.Security;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// <para>
	/// Exposes methods that allow implementers of a custom IAssocHandler object to provide access to its explicit Application User
	/// Model ID (AppUserModelID). This information is used to determine whether a particular file type can be added to an application's
	/// Jump List.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Only file types for which an application is a registered handler appear in that application's Jump List. When an application
	/// uses an explicit AppUserModelID to identify itself and the windows and processes that belong to it, that AppUserModelID must
	/// also be set in a handler's implementation so that the handler is recognized as being associated with that application. When the
	/// application accesses a file such that SHAddToRecentDocs is called as a result, an attempt is made to add the file to the
	/// <c>Recent</c> or <c>Frequent</c> category, or possibly a custom category, in that application's Jump List. If the application is
	/// a registered handler for that file type, identified as such by the handler's AppUserModelID matching the application's
	/// AppUserModelID, that file is added to the Jump List. If not, it is filtered and does not appear.
	/// </para>
	/// <para>When to Implement</para>
	/// <para>
	/// An implementation of this interface is provided in Windows. Applications that create custom Shell folders that expose an
	/// association handler enumeration needed by the system to determine the files allowed in the application's Jump List should
	/// implement their own versions.
	/// </para>
	/// <para>When to Use</para>
	/// <para>
	/// This object is needed only if your application is using explicit AppUserModelIDs. Without an explicit AppUserModelID to expose,
	/// there is no need for this object.
	/// </para>
	/// <para>
	/// <c>IObjectWithAppUserModelID</c> is always used as part of a larger object that uses explicit AppUserModelIDs and wants to
	/// expose that information to the system.
	/// </para>
	/// <para>
	/// The system calls the IObjectWithAppUserModelID::GetAppID method implemented on a handler to determine whether the application is
	/// a registered handler for a file type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iobjectwithappusermodelid
	[PInvokeData("shobjidl_core.h", MSDNShortId = "f5b4e6bf-a5bf-49c5-b343-e9c1ec6c263d")]
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36db0196-9665-46d1-9ba7-d3709eecf9ed")]
	public interface IObjectWithAppUserModelId
	{
		/// <summary>
		/// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the object as a handler
		/// for a specific file type. This method is used by applications that require dynamic AppUserModelIDs.
		/// </summary>
		/// <param name="pszAppID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to the AppUserModelID string to assign to an application.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Custom implementations that do not require dynamic AppUserModelIDs can return E_NOTIMPL. Custom implementations that require
		/// dynamic AppUserModelIDs should return S_OK if successful, or an error value otherwise.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iobjectwithappusermodelid-setappid
		[PreserveSig]
		HRESULT SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

		/// <summary>
		/// <para>Retrieves a file type handler's explicit Application User Model ID (AppUserModelID), if one has been declared.</para>
		/// </summary>
		/// <param name="ppszAppID">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>When this method returns, contains the address of the AppUserModelID string assigned to the object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method can only retrieve an AppUserModelID explicitly set for the handler. If the handler did not register an explicit
		/// AppUserModelID and is relying on a system-assigned AppUserModelID, this method will not retrieve the AppUserModelID. For
		/// more information, see Application User Model IDs (AppUserModelIDs).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iobjectwithappusermodelid-getappid
		[PreserveSig]
		HRESULT GetAppID([MarshalAs(UnmanagedType.LPWStr)] out string ppszAppID);
	}

	/// <summary>Provides a method for interacting with back references held by an object.</summary>
	/// <remarks>
	/// <para>When to Use</para>
	/// <para>
	/// When an object contains forward references to child objects that have back references to the parent object, circular references
	/// can occur. To break this circle, the parent object needs to keep track of back references from child objects.
	/// </para>
	/// <para>When to Implement</para>
	/// <para>
	/// This interface should be implemented by Shell data source objects (objects that implement IShellFolder) that hold references to
	/// other objects in a way that might result in reference cycles. For example, an object that maintains references to other data
	/// source objects that are cached as the result of binding operations should implement this interface.
	/// </para>
	/// <para>
	/// This interface was available in Windows Vista with Service Pack 1 (SP1), but it was not declared in a public header until
	/// Windows 7. For use in Windows Vista with SP1, the following Interface Definition Language (IDL) fragment describes this
	/// interface, including its IID.
	/// </para>
	/// <para>The following C++ fragment can be used to enable access to this interface.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iobjectwithbackreferences
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IObjectWithBackReferences")]
	[ComImport, Guid("321a6a6a-d61f-4bf3-97ae-14be2986bb36"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectWithBackReferences
	{
		/// <summary>Removes all back references held by an object.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// This method is used for all tasks associated with freeing/releasing back references held by an object, and may prepare an
		/// object for reuse.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectwithbackreferences-removebackreferences
		// HRESULT RemoveBackReferences();
		[PreserveSig]
		HRESULT RemoveBackReferences();
	}

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>Supplies a caller with an event that will be signaled by the called object to denote cancellation of a task.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iobjectwithcancelevent
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IObjectWithCancelEvent")]
	[ComImport, Guid("F279B885-0AE9-4b85-AC06-DDECF9408941"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectWithCancelEvent
	{
		/// <summary>Retrieves an event that will be sent when an operation is canceled.</summary>
		/// <param name="phEvent">
		/// <para>Type: <c>HANDLE*</c></para>
		/// <para>
		/// Pointer to a handle that, when this method successfully returns, is the handle to the cancel event. The caller is
		/// responsible for closing this handle when it is no longer needed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Call this function to retrieve an event that will be signaled when the called object cancels the operation it is performing.
		/// The caller is responsible for closing the returned handle.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-iobjectwithcancelevent-getcancelevent
		// HRESULT GetCancelEvent( HANDLE *phEvent );
		[PreserveSig]
		HRESULT GetCancelEvent(out HANDLE phEvent);
	}

	/// <summary>Exposes methods that provide access to the ProgID associated with an object.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iobjectwithprogid
	[PInvokeData("shobjidl_core.h", MSDNShortId = "3b66ba49-ed39-464e-b15a-c72fdff7f5e5")]
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("71e806fb-8dee-46fc-bf8c-7748a8a1ae13")]
	public interface IObjectWithProgId
	{
		/// <summary>
		/// <para>Sets the ProgID of an object.</para>
		/// </summary>
		/// <param name="pszProgID">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a string that contains the new ProgID.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		[PreserveSig]
		HRESULT SetProgID([MarshalAs(UnmanagedType.LPWStr)] string pszProgID);

		/// <summary>
		/// <para>Retrieves the ProgID associated with an object.</para>
		/// </summary>
		/// <param name="ppszProgID">
		/// <para>Type: <c>LPWSTR*</c></para>
		/// <para>A pointer to a string that, when this method returns successfully, contains the ProgID.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		[PreserveSig]
		HRESULT GetProgID([MarshalAs(UnmanagedType.LPWStr)] out string ppszProgID);
	}

	/// <summary>Exposes methods that get or set selected items represented by a Shell item array.</summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>
	/// This interface is implemented by verbs that implement IExecuteCommand. This allows objects to invoke the verb on the selection
	/// through IExecuteCommand::Execute.
	/// </para>
	/// <para>When to Use</para>
	/// <para>
	/// <c>IObjectWithSelection</c> is used by Windows Explorer to invoke a verb on the selected items. Do not call this interface directly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iobjectwithselection
	[PInvokeData("shobjidl_core.h", MSDNShortId = "8fb248eb-73e7-4db0-8585-4accafe332d0")]
	[ComImport, Guid("1c9cd5bb-98e9-4491-a60f-31aacc72b83c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IObjectWithSelection
	{
		/// <summary>Provides the Shell item array that specifies the items included in the selection.</summary>
		/// <param name="psia">
		/// <para>Type: <c>IShellItemArray*</c></para>
		/// <para>A pointer to an IShellItemArray that represents the selected items.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iobjectwithselection-setselection HRESULT
		// SetSelection( IShellItemArray *psia );
		[PreserveSig]
		HRESULT SetSelection([In] IShellItemArray psia);

		/// <summary>Gets the Shell item array that contains the selected items.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>A reference to the IID of the interface to retrieve through ppv, typically IID_IShellItemArray.</para>
		/// </param>
		/// <param name="ppv">
		/// <para>Type: <c>void**</c></para>
		/// <para>When this method returns successfully, contains the interface pointer requested in riid. This is typically an IShellItemArray.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// We recommend that you use the <c>IID_PPV_ARGS</c> macro, defined in Objbase.h, to package the riid and ppv parameters. This
		/// macro provides the correct IID based on the interface pointed to by the value in ppv, which eliminates the possibility of a
		/// coding error in riid that could lead to unexpected results.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iobjectwithselection-getselection HRESULT
		// GetSelection( REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT GetSelection(in Guid riid, [MaybeNull, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppv);
	}
}