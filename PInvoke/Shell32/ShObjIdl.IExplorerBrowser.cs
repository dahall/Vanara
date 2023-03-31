using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>These flags are used with IExplorerBrowser::FillFromObject.</summary>
	[Flags]
	[PInvokeData("Shobjidl.h", MSDNShortId = "5be62600-147d-4625-8e6c-aa6687da2168")]
	public enum EXPLORER_BROWSER_FILL_FLAGS
	{
		/// <summary>No flags.</summary>
		EBF_NONE = 0x0000000,

		/// <summary>
		/// Causes IExplorerBrowser::FillFromObject to first populate the results folder with the contents of the parent folders of the
		/// items in the data object, and then select only the items that are in the data object.
		/// </summary>
		EBF_SELECTFROMDATAOBJECT = 0x0000100,

		/// <summary>
		/// Do not allow dropping on the folder. In other words, do not register a drop target for the view. Applications can then
		/// register their own drop targets.
		/// </summary>
		EBF_NODROPTARGET = 0x0000200,
	}

	/// <summary>These flags are used with IExplorerBrowser::GetOptions and IExplorerBrowser::SetOptions.</summary>
	[Flags]
	[PInvokeData("Shobjidl.h", MSDNShortId = "4e2983bc-cad2-4bcc-8169-57b5274b2142")]
	public enum EXPLORER_BROWSER_OPTIONS
	{
		/// <summary>No options.</summary>
		EBO_NONE = 0x00000000,

		/// <summary>Do not navigate further than the initial navigation.</summary>
		EBO_NAVIGATEONCE = 0x00000001,

		/// <summary>
		/// Use the following standard panes: Commands Module pane, Navigation pane, Details pane, and Preview pane. An implementer of
		/// IExplorerPaneVisibility can modify the components of the Commands Module that are shown. For more information see,
		/// IExplorerPaneVisibility::GetPaneState. If EBO_SHOWFRAMES is not set, Explorer browser uses a single view object.
		/// </summary>
		EBO_SHOWFRAMES = 0X00000002,

		/// <summary>Always navigate, even if you are attempting to navigate to the current folder.</summary>
		EBO_ALWAYSNAVIGATE = 0x00000004,

		/// <summary>Do not update the travel log.</summary>
		EBO_NOTRAVELLOG = 0x00000008,

		/// <summary>
		/// Do not use a wrapper window. This flag is used with legacy clients that need the browser parented directly on themselves.
		/// </summary>
		EBO_NOWRAPPERWINDOW = 0x00000010,

		/// <summary>Show WebView for SharePoint sites.</summary>
		EBO_HTMLSHAREPOINTVIEW = 0x00000020,

		/// <summary>Introduced in Windows Vista. Do not draw a border around the browser window.</summary>
		EBO_NOBORDER = 0x00000040,

		/// <summary>Introduced in Windows Vista. Do not persist the view state.</summary>
		EBO_NOPERSISTVIEWSTATE = 0x00000080,
	}

	/// <summary>
	/// <para>
	/// <c>IExplorerBrowser</c> is a browser object that can be either navigated or that can host a view of a data object. As a
	/// full-featured browser object, it also supports an automatic travel log.
	/// </para>
	/// <para>
	/// The Shell provides a default implementation of <c>IExplorerBrowser</c> as CLSID_ExplorerBrowser. Typically, a developer does not
	/// need to provide a custom implementation of this interface.
	/// </para>
	/// <para>
	/// The Windows Software Development Kit (SDK) provides full samples that demonstrate the use of and interaction with
	/// <c>IExplorerBrowser</c>. Download the Explorer Browser Search Sample and the Explorer Browser Custom Contents Sample.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// For example code that shows typical use of <c>IExplorerBrowser</c> and its methods, see the Explorer Browser Custom Contents and
	/// Explorer Browser Custom Contents samples.
	/// </para>
	/// <para>
	/// After calling this object's Initialize method, its Destroy method must be called to free any windowed resources that were
	/// generated in the call to <c>Initialize</c>.
	/// </para>
	/// <para>
	/// The object that hosts the ExplorerBrowser object should derive from IServiceProvider and implement QueryService to respond to any
	/// queries for service. For example, the number of panes shown by the browser can be controlled by implementing
	/// IExplorerPaneVisibility and responding to any SID_ExplorerPaneVisibility service requests.
	/// </para>
	/// <para>
	/// Frames are disabled by default. To enable frames and get the default set of panes, set the EBO_SHOWFRAMES flag using the
	/// IExplorerBrowser::SetOptions method. The default panes, listed as IExplorerPaneVisibility constants, are these:
	/// </para>
	/// <list type="bullet">
	/// <item>EP_NavPane</item>
	/// <item>EP_Commands</item>
	/// <item>EP_Commands_Organize</item>
	/// <item>EP_Commands_View</item>
	/// <item>EP_DetailsPane</item>
	/// <item>EP_PreviewPane</item>
	/// <item>EP_QueryPane</item>
	/// <item>EP_AdvQueryPane</item>
	/// <item>EP_StatusBar</item>
	/// <item>EP_Ribbon</item>
	/// </list>
	/// <para>See IExplorerPaneVisibility::GetPaneState for more information.</para>
	/// <para>
	/// Clients of the ExplorerBrowser object can implement the ICommDlgBrowser, ICommDlgBrowser2, or ICommDlgBrowser3 interfaces and
	/// respond to an SID_SExplorerBrowserFrame service request in their QueryService implementations that are called when any
	/// <c>ICommDlgBrowser</c> interfaces are called on the browser (usually called from the view as a result of user actions). Note that
	/// the client does not receive a call to ICommDlgBrowser::IncludeObject if a folder filter has been set on the browser by a call to IFolderFilterSite::SetFilter.
	/// </para>
	/// <para>
	/// To remain compatible with some older applications, the default Shell view (DefView) performs filtering operations (for example,
	/// searching operations executed by a search folder) on the UI thread. For new applications, this is typically not desired; the
	/// search should execute on a background thread. To stop the UI thread from filtering and instead run filtering on a background
	/// thread, provide ICommDlgBrowser2 through the SID_SExplorerBrowserFrame service request. When ICommDlgBrowser2::GetViewFlags is
	/// called, it should return CDB2GVF_NOINCLUDEITEM. For example, if you navigate to a search folder in ExplorerBrowser and you do not
	/// return CDB2GVF_NOINCLUDEITEM, the view can stop responding until the entire search is complete.
	/// </para>
	/// <para>
	/// The Shell architecture has three main components: the browser, the views, and the data sources (for example, IShellFolder). The
	/// ExplorerBrowser object maintains the current location and navigation to other locations throughout the Shell namespace. It also
	/// keeps a travel log (forward and back history). The browser is notified when things happen in the view; for example, when the user
	/// double-clicks a folder. In response, the browser navigates to that location. The data sources are the objects that supply the
	/// items and folders in the namespace. They also have information about the location, such as the properties of the items and what
	/// to add to the context menu when the view requests it. Additionally, the data sources know what view should be created to
	/// represent their items at a location. In almost all instances, the folders create the Shell's default view (DefView). Therefore,
	/// as the browser navigates, it receives an IShellFolder object for the new location and asks it what view to create. The browser
	/// then creates that view and makes it visible, while hiding and then destroying the view that was showing the previous location.
	/// The view is responsible for communicating with <c>IShellFolder</c> for the current location and requesting it to enumerate the
	/// items, which allows the view to show these items to the user. As the user interacts with the items, the view communicates with
	/// the <c>IShellFolder</c> to get any additional information it needs, such as specific properties of the items or the context menu
	/// entries for the item.
	/// </para>
	/// <para>
	/// If an application uses the default implementation provided by CLSID_ExplorerBrowser, inserting it into the window of an
	/// application and then browsing to a location, ExplorerBrowser creates the proper IShellView as specified by the location that it
	/// is browsing to. The application can then ask ExplorerBrowser to give it an interface on the current view, allowing the
	/// application to manipulate the view directly if required. The default implementation of the Windows Explorer view object, created
	/// by SHCreateShellFolderViewEx, supports the interface <c>IShellView</c>. You may verify that you have the default Shell folder
	/// view object by calling IExplorerBrowser::GetCurrentView and then calling QueryInterface on the object returned using the
	/// interface ID IID_CDefView.
	/// </para>
	/// <para>
	/// <c>Windows 7 and later</c>. CExplorerBrowser can support in-place navigation by using IServiceProvider::QueryService with the
	/// Service ID SID_SlnPlaceBrowser. When using SID_SInPlaceBrowser, the CExplorerBrowser state cannot be set to EBO_NAVIGATEONCE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iexplorerbrowser
	[PInvokeData("shobjidl_core.h", MSDNShortId = "da2cf5d4-5a68-4d18-807b-b9d4e2712c10")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("dfd3b6b5-c10c-4be9-85f6-a66969f402f6"), CoClass(typeof(ExplorerBrowser))]
	public interface IExplorerBrowser
	{
		/// <summary>Prepares the browser to be navigated.</summary>
		/// <param name="hwndParent">A handle to the owner window or control.</param>
		/// <param name="prc">
		/// A pointer to a RECT that contains the coordinates of the bounding rectangle that the browser will occupy. The coordinates are
		/// relative to hwndParent.
		/// </param>
		/// <param name="pfs">A pointer to a FOLDERSETTINGS structure that determines how the folder will be displayed in the view.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Initialize([In] IntPtr hwndParent, in RECT prc, [Optional] PFOLDERSETTINGS pfs);

		/// <summary>Destroys the browser.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Destroy();

		/// <summary>Sets the size and position of the view windows created by the browser.</summary>
		/// <param name="phdwp">A pointer to a DeferWindowPos handle. This parameter can be NULL.</param>
		/// <param name="rcBrowser">The coordinates that the browser will occupy.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetRect([In, Out] ref HDWP phdwp, [In] RECT rcBrowser);

		/// <summary>Sets the name of the property bag.</summary>
		/// <param name="pszPropertyBag">
		/// A pointer to a constant, null-terminated, Unicode string that contains the name of the property bag. View state information
		/// that is specific to the application of the client is stored (persisted) using this name.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetPropertyBag([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyBag);

		/// <summary>Sets the default empty text.</summary>
		/// <param name="pszEmptyText">A pointer to a constant, null-terminated, Unicode string that contains the empty text.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetEmptyText([In, MarshalAs(UnmanagedType.LPWStr)] string pszEmptyText);

		/// <summary>Sets the folder settings for the current view.</summary>
		/// <param name="pfs">A pointer to a FOLDERSETTINGS structure that contains the folder settings to be applied.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetFolderSettings(in FOLDERSETTINGS pfs);

		/// <summary>Initiates a connection with IExplorerBrowser for event callbacks.</summary>
		/// <param name="psbe">A pointer to the IExplorerBrowserEvents interface of the object to be advised of IExplorerBrowser events.</param>
		/// <param name="pdwCookie">
		/// When this method returns, contains a token that uniquely identifies the event listener. This allows several event listeners
		/// to be subscribed at a time.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Advise([In] IExplorerBrowserEvents psbe, out uint pdwCookie);

		/// <summary>Terminates an advisory connection.</summary>
		/// <param name="dwCookie">
		/// A connection token previously returned from IExplorerBrowser::Advise. Identifies the connection to be terminated.
		/// </param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void Unadvise([In] uint dwCookie);

		/// <summary>Sets the current browser options.</summary>
		/// <param name="dwFlag">One or more EXPLORER_BROWSER_OPTIONS flags to be set.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetOptions([In] EXPLORER_BROWSER_OPTIONS dwFlag);

		/// <summary>Gets the current browser options.</summary>
		/// <param name="pdwFlag">When this method returns, contains the current EXPLORER_BROWSER_OPTIONS for the browser.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetOptions(out EXPLORER_BROWSER_OPTIONS pdwFlag);

		/// <summary>Browses to a pointer to an item identifier list (PIDL)</summary>
		/// <param name="pidl">
		/// A pointer to a const ITEMIDLIST (item identifier list) that specifies an object's location as the destination to navigate to.
		/// This parameter can be NULL. For more information, see Remarks.
		/// </param>
		/// <param name="uFlags">A flag that specifies the category of the pidl. This affects how navigation is accomplished.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void BrowseToIDList([In] PIDL pidl, [In] SBSP uFlags);

		/// <summary>Browses to an object.</summary>
		/// <param name="punk">A pointer to an object to browse to. If the object cannot be browsed, an error value is returned.</param>
		/// <param name="uFlags">A flag that specifies the category of the pidl. This affects how navigation is accomplished.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT BrowseToObject([MarshalAs(UnmanagedType.IUnknown)] object punk, SBSP uFlags);

		/// <summary>Creates a results folder and fills it with items.</summary>
		/// <param name="punk">
		/// An interface pointer on the source object that will fill the IResultsFolder. This can be an IDataObject or any object that
		/// can be used with INamespaceWalk.
		/// </param>
		/// <param name="dwFlags">One of the EXPLORER_BROWSER_FILL_FLAGS values.</param>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void FillFromObject([In, MarshalAs(UnmanagedType.IUnknown)] object punk, [In] EXPLORER_BROWSER_FILL_FLAGS dwFlags);

		/// <summary>Removes all items from the results folder.</summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void RemoveAll();

		/// <summary>Gets an interface for the current view of the browser.</summary>
		/// <param name="riid">A reference to the desired interface ID.</param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in <paramref name="riid"/>. This will typically be
		/// IShellView, IShellView2, IFolderView, or a related interface.
		/// </returns>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)]
		object GetCurrentView(in Guid riid);
	}

	/// <summary>Exposes methods for notification of Explorer browser navigation and view creation events.</summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("361bbdc7-e6ee-4e13-be58-58e2240c810f")]
	[PInvokeData("Shobjidl.h", MSDNShortId = "802d547f-41c2-4c4a-9f07-be615d7b86eb")]
	public interface IExplorerBrowserEvents
	{
		/// <summary>Notifies clients of a pending Explorer browser navigation to a Shell folder.</summary>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A PIDL that specifies the folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Explorer browser calls this method before it navigates to a folder, that is, before calling
		/// IExplorerBrowserEvents::OnNavigationFailed or IExplorerBrowserEvents::OnNavigationComplete.
		/// </para>
		/// <para>Returning any failure code from this method, including E_NOTIMPL, will cancel the navigation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexplorerbrowserevents-onnavigationpending
		// HRESULT OnNavigationPending( PCIDLIST_ABSOLUTE pidlFolder );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnNavigationPending([In] IntPtr pidlFolder);

		/// <summary>Notifies clients that the view of the Explorer browser has been created and can be modified.</summary>
		/// <param name="psv">
		/// <para>Type: <c>IShellView*</c></para>
		/// <para>A pointer to an IShellView.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// An Explorer browser calls this method to enable the client to perform any modifications to the Explorer browser view before
		/// it is shown; for example, to set view modes or folder flags.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexplorerbrowserevents-onviewcreated
		// HRESULT OnViewCreated( IShellView *psv );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnViewCreated([In] IShellView psv);

		/// <summary>Notifies clients that the Explorer browser has successfully navigated to a Shell folder.</summary>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A PIDL that specifies the folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is called after method IExplorerBrowserEvents::OnViewCreated, assuming a successful view creation.</para>
		/// <para>
		/// After a navigation and view creation, either <c>IExplorerBrowserEvents::OnNavigationComplete</c> or
		/// IExplorerBrowserEvents::OnNavigationFailed is called depending on whether the destination could be navigated to. For example,
		/// a failure to navigate includes a destination that is not reached either because there is no route to the path or the user has canceled.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexplorerbrowserevents-onnavigationcomplete
		// HRESULT OnNavigationComplete( PCIDLIST_ABSOLUTE pidlFolder );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnNavigationComplete([In] IntPtr pidlFolder);

		/// <summary>Notifies clients that the Explorer browser has failed to navigate to a Shell folder.</summary>
		/// <param name="pidlFolder">
		/// <para>Type: <c>PCIDLIST_ABSOLUTE</c></para>
		/// <para>A PIDL that specifies the folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is called after method IExplorerBrowserEvents::OnViewCreated, assuming a successful view creation.</para>
		/// <para>
		/// After a navigation and view creation, either IExplorerBrowserEvents::OnNavigationComplete or
		/// <c>IExplorerBrowserEvents::OnNavigationFailed</c> is called, depending on whether the destination could be navigated to. For
		/// example, a failure to navigate includes a destination that is not reached either because there is no route to the path or the
		/// user has canceled.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexplorerbrowserevents-onnavigationfailed
		// HRESULT OnNavigationFailed( PCIDLIST_ABSOLUTE pidlFolder );
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[PreserveSig]
		HRESULT OnNavigationFailed([In] IntPtr pidlFolder);
	}

	/// <summary>Extension method to simplify using the <see cref="IExplorerBrowser.GetCurrentView"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="eb">An <see cref="IExplorerBrowser"/> instance.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T GetCurrentView<T>(this IExplorerBrowser eb) where T : class => (T)eb.GetCurrentView(typeof(T).GUID);

	/// <summary>The ExplorerBrowser class is the base CoClass for all I ExplorerBrowser interfaces.</summary>
	[ComImport, Guid("71f96385-ddd6-48d3-a0c1-ae06e8b055fb"), ClassInterface(ClassInterfaceType.None)]
	[PInvokeData("Shobjidl.h", MSDNShortId = "da2cf5d4-5a68-4d18-807b-b9d4e2712c10")]
	public class ExplorerBrowser { }
}