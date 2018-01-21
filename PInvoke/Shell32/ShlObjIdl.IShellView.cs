using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMethodReturnValue.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
		[System.Security.SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool AddPropSheetPageProc(IntPtr hpage, IntPtr lParam);

		[Flags]
		public enum FCT : uint
		{
			/// <summary>Merge the toolbar items instead of replacing all of the buttons with those provided by the view. This is the recommended choice.</summary>
			FCT_MERGE = 0x0001,
			/// <summary>Not implemented.</summary>
			FCT_CONFIGABLE = 0x0002,
			/// <summary>Add at the right side of the toolbar.</summary>
			FCT_ADDTOEND = 0x0004,
		}

		[Flags]
		public enum FCW : uint
		{
			FCW_INTERNETBAR = 0x0006,
			/// <summary>Retrieves the window handle to the browser's progress bar.</summary>
			FCW_PROGRESS = 0x0008,
			/// <summary>Retrieves the window handle to the browser's status bar.</summary>
			FCW_STATUS = 0x0001,
			/// <summary>Retrieves the window handle to the browser's toolbar.</summary>
			FCW_TOOLBAR = 0x0002,
			/// <summary>Retrieves the window handle to the browser's tree view.</summary>
			FCW_TREE = 0x0003,
		}

		[Flags]
		public enum FOLDERFLAGS : uint
		{
			/// <summary>Windows 7 and later. No special view options.</summary>
			FWF_NONE = 0x00000000,
			/// <summary>Automatically arrange the elements in the view. This implies LVS_AUTOARRANGE if the list-view control is used to implement the view.</summary>
			FWF_AUTOARRANGE = 0x00000001,
			/// <summary>Not supported.</summary>
			FWF_ABBREVIATEDNAMES = 0x00000002,
			/// <summary>Not supported.</summary>
			FWF_SNAPTOGRID = 0x00000004,
			/// <summary>Not supported.</summary>
			FWF_OWNERDATA = 0x00000008,
			/// <summary>Not supported.</summary>
			FWF_BESTFITWINDOW = 0x00000010,
			/// <summary>Make the folder behave like the desktop. This value applies only to the desktop and is not used for typical Shell folders. This flag implies FWF_NOCLIENTEDGE and FWF_NOSCROLL.</summary>
			FWF_DESKTOP = 0x00000020,
			/// <summary>Do not allow more than a single item to be selected. This is used in the common dialog boxes.</summary>
			FWF_SINGLESEL = 0x00000040,
			/// <summary>Do not show subfolders.</summary>
			FWF_NOSUBFOLDERS = 0x00000080,
			/// <summary>Draw transparently. This is used only for the desktop.</summary>
			FWF_TRANSPARENT = 0x00000100,
			/// <summary>Not supported.</summary>
			FWF_NOCLIENTEDGE = 0x00000200,
			/// <summary>Do not add scroll bars. This is used only for the desktop.</summary>
			FWF_NOSCROLL = 0x00000400,
			/// <summary>The view should be left-aligned. This implies LVS_ALIGNLEFT if the list-view control is used to implement the view.</summary>
			FWF_ALIGNLEFT = 0x00000800,
			/// <summary>The view should not display icons.</summary>
			FWF_NOICONS = 0x00001000,
			/// <summary>This flag is deprecated as of Windows XP and has no effect. Always show the selection.</summary>
			FWF_SHOWSELALWAYS = 0x00002000,
			/// <summary>Not supported.</summary>
			FWF_NOVISIBLE = 0x00004000,
			/// <summary>Not supported.</summary>
			FWF_SINGLECLICKACTIVATE = 0x00008000,
			/// <summary>The view should not be shown as a web view.</summary>
			FWF_NOWEBVIEW = 0x00010000,
			/// <summary>The view should not display file names.</summary>
			FWF_HIDEFILENAMES = 0x00020000,
			/// <summary>Turns on the check mode for the view.</summary>
			FWF_CHECKSELECT = 0x00040000,
			/// <summary>Windows Vista and later. Do not re-enumerate the view (or drop the current contents of the view) when the view is refreshed.</summary>
			FWF_NOENUMREFRESH = 0x00080000,
			/// <summary>Windows Vista and later. Do not allow grouping in the view</summary>
			FWF_NOGROUPING = 0x00100000,
			/// <summary>Windows Vista and later. When an item is selected, the item and all its sub-items are highlighted.</summary>
			FWF_FULLROWSELECT = 0x00200000,
			/// <summary>Windows Vista and later. Do not display filters in the view.</summary>
			FWF_NOFILTERS = 0x00400000,
			/// <summary>Windows Vista and later. Do not display a column header in the view in any view mode.</summary>
			FWF_NOCOLUMNHEADER = 0x00800000,
			/// <summary>Windows Vista and later. Only show the column header in details view mode.</summary>
			FWF_NOHEADERINALLVIEWS = 0x01000000,
			/// <summary>Windows Vista and later. When the view is in "tile view mode" the layout of a single item should be extended to the width of the view.</summary>
			FWF_EXTENDEDTILES = 0x02000000,
			/// <summary>Windows Vista and later. Not supported.</summary>
			FWF_TRICHECKSELECT = 0x04000000,
			/// <summary>Windows Vista and later. Items can be selected using checkboxes.</summary>
			FWF_AUTOCHECKSELECT = 0x08000000,
			/// <summary>Windows Vista and later. The view should not save view state in the browser.</summary>
			FWF_NOBROWSERVIEWSTATE = 0x10000000,
			/// <summary>Windows Vista and later. The view should list the number of items displayed in each group. To be used with IFolderView2::SetGroupSubsetCount.</summary>
			FWF_SUBSETGROUPS = 0x20000000,
			/// <summary>Windows Vista and later. Use the search folder for stacking and searching.</summary>
			FWF_USESEARCHFOLDER = 0x40000000,
			/// <summary>Windows Vista and later. Ensure right-to-left reading layout in a right-to-left system. Without this flag, the view displays strings from left-to-right both on systems set to left-to-right and right-to-left reading layout, which ensures that file names display correctly.</summary>
			FWF_ALLOWRTLREADING = 0x80000000,
		}

		public enum FOLDERVIEWMODE
		{
			/// <summary>The view should determine the best option.</summary>
			FVM_AUTO = -1,
			/// <summary>Windows 7 and later. The view should display content mode.</summary>
			FVM_CONTENT = 8,
			/// <summary>Object names and other selected information, such as the size or date last updated, are shown.</summary>
			FVM_DETAILS = 4,
			/// <summary>The view should display medium-size icons.</summary>
			FVM_ICON = 1,
			/// <summary>Object names are displayed in a list view.</summary>
			FVM_LIST = 3,
			/// <summary>The view should display small icons.</summary>
			FVM_SMALLICON = 2,
			/// <summary>The view should display thumbnail icons.</summary>
			FVM_THUMBNAIL = 5,
			/// <summary>The view should display icons in a filmstrip format.</summary>
			FVM_THUMBSTRIP = 7,
			/// <summary>The view should display large icons.</summary>
			FVM_TILE = 6,
		}

		[Flags]
		public enum SBSP : uint
		{
			/// <summary>An absolute PIDL, relative to the desktop.</summary>
			SBSP_ABSOLUTE = 0x0000,

			/// <summary>Windows Vista and later. Navigate without the default behavior of setting focus into the new view.</summary>
			SBSP_ACTIVATE_NOFOCUS = 0x00080000,

			/// <summary>Enable auto-navigation.</summary>
			SBSP_ALLOW_AUTONAVIGATE = 0x00010000,

			/// <summary>Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The navigation was possibly initiated by a webpage with scripting code already present on the local system.</summary>
			SBSP_CALLERUNTRUSTED = 0x00800000,

			/// <summary>Windows 7 and later. Do not add a new entry to the travel log. When the user enters a search term in the search box and subsequently refines the query, the browser navigates forward but does not add an additional travel log entry.</summary>
			SBSP_CREATENOHISTORY = 0x00100000,

			/// <summary>Use default behavior, which respects the view option (the user setting to create new windows or to browse in place). In most cases, calling applications should use this flag.</summary>
			SBSP_DEFBROWSER = 0x0000,

			/// <summary>Use the current window.</summary>
			SBSP_DEFMODE = 0x0000,

			/// <summary>Specifies a folder tree for the new browse window. If the current browser does not match the SBSP_EXPLOREMODE of the browse object call, a new window is opened.</summary>
			SBSP_EXPLOREMODE = 0x0020,

			/// <summary>Windows Internet Explorer 7 and later. If allowed by current registry settings, give the browser a destination to navigate to.</summary>
			SBSP_FEEDNAVIGATION = 0x20000000,

			/// <summary>Not supported. Do not use.</summary>
			SBSP_HELPMODE = 0x0040,

			/// <summary>Undocumented</summary>
			SBSP_INITIATEDBYHLINKFRAME = 0x80000000,

			/// <summary>Windows Vista and later. Not supported. Do not use.</summary>
			SBSP_KEEPSAMETEMPLATE = 0x00020000,

			/// <summary>Windows Vista and later. Navigate without clearing the search entry field.</summary>
			SBSP_KEEPWORDWHEELTEXT = 0x00040000,

			/// <summary>Navigate back, ignore the PIDL.</summary>
			SBSP_NAVIGATEBACK = 0x4000,

			/// <summary>Navigate forward, ignore the PIDL.</summary>
			SBSP_NAVIGATEFORWARD = 0x8000,

			/// <summary>Creates another window for the specified folder.</summary>
			SBSP_NEWBROWSER = 0x0002,

			/// <summary>Suppress selection in the history pane.</summary>
			SBSP_NOAUTOSELECT = 0x04000000,

			/// <summary>Do not transfer the browsing history to the new window.</summary>
			SBSP_NOTRANSFERHIST = 0x0080,

			/// <summary>Specifies no folder tree for the new browse window. If the current browser does not match the SBSP_OPENMODE of the browse object call, a new window is opened.</summary>
			SBSP_OPENMODE = 0x0010,

			/// <summary>Browse the parent folder, ignore the PIDL.</summary>
			SBSP_PARENT = 0x2000,

			/// <summary>Windows 7 and later. Do not make the navigation complete sound for each keystroke in the search box.</summary>
			SBSP_PLAYNOSOUND = 0x00200000,

			/// <summary>Enables redirection to another URL.</summary>
			SBSP_REDIRECT = 0x40000000,

			/// <summary>A relative PIDL, relative to the current folder.</summary>
			SBSP_RELATIVE = 0x1000,

			/// <summary>Browse to another folder with the same Windows Explorer window.</summary>
			SBSP_SAMEBROWSER = 0x0001,

			/// <summary>Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The navigate should allow ActiveX prompts.</summary>
			SBSP_TRUSTEDFORACTIVEX = 0x10000000,

			/// <summary>Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The new window is the result of a user initiated action. Trust the new window if it immediately attempts to download content.</summary>
			SBSP_TRUSTFIRSTDOWNLOAD = 0x01000000,

			/// <summary>Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The window is navigating to an untrusted, non-HTML file. If the user attempts to download the file, do not allow the download.</summary>
			SBSP_UNTRUSTEDFORDOWNLOAD = 0x02000000,

			/// <summary>Write no history of this navigation in the history Shell folder.</summary>
			SBSP_WRITENOHISTORY = 0x08000000
		}

		public enum SV2GV : int
		{
			SV2GV_CURRENTVIEW = -1,
			SV2GV_DEFAULTVIEW = -2,
		}

		/// <summary>Flags that specify details of the view being created.</summary>
		public enum SV3CVW3_FLAGS
		{
			/// <summary>The default view.</summary>
			SV3CVW3_DEFAULT = 0x00000000,
			/// <summary>In the case of an error, the view should fail silently rather than displaying a UI.</summary>
			SV3CVW3_NONINTERACTIVE = 0x00000001,
			/// <summary>The view mode set by IShellView3::CreateViewWindow3 overrides the saved view state.</summary>
			SV3CVW3_FORCEVIEWMODE = 0x00000002,
			/// <summary>Folder flags set by IShellView3::CreateViewWindow3 override the saved view state.</summary>
			SV3CVW3_FORCEFOLDERFLAGS = 0x00000004,
		}

		[Flags]
		public enum SVSIF : uint
		{
			/// <summary>Deselect the item.</summary>
			SVSI_DESELECT = 0x00000000,
			/// <summary>Select the item.</summary>
			SVSI_SELECT = 0x00000001,
			/// <summary>Put the name of the item into rename mode. This value includes SVSI_SELECT.</summary>
			SVSI_EDIT = 0x00000003,
			/// <summary>Deselect all but the selected item. If the item parameter is NULL, deselect all items.</summary>
			SVSI_DESELECTOTHERS = 0x00000004,
			/// <summary>In the case of a folder that cannot display all of its contents on one screen, display the portion that contains the selected item.</summary>
			SVSI_ENSUREVISIBLE = 0x00000008,
			/// <summary>Give the selected item the focus when multiple items are selected, placing the item first in any list of the collection returned by a method.</summary>
			SVSI_FOCUSED = 0x00000010,
			/// <summary>Convert the input point from screen coordinates to the list-view client coordinates.</summary>
			SVSI_TRANSLATEPT = 0x00000020,
			/// <summary>Mark the item so that it can be queried using IFolderView::GetSelectionMarkedItem.</summary>
			SVSI_SELECTIONMARK = 0x00000040,
			/// <summary>Allows the window's default view to position the item. In most cases, this will place the item in the first available position. However, if the call comes during the processing of a mouse-positioned context menu, the position of the context menu is used to position the item.</summary>
			SVSI_POSITIONITEM = 0x00000080,
			/// <summary>The item should be checked. This flag is used with items in views where the checked mode is supported.</summary>
			SVSI_CHECK = 0x00000100,
			/// <summary>The second check state when the view is in tri-check mode, in which there are three values for the checked state. You can indicate tri-check mode by specifying FWF_TRICHECKSELECT in IFolderView2::SetCurrentFolderFlags. The 3 states for FWF_TRICHECKSELECT are unchecked, SVSI_CHECK and SVSI_CHECK2.</summary>
			SVSI_CHECK2 = 0x00000200,
			/// <summary>Selects the item and marks it as selected by the keyboard. This value includes SVSI_SELECT.</summary>
			SVSI_KEYBOARDSELECT = 0x00000401,
			/// <summary>An operation to select or focus an item should not also set focus on the view itself.</summary>
			SVSI_NOTAKEFOCUS = 0x40000000,
		}

		/// <summary>Flag specifying the activation state of the window.</summary>
		public enum SVUIA : uint
		{
			/// <summary>Windows Explorer is about to destroy the Shell view window. The Shell view should remove all extended user interfaces. These are typically merged menus and merged modeless pop-up windows.</summary>
			SVUIA_DEACTIVATE = 0,
			/// <summary>The Shell view is losing the input focus, or it has just been created without the input focus. The Shell view should be able to set menu items appropriate for the nonfocused state. This means no selection-specific items should be added.</summary>
			SVUIA_ACTIVATE_NOFOCUS = 1,
			/// <summary>Windows Explorer has just created the view window with the input focus. This means the Shell view should be able to set menu items appropriate for the focused state.</summary>
			SVUIA_ACTIVATE_FOCUS = 2,
			/// <summary>The Shell view is active without focus. This flag is only used when UIActivate is exposed through the IShellView2 interface.</summary>
			SVUIA_INPLACEACTIVATE = 3
		}

		[ComImport, Guid("000214E2-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellBrowser : IOleWindow
		{
			/// <summary>Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).</summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			new IntPtr GetWindow();
			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
			void InsertMenusSB(IntPtr hmenuShared, ref OLEMENUGROUPWIDTHS lpMenuWidths);
			void SetMenuSB(IntPtr hmenuShared, IntPtr holemenuRes, IntPtr hwndActiveObject);
			void RemoveMenusSB(IntPtr hmenuShared);
			void SetStatusTextSB([MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);
			void EnableModelessSB([MarshalAs(UnmanagedType.Bool)] bool fEnable);
			void TranslateAcceleratorSB(ref MSG pmsg, ushort wID);
			void BrowseObject(PIDL pidl, SBSP wFlags);
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetViewStateStream(STGM grfMode);
			IntPtr GetControlWindow(FCW id);
			IntPtr SendControlMsg(FCW id, uint uMsg, IntPtr wParam, IntPtr lParam);
			void QueryActiveShellView(ref IShellView ppshv);
			void OnViewWindowActive(IShellView ppshv);
			void SetToolbarItems(IntPtr lpButtons, uint nButtons, FCT uFlags);
		}

		/// <summary>Exposes methods that present a view in the Windows Explorer or folder windows.</summary>
		/// <seealso cref="Vanara.PInvoke.Ole32.IOleWindow"/>
		[ComImport, Guid("000214E3-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellView : IOleWindow
		{
			/// <summary>Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).</summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			new IntPtr GetWindow();
			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
			/// <summary>Translates keyboard shortcut (accelerator) key strokes when a namespace extension's view has the focus.</summary>
			/// <param name="lpmsg">The address of the message to be translated.</param>
			void TranslateAccelerator(ref MSG lpmsg);
			void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool enable);
			/// <summary>
			/// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For example, if the TAB
			/// key is pressed when the tree has the focus, the view should be given the focus.
			/// </summary>
			/// <param name="uState">Flag specifying the activation state of the window.</param>
			void UIActivate(SVUIA uState);
			/// <summary>Refreshes the view's contents in response to user input.</summary>
			void Refresh();
			/// <summary>Creates a view window. This can be either the right pane of Windows Explorer or the client window of a folder window.</summary>
			/// <param name="psvPrevious">
			/// The address of the IShellView interface of the view window being exited. Views can use this parameter to communicate with a previous view of the
			/// same implementation. This interface can be used to optimize browsing between like views. This pointer may be NULL.
			/// </param>
			/// <param name="pfs">The address of a FOLDERSETTINGS structure. The view should use this when creating its view.</param>
			/// <param name="psb">
			/// The address of the current instance of the IShellBrowser interface. The view should call this interface's AddRef method and keep the interface
			/// pointer to allow communication with the Windows Explorer window.
			/// </param>
			/// <param name="prcView">The dimensions of the new view, in client coordinates.</param>
			/// <returns>The address of the window handle being created.</returns>
			IntPtr CreateViewWindow(IShellView psvPrevious, ref FOLDERSETTINGS pfs, IShellBrowser psb, ref RECT prcView);
			/// <summary>Destroys the view window.</summary>
			void DestroyViewWindow();
			/// <summary>Gets the current information.</summary>
			/// <returns>A FOLDERSETTINGS structure to receive the settings.</returns>
			FOLDERSETTINGS GetCurrentInfo();
			/// <summary>Allows the view to add pages to the Options property sheet from the View menu.</summary>
			/// <param name="dwReserved">Reserved.</param>
			/// <param name="lpfn">The address of the callback function used to add the pages.</param>
			/// <param name="lparam">A value that must be passed as the callback function's lparam parameter.</param>
			void AddPropertySheetPages(uint dwReserved, [In] AddPropSheetPageProc lpfn, [In] IntPtr lparam);
			/// <summary>Saves the Shell's view settings so the current state can be restored during a subsequent browsing session.</summary>
			void SaveViewState();
			/// <summary>Changes the selection state of one or more items within the Shell view window.</summary>
			/// <param name="pidlItem">The address of the ITEMIDLIST structure.</param>
			/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			void SelectItem(PIDL pidlItem, SVSIF uFlags);
			/// <summary>Gets an interface that refers to data presented in the view.</summary>
			/// <param name="uItem">The constants that refer to an aspect of the view.</param>
			/// <param name="riid">The identifier of the COM interface being requested.</param>
			/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetItemObject(SVGIO uItem, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
		}
		/// <summary>Extends the capabilities of IShellView.</summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IShellView"/>
		[ComImport, Guid("88E39E80-3578-11CF-AE69-08002B2E1262"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellView2 : IShellView
		{
			new IntPtr GetWindow();
			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
			/// <summary>Translates keyboard shortcut (accelerator) key strokes when a namespace extension's view has the focus.</summary>
			/// <param name="lpmsg">The address of the message to be translated.</param>
			new void TranslateAccelerator(ref MSG lpmsg);
			new void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool enable);
			/// <summary>
			/// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For example, if the TAB
			/// key is pressed when the tree has the focus, the view should be given the focus.
			/// </summary>
			/// <param name="uState">Flag specifying the activation state of the window.</param>
			new void UIActivate(SVUIA uState);
			/// <summary>Refreshes the view's contents in response to user input.</summary>
			new void Refresh();
			/// <summary>Creates a view window. This can be either the right pane of Windows Explorer or the client window of a folder window.</summary>
			/// <param name="psvPrevious">
			/// The address of the IShellView interface of the view window being exited. Views can use this parameter to communicate with a previous view of the
			/// same implementation. This interface can be used to optimize browsing between like views. This pointer may be NULL.
			/// </param>
			/// <param name="pfs">The address of a FOLDERSETTINGS structure. The view should use this when creating its view.</param>
			/// <param name="psb">
			/// The address of the current instance of the IShellBrowser interface. The view should call this interface's AddRef method and keep the interface
			/// pointer to allow communication with the Windows Explorer window.
			/// </param>
			/// <param name="prcView">The dimensions of the new view, in client coordinates.</param>
			/// <returns>The address of the window handle being created.</returns>
			new IntPtr CreateViewWindow(IShellView psvPrevious, ref FOLDERSETTINGS pfs, IShellBrowser psb, ref RECT prcView);
			/// <summary>Destroys the view window.</summary>
			new void DestroyViewWindow();
			/// <summary>Gets the current information.</summary>
			/// <returns>A FOLDERSETTINGS structure to receive the settings.</returns>
			new FOLDERSETTINGS GetCurrentInfo();
			/// <summary>Allows the view to add pages to the Options property sheet from the View menu.</summary>
			/// <param name="dwReserved">Reserved.</param>
			/// <param name="lpfn">The address of the callback function used to add the pages.</param>
			/// <param name="lparam">A value that must be passed as the callback function's lparam parameter.</param>
			new void AddPropertySheetPages(uint dwReserved, [In] AddPropSheetPageProc lpfn, [In] IntPtr lparam);
			/// <summary>Saves the Shell's view settings so the current state can be restored during a subsequent browsing session.</summary>
			new void SaveViewState();
			/// <summary>Changes the selection state of one or more items within the Shell view window.</summary>
			/// <param name="pidlItem">The address of the ITEMIDLIST structure.</param>
			/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			new void SelectItem(PIDL pidlItem, SVSIF uFlags);
			/// <summary>Gets an interface that refers to data presented in the view.</summary>
			/// <param name="uItem">The constants that refer to an aspect of the view.</param>
			/// <param name="riid">The identifier of the COM interface being requested.</param>
			/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetItemObject(SVGIO uItem, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
			/// <summary>Requests the current or default Shell view, together with all other valid view identifiers (VIDs) supported by this implementation of IShellView2.</summary>
			/// <param name="pvid">A pointer to the GUID of the requested view.</param>
			/// <param name="uView">The type of view requested.</param>
			void GetView([MarshalAs(UnmanagedType.LPStruct)] out Guid pvid, SV2GV uView);
			/// <summary>Used to request the creation of a new Shell view window. It can be either the right pane of Windows Explorer or the client window of a folder window.</summary>
			/// <param name="lpParams">A pointer to an SV2CVW2_PARAMS structure that defines the new view window.</param>
			void CreateViewWindow(ref SV2CVW2_PARAMS lpParams);
			/// <summary>Used to change an item's identifier.</summary>
			/// <param name="pidlNew">A pointer to an ITEMIDLIST structure. The current identifier is passed in and is replaced by the new one.</param>
			void HandleRename(PIDL pidlNew);
			/// <summary>Selects and positions an item in a Shell View.</summary>
			/// <param name="pidlItem">A pointer to an ITEMIDLIST structure that uniquely identifies the item of interest.</param>
			/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			/// <param name="point">A pointer to a POINT structure containing the new position.</param>
			void SelectAndPositionItem(PIDL pidlItem, SVSIF flags, ref System.Drawing.Point point);
		}

		/// <summary>Extends the capabilities of IShellView2 by providing a method to replace IShellView2::CreateViewWindow2.</summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IShellView2"/>
		[ComImport(), Guid("ec39fa88-f8af-41c5-8421-38bed28f4673"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellView3 : IShellView2
		{
			new IntPtr GetWindow();
			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
			/// <summary>Translates keyboard shortcut (accelerator) key strokes when a namespace extension's view has the focus.</summary>
			/// <param name="lpmsg">The address of the message to be translated.</param>
			new void TranslateAccelerator(ref MSG lpmsg);
			new void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool enable);
			/// <summary>
			/// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For example, if the TAB
			/// key is pressed when the tree has the focus, the view should be given the focus.
			/// </summary>
			/// <param name="uState">Flag specifying the activation state of the window.</param>
			new void UIActivate(SVUIA uState);
			/// <summary>Refreshes the view's contents in response to user input.</summary>
			new void Refresh();
			/// <summary>Creates a view window. This can be either the right pane of Windows Explorer or the client window of a folder window.</summary>
			/// <param name="psvPrevious">
			/// The address of the IShellView interface of the view window being exited. Views can use this parameter to communicate with a previous view of the
			/// same implementation. This interface can be used to optimize browsing between like views. This pointer may be NULL.
			/// </param>
			/// <param name="pfs">The address of a FOLDERSETTINGS structure. The view should use this when creating its view.</param>
			/// <param name="psb">
			/// The address of the current instance of the IShellBrowser interface. The view should call this interface's AddRef method and keep the interface
			/// pointer to allow communication with the Windows Explorer window.
			/// </param>
			/// <param name="prcView">The dimensions of the new view, in client coordinates.</param>
			/// <returns>The address of the window handle being created.</returns>
			new IntPtr CreateViewWindow(IShellView psvPrevious, ref FOLDERSETTINGS pfs, IShellBrowser psb, ref RECT prcView);
			/// <summary>Destroys the view window.</summary>
			new void DestroyViewWindow();
			/// <summary>Gets the current information.</summary>
			/// <returns>A FOLDERSETTINGS structure to receive the settings.</returns>
			new FOLDERSETTINGS GetCurrentInfo();
			/// <summary>Allows the view to add pages to the Options property sheet from the View menu.</summary>
			/// <param name="dwReserved">Reserved.</param>
			/// <param name="lpfn">The address of the callback function used to add the pages.</param>
			/// <param name="lparam">A value that must be passed as the callback function's lparam parameter.</param>
			new void AddPropertySheetPages(uint dwReserved, [In] AddPropSheetPageProc lpfn, [In] IntPtr lparam);
			/// <summary>Saves the Shell's view settings so the current state can be restored during a subsequent browsing session.</summary>
			new void SaveViewState();
			/// <summary>Changes the selection state of one or more items within the Shell view window.</summary>
			/// <param name="pidlItem">The address of the ITEMIDLIST structure.</param>
			/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			new void SelectItem(PIDL pidlItem, SVSIF uFlags);
			/// <summary>Gets an interface that refers to data presented in the view.</summary>
			/// <param name="uItem">The constants that refer to an aspect of the view.</param>
			/// <param name="riid">The identifier of the COM interface being requested.</param>
			/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetItemObject(SVGIO uItem, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
			/// <summary>Requests the current or default Shell view, together with all other valid view identifiers (VIDs) supported by this implementation of IShellView2.</summary>
			/// <param name="pvid">A pointer to the GUID of the requested view.</param>
			/// <param name="uView">The type of view requested.</param>
			new void GetView([MarshalAs(UnmanagedType.LPStruct)] out Guid pvid, SV2GV uView);
			/// <summary>Used to request the creation of a new Shell view window. It can be either the right pane of Windows Explorer or the client window of a folder window.</summary>
			/// <param name="lpParams">A pointer to an SV2CVW2_PARAMS structure that defines the new view window.</param>
			new void CreateViewWindow(ref SV2CVW2_PARAMS lpParams);
			/// <summary>Used to change an item's identifier.</summary>
			/// <param name="pidlNew">A pointer to an ITEMIDLIST structure. The current identifier is passed in and is replaced by the new one.</param>
			new void HandleRename(PIDL pidlNew);
			/// <summary>Selects and positions an item in a Shell View.</summary>
			/// <param name="pidlItem">A pointer to an ITEMIDLIST structure that uniquely identifies the item of interest.</param>
			/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
			/// <param name="point">A pointer to a POINT structure containing the new position.</param>
			new void SelectAndPositionItem(PIDL pidlItem, SVSIF flags, ref System.Drawing.Point point);
			/// <summary>Requests the creation of a new Shell view window. The view can be either the right pane of Windows Explorer or the client window of a folder window. This method replaces CreateViewWindow2.</summary>
			/// <param name="psbOwner">A pointer to an IShellBrowser interface to provide namespace extension services.</param>
			/// <param name="psvPrevious">A pointer to an IShellView interface that represents the previous view in the Windows Explorer or folder window.</param>
			/// <param name="dwViewFlags">Flags that specify details of the view being created.</param>
			/// <param name="dwMask">A bitwise mask that specifies which folder options specified in dwFlags are to be used.</param>
			/// <param name="dwFlags">A bitwise value that contains the folder options, as FOLDERFLAGS, to use in the new view.</param>
			/// <param name="fvMode">A bitwise value that contains the folder view mode options, as FOLDERVIEWMODE, to use in the new view.</param>
			/// <param name="pvid">A pointer to Shell view ID as a GUID.</param>
			/// <param name="prcView">A pointer to a RECT structure that provides the dimensions of the view window.</param>
			/// <returns>A value that receives a pointer to the handle of the new Shell view window.</returns>
			IntPtr CreateViewWindow3(IShellBrowser psbOwner, IShellView psvPrevious, SV3CVW3_FLAGS dwViewFlags, FOLDERFLAGS dwMask,
				FOLDERFLAGS dwFlags, FOLDERVIEWMODE fvMode, [MarshalAs(UnmanagedType.LPStruct)] Guid pvid, ref RECT prcView);
		}

		/// <summary>Contains folder view information.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct FOLDERSETTINGS
		{
			/// <summary>Folder view mode.</summary>
			public FOLDERVIEWMODE ViewMode;
			/// <summary>A set of flags that indicate the options for the folder.</summary>
			public FOLDERFLAGS fFlags;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct SV2CVW2_PARAMS
		{
			public uint cbSize;
			public IShellView psvPrev;  // IShellView*
			public IntPtr pfs;      // FOLDERSETTINGS*
			public IShellBrowser psbOwner; // IShellBrowser*
			public IntPtr prcView;  // RECT*
			public IntPtr pvid;     // GUID*
			public IntPtr hwndView; // HWND

			// TODO: ctor that grabs all but last two fields
		}
	}
}