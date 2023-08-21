using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Used with method IBrowserFrameOptions::GetFrameOptions.</summary>
	/// <remarks>These constants are defined in the Shobjidl.h file beginning in Windows Vista.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-_browserframeoptions typedef enum
	// _BROWSERFRAMEOPTIONS { BFO_NONE, BFO_BROWSER_PERSIST_SETTINGS, BFO_RENAME_FOLDER_OPTIONS_TOINTERNET, BFO_BOTH_OPTIONS,
	// BIF_PREFER_INTERNET_SHORTCUT, BFO_BROWSE_NO_IN_NEW_PROCESS, BFO_ENABLE_HYPERLINK_TRACKING, BFO_USE_IE_OFFLINE_SUPPORT,
	// BFO_SUBSTITUE_INTERNET_START_PAGE, BFO_USE_IE_LOGOBANDING, BFO_ADD_IE_TOCAPTIONBAR, BFO_USE_DIALUP_REF, BFO_USE_IE_TOOLBAR,
	// BFO_NO_PARENT_FOLDER_SUPPORT, BFO_NO_REOPEN_NEXT_RESTART, BFO_GO_HOME_PAGE, BFO_PREFER_IEPROCESS, BFO_SHOW_NAVIGATION_CANCELLED,
	// BFO_USE_IE_STATUSBAR, BFO_QUERY_ALL } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core._BROWSERFRAMEOPTIONS")]
	[Flags]
	public enum BROWSERFRAMEOPTIONS : uint
	{
		/// <summary>Do nothing.</summary>
		BFO_NONE = 0,

		/// <summary>Use the browser stream for this item. (Same window position as IE browser windows.)</summary>
		BFO_BROWSER_PERSIST_SETTINGS = 0x1,

		/// <summary>Rename Folder Options to Internet Options in the Tools or View menu.</summary>
		BFO_RENAME_FOLDER_OPTIONS_TOINTERNET = 0x2,

		/// <summary>Keep both Folder Options and Internet Options in the Tools or View menu.</summary>
		BFO_BOTH_OPTIONS = 0x4,

		/// <summary>This namespace extension prefers a .url shortcut over a .lnk shortcut.</summary>
		BIF_PREFER_INTERNET_SHORTCUT = 0x8,

		/// <summary>Do not use "Browse in New Process" by invoking a shortcut.</summary>
		BFO_BROWSE_NO_IN_NEW_PROCESS = 0x10,

		/// <summary>Track display name to determine when hyperlinks should be tagged as previously used.</summary>
		BFO_ENABLE_HYPERLINK_TRACKING = 0x20,

		/// <summary>Use Internet Explorer's offline support.</summary>
		BFO_USE_IE_OFFLINE_SUPPORT = 0x40,

		/// <summary>Use Start Page support for this namespace extension.</summary>
		BFO_SUBSTITUE_INTERNET_START_PAGE = 0x80,

		/// <summary>Use the Brand block in the Toolbar.</summary>
		BFO_USE_IE_LOGOBANDING = 0x100,

		/// <summary>Append to display name in the caption bar.</summary>
		BFO_ADD_IE_TOCAPTIONBAR = 0x200,

		/// <summary>
		/// Reference the DialUp reference count while the browser is navigated to this location. This will also enable the ICW and
		/// Software update.
		/// </summary>
		BFO_USE_DIALUP_REF = 0x400,

		/// <summary>Use the Internet Explorer toolbar.</summary>
		BFO_USE_IE_TOOLBAR = 0x800,

		/// <summary>
		/// Disable navigation to parent folders. Used for the button that navigates to parent folder or the View.GoTo.ParentFolder feature.
		/// </summary>
		BFO_NO_PARENT_FOLDER_SUPPORT = 0x1000,

		/// <summary>
		/// Browser windows are not reopened after a reboot of the system, regardless of whether they were open before the reboot. Use
		/// the same behavior for the namespace extension.
		/// </summary>
		BFO_NO_REOPEN_NEXT_RESTART = 0x2000,

		/// <summary>Add Home Page to menu (Go).</summary>
		BFO_GO_HOME_PAGE = 0x4000,

		/// <summary>Prefer use of Iexplore.exe over Explorer.exe.</summary>
		BFO_PREFER_IEPROCESS = 0x8000,

		/// <summary>If navigation is terminated, show the Action Canceled HTML page.</summary>
		BFO_SHOW_NAVIGATION_CANCELLED = 0x10000,

		/// <summary>Use the persisted Internet Explorer status bar settings.</summary>
		BFO_USE_IE_STATUSBAR = 0x20000,

		/// <summary>Return all values.</summary>
		BFO_QUERY_ALL = 0xffffffff,
	}

	/// <summary>Flags specifying where the toolbar buttons should go.</summary>
	[PInvokeData("shobjidl.h")]
	[Flags]
	public enum FCT : uint
	{
		/// <summary>
		/// Merge the toolbar items instead of replacing all of the buttons with those provided by the view. This is the recommended choice.
		/// </summary>
		FCT_MERGE = 0x0001,

		/// <summary>Not implemented.</summary>
		FCT_CONFIGABLE = 0x0002,

		/// <summary>Add at the right side of the toolbar.</summary>
		FCT_ADDTOEND = 0x0004,
	}

	/// <summary>
	/// A value that indicates the frame control to show or hide. One of the following values as defined in Shobjidl.h or -1 for
	/// fullscreen/kiosk mode.
	/// </summary>
	[PInvokeData("shobjidl.h")]
	[Flags]
	public enum FCW : uint
	{
		/// <summary>The browser's media bar.</summary>
		FCW_INTERNETBAR = 0x0006,

		/// <summary>The browser's progress bar.</summary>
		FCW_PROGRESS = 0x0008,

		/// <summary>The browser's status bar.</summary>
		FCW_STATUS = 0x0001,

		/// <summary>The browser's toolbar.</summary>
		FCW_TOOLBAR = 0x0002,

		/// <summary>The browser's tree view.</summary>
		FCW_TREE = 0x0003,
	}

	/// <summary>Folder view flags.</summary>
	[PInvokeData("shobjidl.h")]
	[Flags]
	public enum FOLDERFLAGS : uint
	{
		/// <summary>Windows 7 and later. No special view options.</summary>
		FWF_NONE = 0x00000000,

		/// <summary>
		/// Automatically arrange the elements in the view. This implies LVS_AUTOARRANGE if the list-view control is used to implement
		/// the view.
		/// </summary>
		FWF_AUTOARRANGE = 0x00000001,

		/// <summary>Not supported.</summary>
		FWF_ABBREVIATEDNAMES = 0x00000002,

		/// <summary>Not supported.</summary>
		FWF_SNAPTOGRID = 0x00000004,

		/// <summary>Not supported.</summary>
		FWF_OWNERDATA = 0x00000008,

		/// <summary>Not supported.</summary>
		FWF_BESTFITWINDOW = 0x00000010,

		/// <summary>
		/// Make the folder behave like the desktop. This value applies only to the desktop and is not used for typical Shell folders.
		/// This flag implies FWF_NOCLIENTEDGE and FWF_NOSCROLL.
		/// </summary>
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

		/// <summary>
		/// The view should be left-aligned. This implies LVS_ALIGNLEFT if the list-view control is used to implement the view.
		/// </summary>
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

		/// <summary>
		/// Windows Vista and later. Do not re-enumerate the view (or drop the current contents of the view) when the view is refreshed.
		/// </summary>
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

		/// <summary>
		/// Windows Vista and later. When the view is in "tile view mode" the layout of a single item should be extended to the width of
		/// the view.
		/// </summary>
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

		/// <summary>
		/// Windows Vista and later. Ensure right-to-left reading layout in a right-to-left system. Without this flag, the view displays
		/// strings from left-to-right both on systems set to left-to-right and right-to-left reading layout, which ensures that file
		/// names display correctly.
		/// </summary>
		FWF_ALLOWRTLREADING = 0x80000000,
	}

	/// <summary>The view mode of a folder.</summary>
	[PInvokeData("shobjidl.h")]
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

	/// <summary>
	/// Used by methods of the IFolderViewOptions interface to activate Windows Vista options not supported by default in Windows 7 and
	/// later systems as well as deactivating new Windows 7 options.
	/// </summary>
	[PInvokeData("shobjidl.h")]
	[Flags]
	public enum FOLDERVIEWOPTIONS
	{
		/// <summary>Do not use any special options.</summary>
		FVO_DEFAULT = 0x00000000,

		/// <summary>
		/// Use the Windows Vista list view. This can be used to maintain continuity between systems so that users are presented with an
		/// expected view. At this time, setting this flag has the effective, though not literal, result of the application of the
		/// FVO_CUSTOMPOSITION and FVO_CUSTOMORDERING flags. However, this could change. Applications should be specific about the
		/// behaviors that they require. For instance, if an application requires custom positioning of its items, it should not rely on
		/// FVO_VISTALAYOUT to provide it, but instead explicitly apply the FVO_CUSTOMPOSITION flag.
		/// </summary>
		FVO_VISTALAYOUT = 0x00000001,

		/// <summary>
		/// Items require custom positioning within the space of the view. Those items are positioned to specific coordinates. This
		/// option is not active by default in the Windows 7 view.
		/// </summary>
		FVO_CUSTOMPOSITION = 0x00000002,

		/// <summary>
		/// Items require custom ordering within the view. This option is not active by default in the Windows 7 view. When it is
		/// active, the user can reorder the view by dragging items to their desired locations.
		/// </summary>
		FVO_CUSTOMORDERING = 0x00000004,

		/// <summary>
		/// Tiles and Details displays can contain hyperlinks. This option is not active by default in the Windows 7 view. When
		/// hyperlinks are displayed, they are updated to the Windows 7 view.
		/// </summary>
		FVO_SUPPORTHYPERLINKS = 0x00000008,

		/// <summary>
		/// Do not display animations in the view. This option was introduced in Windows 7 and is active by default in the Windows 7 view.
		/// </summary>
		FVO_NOANIMATIONS = 0x00000010,

		/// <summary>Do not show scroll tips. This option was introduced in Windows 7 and is active by default in the Windows 7 view.</summary>
		FVO_NOSCROLLTIPS = 0x00000020,
	}

	/// <summary>Flags specifying the folder to be browsed.</summary>
	[PInvokeData("shobjidl.h")]
	[Flags]
	public enum SBSP : uint
	{
		/// <summary>An absolute PIDL, relative to the desktop.</summary>
		SBSP_ABSOLUTE = 0x0000,

		/// <summary>Windows Vista and later. Navigate without the default behavior of setting focus into the new view.</summary>
		SBSP_ACTIVATE_NOFOCUS = 0x00080000,

		/// <summary>Enable auto-navigation.</summary>
		SBSP_ALLOW_AUTONAVIGATE = 0x00010000,

		/// <summary>
		/// Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The navigation was possibly initiated by a webpage with
		/// scripting code already present on the local system.
		/// </summary>
		SBSP_CALLERUNTRUSTED = 0x00800000,

		/// <summary>
		/// Windows 7 and later. Do not add a new entry to the travel log. When the user enters a search term in the search box and
		/// subsequently refines the query, the browser navigates forward but does not add an additional travel log entry.
		/// </summary>
		SBSP_CREATENOHISTORY = 0x00100000,

		/// <summary>
		/// Use default behavior, which respects the view option (the user setting to create new windows or to browse in place). In most
		/// cases, calling applications should use this flag.
		/// </summary>
		SBSP_DEFBROWSER = 0x0000,

		/// <summary>Use the current window.</summary>
		SBSP_DEFMODE = 0x0000,

		/// <summary>
		/// Specifies a folder tree for the new browse window. If the current browser does not match the SBSP_EXPLOREMODE of the browse
		/// object call, a new window is opened.
		/// </summary>
		SBSP_EXPLOREMODE = 0x0020,

		/// <summary>
		/// Windows Internet Explorer 7 and later. If allowed by current registry settings, give the browser a destination to navigate to.
		/// </summary>
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

		/// <summary>
		/// Specifies no folder tree for the new browse window. If the current browser does not match the SBSP_OPENMODE of the browse
		/// object call, a new window is opened.
		/// </summary>
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

		/// <summary>
		/// Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The new window is the result of a user initiated action. Trust
		/// the new window if it immediately attempts to download content.
		/// </summary>
		SBSP_TRUSTFIRSTDOWNLOAD = 0x01000000,

		/// <summary>
		/// Microsoft Internet Explorer 6 Service Pack 2 (SP2) and later. The window is navigating to an untrusted, non-HTML file. If
		/// the user attempts to download the file, do not allow the download.
		/// </summary>
		SBSP_UNTRUSTEDFORDOWNLOAD = 0x02000000,

		/// <summary>Write no history of this navigation in the history Shell folder.</summary>
		SBSP_WRITENOHISTORY = 0x08000000
	}

	/// <summary>Flags used by IShellFolderViewCB::MessageSFVCB.</summary>
	[PInvokeData("shobjidl.h")]
	public enum SFVM
	{
		/// <summary>Allows the callback object to provide a page to add to the Properties property sheet of the selected object.</summary>
		SFVM_ADDPROPERTYPAGES = 47,

		/// <summary>Allows the callback object to request that enumeration be done on a background thread.</summary>
		SFVM_BACKGROUNDENUM = 32,

		/// <summary>Notifies the callback object that background enumeration is complete.</summary>
		SFVM_BACKGROUNDENUMDONE = 48,

		/// <summary>
		/// Notifies the callback object that the user has clicked a column header to sort the list of objects in the folder view.
		/// </summary>
		SFVM_COLUMNCLICK = 24,

		/// <summary>Allows the callback object to specify the number of items in the folder view.</summary>
		SFVM_DEFITEMCOUNT = 26,

		/// <summary>Allows the callback object to specify the view mode.</summary>
		SFVM_DEFVIEWMODE = 27,

		/// <summary>Notifies the callback function that a drag-and-drop operation has begun.</summary>
		SFVM_DIDDRAGDROP = 36,

		/// <summary>Notifies the callback object that an event has taken place that affects one of its items.</summary>
		SFVM_FSNOTIFY = 14,

		/// <summary>
		/// Allows the callback object to specify that an animation be displayed while items are enumerated on a background thread.
		/// </summary>
		SFVM_GETANIMATION = 68,

		/// <summary>Allows the callback object to add buttons to the toolbar.</summary>
		SFVM_GETBUTTONINFO = 5,

		/// <summary>Allows the callback object to specify the buttons to be added to the toolbar.</summary>
		SFVM_GETBUTTONS = 6,

		/// <summary>
		/// Allows the callback object to provide the details for an item in a Shell folder. Use only if a call to GetDetailsOf fails
		/// and there is no GetDetailsOf method available to call.
		/// </summary>
		SFVM_GETDETAILSOF = 23,

		/// <summary>Allows the callback object to specify a help text string for menu items or toolbar buttons.</summary>
		SFVM_GETHELPTEXT = 3,

		/// <summary>Allows the callback object to specify a Help file and topic.</summary>
		SFVM_GETHELPTOPIC = 63,

		/// <summary>Specifies which events will generate an SFVM_FSNOTIFY message for a given item.</summary>
		SFVM_GETNOTIFY = 49,

		/// <summary>Allows the callback object to provide the status bar pane in which to display the Internet zone information.</summary>
		SFVM_GETPANE = 59,

		/// <summary>Allows the callback object to specify default sorting parameters.</summary>
		SFVM_GETSORTDEFAULTS = 53,

		/// <summary>Allows the callback object to specify a tooltip text string for menu items or toolbar buttons.</summary>
		SFVM_GETTOOLTIPTEXT = 4,

		/// <summary>Allows the callback object to provide Internet zone information.</summary>
		SFVM_GETZONE = 58,

		/// <summary>Allows the callback object to modify an item's context menu.</summary>
		SFVM_INITMENUPOPUP = 7,

		/// <summary>Notifies the callback object that one of its toolbar or menu commands has been invoked.</summary>
		SFVM_INVOKECOMMAND = 2,

		/// <summary>Allows the callback object to merge menu items into the Windows Explorer menus.</summary>
		SFVM_MERGEMENU = 1,

		/// <summary>Allows the callback object to register a folder so that changes to that folder's view will generate notifications.</summary>
		SFVM_QUERYFSNOTIFY = 25,

		/// <summary>
		/// Notifies the callback object of the container site. This is used only when IObjectWithSite::SetSite is not supported and
		/// SHCreateShellFolderViewEx is used.
		/// </summary>
		SFVM_SETISFV = 39,

		/// <summary>Notifies the callback object that the folder view has been resized.</summary>
		SFVM_SIZE = 57,

		/// <summary>
		/// Allows the callback object to specify the view's PIDL. This is used only when SetIDList and IPersistFolder2::GetCurFolder
		/// have failed.
		/// </summary>
		SFVM_THISIDLIST = 41,

		/// <summary>Notifies the callback object that a menu is being removed.</summary>
		SFVM_UNMERGEMENU = 28,

		/// <summary>Allows the callback object to request that the status bar be updated.</summary>
		SFVM_UPDATESTATUSBAR = 31,

		/// <summary>Notifies the callback object that the folder view window is being created.</summary>
		SFVM_WINDOWCREATED = 15,
	}

	/// <summary>The type of view requested.</summary>
	[PInvokeData("shobjidl.h")]
	public enum SV2GV : int
	{
		/// <summary>Current Shell view.</summary>
		SV2GV_CURRENTVIEW = -1,

		/// <summary>Default Shell view.</summary>
		SV2GV_DEFAULTVIEW = -2,
	}

	/// <summary>Flags that specify details of the view being created.</summary>
	[PInvokeData("shobjidl.h")]
	[Flags]
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

	/// <summary>Selection flags for IShellView objects.</summary>
	[Flags]
	[PInvokeData("shobjidl.h")]
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

		/// <summary>
		/// In the case of a folder that cannot display all of its contents on one screen, display the portion that contains the
		/// selected item.
		/// </summary>
		SVSI_ENSUREVISIBLE = 0x00000008,

		/// <summary>
		/// Give the selected item the focus when multiple items are selected, placing the item first in any list of the collection
		/// returned by a method.
		/// </summary>
		SVSI_FOCUSED = 0x00000010,

		/// <summary>Convert the input point from screen coordinates to the list-view client coordinates.</summary>
		SVSI_TRANSLATEPT = 0x00000020,

		/// <summary>Mark the item so that it can be queried using IFolderView::GetSelectionMarkedItem.</summary>
		SVSI_SELECTIONMARK = 0x00000040,

		/// <summary>
		/// Allows the window's default view to position the item. In most cases, this will place the item in the first available
		/// position. However, if the call comes during the processing of a mouse-positioned context menu, the position of the context
		/// menu is used to position the item.
		/// </summary>
		SVSI_POSITIONITEM = 0x00000080,

		/// <summary>The item should be checked. This flag is used with items in views where the checked mode is supported.</summary>
		SVSI_CHECK = 0x00000100,

		/// <summary>
		/// The second check state when the view is in tri-check mode, in which there are three values for the checked state. You can
		/// indicate tri-check mode by specifying FWF_TRICHECKSELECT in IFolderView2::SetCurrentFolderFlags. The 3 states for
		/// FWF_TRICHECKSELECT are unchecked, SVSI_CHECK and SVSI_CHECK2.
		/// </summary>
		SVSI_CHECK2 = 0x00000200,

		/// <summary>Selects the item and marks it as selected by the keyboard. This value includes SVSI_SELECT.</summary>
		SVSI_KEYBOARDSELECT = 0x00000401,

		/// <summary>An operation to select or focus an item should not also set focus on the view itself.</summary>
		SVSI_NOTAKEFOCUS = 0x40000000,
	}

	/// <summary>Flag specifying the activation state of the window.</summary>
	[PInvokeData("shobjidl.h")]
	public enum SVUIA : uint
	{
		/// <summary>
		/// Windows Explorer is about to destroy the Shell view window. The Shell view should remove all extended user interfaces. These
		/// are typically merged menus and merged modeless pop-up windows.
		/// </summary>
		SVUIA_DEACTIVATE = 0,

		/// <summary>
		/// The Shell view is losing the input focus, or it has just been created without the input focus. The Shell view should be able
		/// to set menu items appropriate for the nonfocused state. This means no selection-specific items should be added.
		/// </summary>
		SVUIA_ACTIVATE_NOFOCUS = 1,

		/// <summary>
		/// Windows Explorer has just created the view window with the input focus. This means the Shell view should be able to set menu
		/// items appropriate for the focused state.
		/// </summary>
		SVUIA_ACTIVATE_FOCUS = 2,

		/// <summary>
		/// The Shell view is active without focus. This flag is only used when UIActivate is exposed through the IShellView2 interface.
		/// </summary>
		SVUIA_INPLACEACTIVATE = 3
	}

	/// <summary>Allows a browser or host to ask IShellView what kind of view behavior is supported.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ibrowserframeoptions
	[ComImport, Guid("10DF43C8-1DBE-11d3-8B34-006097DF5BD4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IBrowserFrameOptions
	{
		/// <summary>Retrieves the available browser frame view options.</summary>
		/// <param name="dwMask">
		/// <para>Type: <c>BROWSERFRAMEOPTIONS</c></para>
		/// <para>Specifies the options requested as a bitwise combination of one or more of the constants of enumeration type BROWSERFRAMEOPTIONS.</para>
		/// </param>
		/// <param name="pdwOptions">
		/// <para>Type: <c>BROWSERFRAMEOPTIONS*</c></para>
		/// <para>
		/// When this method returns, contains the options that the view can enable (for example, IShellView ). This value is not
		/// optional and is always equal to, or a subset of, the options specified by dwMask.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If the method succeeds, the return value is S_OK and pdwOptions contains the subset of available view options. If the method
		/// fails, pdwOptions is set to BFO_NONE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ibrowserframeoptions-getframeoptions
		// HRESULT GetFrameOptions( BROWSERFRAMEOPTIONS dwMask, BROWSERFRAMEOPTIONS *pdwOptions );
		[PreserveSig]
		HRESULT GetFrameOptions([In] BROWSERFRAMEOPTIONS dwMask, out BROWSERFRAMEOPTIONS pdwOptions);
	}

	/// <summary>
	/// <para>Exposes methods that allow control of folder view options specific to the Windows 7 and later views.</para>
	/// </summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>
	/// An implementation of this interface is provided with Windows as part of CLSID_ExplorerBrowser and CLSID_ShellBrowser. Third
	/// parties do not implement this interface.
	/// </para>
	/// <para>When to Use</para>
	/// <para>
	/// By default, the Windows 7 item view does not support custom positioning, custom ordering, or hyperlinks, which were supported in
	/// the Windows Vista list view. Use this interface when you require those features of the older view. If, at some later time, the
	/// item view adds support for those features, these options will automatically use the newer view rather than continuing to revert
	/// to the older view as they currently do.
	/// </para>
	/// <para>Use this interface to turn off animation and scroll tip view options new to Windows 7.</para>
	/// <para>Use this interface to retrieve the current view settings for all of those options.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nn-shobjidl-ifolderviewoptions
	[PInvokeData("shobjidl.h", MSDNShortId = "4831e62c-45e4-435d-b926-0e140cbfb6fc", MinClient = PInvokeClient.Windows7)]
	[ComImport, Guid("3cc974d2-b302-4d36-ad3e-06d93f695d3f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFolderViewOptions
	{
		/// <summary>Sets specified options for the view.</summary>
		/// <param name="fvoMask">
		/// A bitmask made up of one or more of the FOLDERVIEWOPTIONS flags to indicate which options' are being changed. Values in
		/// fvoFlags not included in this mask are ignored.
		/// </param>
		/// <param name="fvoFlags">
		/// A bitmask that contains the new values for the options specified in fvoMask. To enable an option, the bitmask should include
		/// the FOLDERVIEWOPTIONS flag for that option. To disable an option, the bit used for that FOLDERVIEWOPTIONS flag should be 0.
		/// </param>
		void SetFolderViewOptions(FOLDERVIEWOPTIONS fvoMask, FOLDERVIEWOPTIONS fvoFlags);

		/// <summary>Retrieves the current set of options for the view.</summary>
		/// <returns>
		/// A bitmask that, when this method returns successfully, receives the FOLDERVIEWOPTIONS values that are currently set.
		/// </returns>
		FOLDERVIEWOPTIONS GetFolderViewOptions();
	}

	/// <summary>
	/// Implemented by hosts of Shell views (objects that implement <c>IShellView</c>). Exposes methods that provide services for the
	/// view it is hosting and other objects that run in the context of the Explorer window.
	/// </summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb775123(v=vs.85).aspx
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb775123")]
	[ComImport, Guid("000214E2-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellBrowser : IOleWindow
	{
		/// <summary>
		/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
		/// </summary>
		/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
		/// <returns>
		/// This method returns S_OK on success. Other possible return values include the following.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>The object is windowless.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Window</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>Frame</description>
		/// <description>The outermost main window where the container application's main menu resides.</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// <description>The window that displays the compound document containing the embedded object to the user.</description>
		/// </item>
		/// <item>
		/// <description>Pane</description>
		/// <description>
		/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Parent</description>
		/// <description>
		/// The container window that contains that object's view. The object application installs its window as a child of this window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>In-place</description>
		/// <description>
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
		/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
		/// parent windows.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT GetWindow(out HWND phwnd);

		/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
		/// name="fEnterMode"/>. Other possible return values include the following. <br/>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Applications can invoke context-sensitive help when the user:</para>
		/// <list type="bullet">
		/// <item>presses SHIFT+F1, then clicks a topic</item>
		/// <item>presses F1 when a menu item is selected</item>
		/// </list>
		/// <para>
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		/// <summary>
		/// Allows the container to insert its menu groups into the composite menu that is displayed when an extended namespace is being
		/// viewed or used.
		/// </summary>
		/// <param name="hmenuShared">A handle to an empty menu.</param>
		/// <param name="lpMenuWidths">
		/// The address of an OLEMENUGROUPWIDTHS array of six LONG values. The container fills in elements 0, 2, and 4 to reflect the
		/// number of menu elements it provided in the File, View, and Window menu groups.
		/// </param>
		[PreserveSig]
		HRESULT InsertMenusSB(HMENU hmenuShared, ref OLEMENUGROUPWIDTHS lpMenuWidths);

		/// <summary>Installs the composite menu in the view window.</summary>
		/// <param name="hmenuShared">
		/// A handle to the composite menu constructed by calls to IShellBrowser::InsertMenusSB and the InsertMenu function.
		/// </param>
		/// <param name="holemenuRes"></param>
		/// <param name="hwndActiveObject">The view's window handle.</param>
		[PreserveSig]
		HRESULT SetMenuSB(HMENU hmenuShared, IntPtr holemenuRes, HWND hwndActiveObject);

		/// <summary>
		/// Permits the container to remove any of its menu elements from the in-place composite menu and to free all associated resources.
		/// </summary>
		/// <param name="hmenuShared">
		/// A handle to the in-place composite menu that was constructed by calls to IShellBrowser::InsertMenusSB and the InsertMenu function.
		/// </param>
		[PreserveSig]
		HRESULT RemoveMenusSB(HMENU hmenuShared);

		/// <summary>Sets and displays status text about the in-place object in the container's frame-window status bar.</summary>
		/// <param name="pszStatusText">A pointer to a null-terminated character string that contains the message to display.</param>
		[PreserveSig]
		HRESULT SetStatusTextSB([MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

		/// <summary>Tells Windows Explorer to enable or disable its modeless dialog boxes.</summary>
		/// <param name="fEnable">
		/// Specifies whether the modeless dialog boxes are to be enabled or disabled. If this parameter is nonzero, modeless dialog
		/// boxes are enabled. If this parameter is zero, modeless dialog boxes are disabled.
		/// </param>
		[PreserveSig]
		HRESULT EnableModelessSB([MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Translates accelerator keystrokes intended for the browser's frame while the view is active.</summary>
		/// <param name="pmsg">The address of an MSG structure containing the keystroke message.</param>
		/// <param name="wID">
		/// The command identifier value corresponding to the keystroke in the container-provided accelerator table. Containers should
		/// use this value instead of translating again.
		/// </param>
		[PreserveSig]
		HRESULT TranslateAcceleratorSB(ref MSG pmsg, ushort wID);

		/// <summary>Informs Windows Explorer to browse to another folder.</summary>
		/// <param name="pidl">
		/// The address of an ITEMIDLIST (item identifier list) structure that specifies an object's location. This value is dependent
		/// on the flag or flags set in the wFlags parameter.
		/// </param>
		/// <param name="wFlags">Flags specifying the folder to be browsed.</param>
		[PreserveSig]
		HRESULT BrowseObject(IntPtr pidl, SBSP wFlags);

		/// <summary>Gets an IStream interface that can be used for storage of view-specific state information.</summary>
		/// <param name="grfMode">Read/write access of the IStream interface.</param>
		/// <param name="ppStrm">The address that receives the IStream interface pointer.</param>
		[PreserveSig]
		HRESULT GetViewStateStream(STGM grfMode, [MarshalAs(UnmanagedType.Interface), MaybeNull] out IStream ppStrm);

		/// <summary>Gets the window handle to a browser control.</summary>
		/// <param name="id">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The control handle that is being requested. This parameter can be one of the following values:</para>
		/// <para>FCW_TOOLBAR</para>
		/// <para>Retrieves the window handle to the browser's toolbar.</para>
		/// <para>FCW_STATUS</para>
		/// <para>Retrieves the window handle to the browser's status bar.</para>
		/// <para>FCW_TREE</para>
		/// <para>Retrieves the window handle to the browser's tree view.</para>
		/// <para>FCW_PROGRESS</para>
		/// <para>Retrieves the window handle to the browser's progress bar.</para>
		/// </param>
		/// <param name="phwnd">
		/// <para>Type: <c>HWND*</c></para>
		/// <para>The address of the window handle to the Windows Explorer control.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or a COM-defined error value otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetControlWindow</c> is used so views can directly manipulate the browser's controls. <c>FCW_TREE</c> should be used only to
		/// determine if the tree is present.
		/// </para>
		/// <para>Notes to Calling Applications</para>
		/// <para>
		/// <c>GetControlWindow</c> is used to manipulate and test the state of the control windows. Do not send messages directly to these
		/// controls; instead, use IShellBrowser::SendControlMsg. Be prepared for this method to return <c>NULL</c>. Later versions of
		/// Windows Explorer may not include a toolbar, status bar, or tree window.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para><c>GetControlWindow</c> returns the window handle to these controls if they exist in your implementation.</para>
		/// <para>See also IShellBrowser</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellbrowser-getcontrolwindow
		[PreserveSig]
		HRESULT GetControlWindow(FCW id, out HWND phwnd);

		/// <summary>Sends control messages to either the toolbar or the status bar in a Windows Explorer window.</summary>
		/// <param name="id">
		/// <para>Type: <c>UINT</c></para>
		/// <para>An identifier for either a toolbar (<c>FCW_TOOLBAR</c>) or for a status bar window (<c>FCW_STATUS</c>).</para>
		/// </param>
		/// <param name="uMsg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent to the control.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The value depends on the message specified in the uMsg parameter.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The value depends on the message specified in the uMsg parameter.</para>
		/// </param>
		/// <param name="pret">
		/// <para>Type: <c>LRESULT*</c></para>
		/// <para>The address of the return value of the SendMessage function.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns <c>S_OK</c> if successful, or a COM-defined error value otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>Refer to the Common Controls documentation for more information on the messages that can be sent to the toolbar or status bar control.</para>
		/// <para>Notes to Calling Applications</para>
		/// <para>Use of this call requires diligent attention, because leaving either the status bar or toolbar in an inappropriate state will affect the performance of Windows Explorer.</para>
		/// <para>Notes to Implementers</para>
		/// <para>If your Windows Explorer does not have these controls, you can return <c>E_NOTIMPL</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellbrowser-sendcontrolmsg
		[PreserveSig]
		HRESULT SendControlMsg(FCW id, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr pret);

		/// <summary>Retrieves the currently active (displayed) Shell view object.</summary>
		/// <param name="ppshv">
		/// <para>Type: <c>IShellView**</c></para>
		/// <para>The address of the pointer to the currently active Shell view object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or a COM-defined error value otherwise.</para>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Calling Applications</para>
		/// <para>Because the IShellBrowser interface can host several Shell views simultaneously, this method provides an easy way to determine the active Shell view object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellbrowser-queryactiveshellview
		[PreserveSig]
		HRESULT QueryActiveShellView([MaybeNull] out IShellView ppshv);

		/// <summary>Called by the Shell view when the view window or one of its child windows gets the focus or becomes active.</summary>
		/// <param name="ppshv">Address of the view object's IShellView pointer.</param>
		[PreserveSig]
		HRESULT OnViewWindowActive(IShellView ppshv);

		/// <summary>
		/// <note type="note">This method has no effect on Windows Vista or later operating systems.</note> Adds toolbar items to
		/// Windows Explorer's toolbar.
		/// </summary>
		/// <param name="lpButtons">The address of an array of TBBUTTON structures.</param>
		/// <param name="nButtons">The number of TBBUTTON structures in the lpButtons array.</param>
		/// <param name="uFlags">Flags specifying where the toolbar buttons should go.</param>
		[PreserveSig]
		HRESULT SetToolbarItems([Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TBBUTTON[]? lpButtons, uint nButtons, FCT uFlags);
	}

	/// <summary>
	/// Exposes a method that allows communication between Windows Explorer and a folder view implemented using the system folder view
	/// object (the <c>IShellView</c> object returned through <c>SHCreateShellFolderView</c>) so that the folder view can be notified of
	/// events and modify its view accordingly.
	/// </summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/bb774967(v=vs.85).aspx
	[PInvokeData("Shlobj.h", MSDNShortId = "bb774967")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("2047E320-F2A9-11CE-AE65-08002B2E1262")]
	public interface IShellFolderViewCB
	{
		/// <summary>Allows communication between the system folder view object and a system folder view callback object.</summary>
		/// <param name="uMsg">One of the following notifications.</param>
		/// <param name="wParam">Additional information.</param>
		/// <param name="lParam">Additional information.</param>
		/// <param name="plResult">Additional information.</param>
		/// <returns>S_OK if the message was handled, E_NOTIMPL if the shell should perform default processing.</returns>
		[PreserveSig]
		HRESULT MessageSFVCB(SFVM uMsg, IntPtr wParam, IntPtr lParam, ref IntPtr plResult);
	}

	/// <summary>
	/// <para>Exposes methods that present a view in the Windows Explorer or folder windows.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The object that exposes <c>IShellView</c> is typically created by a call to the IShellFolder::CreateViewObject method. This
	/// provides the channel of communication between a view object and Windows Explorer's outermost frame window. The communication
	/// involves the translation of messages, the state of the frame window (activated or deactivated), the state of the document window
	/// (activated or deactivated), and the merging of menus and toolbar items.
	/// </para>
	/// <para>
	/// This interface is implemented by namespace extensions that display themselves in Windows Explorer's namespace. This object is
	/// created by the IShellFolder object that hosts the view.
	/// </para>
	/// <para>These methods are used by the Shell view's Windows Explorer window to manipulate objects while they are active.</para>
	/// <para><c>IShellView</c> is derived from IOleWindow. The listed methods are specific to <c>IShellView</c>.</para>
	/// <para>
	/// A special instance of <c>IShellView</c> known as the default Shell folder view object can be created by calling
	/// SHCreateShellFolderView or SHCreateShellFolderViewEx. This instance can be differentiated from standard implementations by
	/// calling QueryInterface on an <c>IShellView</c> object using the IID_CDefView IID. This call succeeds only when made on the
	/// default Shell folder view object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellview
	[PInvokeData("shobjidl_core.h", MSDNShortId = "91438583-e4f1-456f-a130-2a45846fd725")]
	[ComImport, Guid("000214E3-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellView : IOleWindow
	{
		/// <summary>
		/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
		/// </summary>
		/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
		/// <returns>
		/// This method returns S_OK on success. Other possible return values include the following.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>The object is windowless.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Window</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>Frame</description>
		/// <description>The outermost main window where the container application's main menu resides.</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// <description>The window that displays the compound document containing the embedded object to the user.</description>
		/// </item>
		/// <item>
		/// <description>Pane</description>
		/// <description>
		/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Parent</description>
		/// <description>
		/// The container window that contains that object's view. The object application installs its window as a child of this window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>In-place</description>
		/// <description>
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
		/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
		/// parent windows.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT GetWindow(out HWND phwnd);

		/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
		/// name="fEnterMode"/>. Other possible return values include the following. <br/>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Applications can invoke context-sensitive help when the user:</para>
		/// <list type="bullet">
		/// <item>presses SHIFT+F1, then clicks a topic</item>
		/// <item>presses F1 when a menu item is selected</item>
		/// </list>
		/// <para>
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		/// <summary>Translates keyboard shortcut (accelerator) key strokes when a namespace extension's view has the focus.</summary>
		/// <param name="lpmsg">The address of the message to be translated.</param>
		void TranslateAccelerator(in MSG lpmsg);

		/// <summary>Enables or disables modeless dialog boxes. This method is not currently implemented.</summary>
		/// <param name="enable"><c>true</c> to enable modeless dialog box windows or <c>false</c> to disable them.</param>
		void EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool enable);

		/// <summary>
		/// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For
		/// example, if the TAB key is pressed when the tree has the focus, the view should be given the focus.
		/// </summary>
		/// <param name="uState">Flag specifying the activation state of the window.</param>
		void UIActivate([In] SVUIA uState);

		/// <summary>Refreshes the view's contents in response to user input.</summary>
		void Refresh();

		/// <summary>
		/// Creates a view window. This can be either the right pane of Windows Explorer or the client window of a folder window.
		/// </summary>
		/// <param name="psvPrevious">
		/// The address of the IShellView interface of the view window being exited. Views can use this parameter to communicate with a
		/// previous view of the same implementation. This interface can be used to optimize browsing between like views. This pointer
		/// may be NULL.
		/// </param>
		/// <param name="pfs">The address of a FOLDERSETTINGS structure. The view should use this when creating its view.</param>
		/// <param name="psb">
		/// The address of the current instance of the IShellBrowser interface. The view should call this interface's AddRef method and
		/// keep the interface pointer to allow communication with the Windows Explorer window.
		/// </param>
		/// <param name="prcView">The dimensions of the new view, in client coordinates.</param>
		/// <returns>The address of the window handle being created.</returns>
		HWND CreateViewWindow([In, Optional] IShellView? psvPrevious, in FOLDERSETTINGS pfs, [In] IShellBrowser psb, in RECT prcView);

		/// <summary>Destroys the view window.</summary>
		void DestroyViewWindow();

		/// <summary>Gets the current information.</summary>
		/// <returns>A FOLDERSETTINGS structure to receive the settings.</returns>
		FOLDERSETTINGS GetCurrentInfo();

		/// <summary>Allows the view to add pages to the Options property sheet from the View menu.</summary>
		/// <param name="dwReserved">Reserved.</param>
		/// <param name="lpfn">The address of the callback function used to add the pages.</param>
		/// <param name="lparam">A value that must be passed as the callback function's lparam parameter.</param>
		void AddPropertySheetPages([In, Optional] uint dwReserved, [In] AddPropSheetPageProc lpfn, [In] IntPtr lparam);

		/// <summary>Saves the Shell's view settings so the current state can be restored during a subsequent browsing session.</summary>
		void SaveViewState();

		/// <summary>Changes the selection state of one or more items within the Shell view window.</summary>
		/// <param name="pidlItem">The address of the ITEMIDLIST structure.</param>
		/// <param name="uFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		void SelectItem([In] IntPtr pidlItem, [In] SVSIF uFlags);

		/// <summary>Gets an interface that refers to data presented in the view.</summary>
		/// <param name="uItem">The constants that refer to an aspect of the view.</param>
		/// <param name="riid">The identifier of the COM interface being requested.</param>
		/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)]
		object? GetItemObject([In] SVGIO uItem, in Guid riid);
	}

	/// <summary>
	/// <para>Extends the capabilities of IShellView.</para>
	/// </summary>
	/// <remarks>
	/// <para>This interface also provides the methods of the IShellView interface, from which it inherits.</para>
	/// <para>When to Implement</para>
	/// <para>Implement IShellView2 if your namespace extension provides services to clients beyond those in IShellView .</para>
	/// <para>When to Use</para>
	/// <para>
	/// You do not call this interface directly. IShellView2 is used by the operating system only when it has confirmed that your
	/// application is aware of this interface. Objects that expose IShellView and IShellView2 are usually created by other Shell folder objects.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellview2
	[PInvokeData("shobjidl_core.h", MSDNShortId = "a61aec39-406d-4066-941d-e788d64f4310")]
	[ComImport, Guid("88E39E80-3578-11CF-AE69-08002B2E1262"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellView2 : IShellView
	{
		/// <summary>
		/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
		/// </summary>
		/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
		/// <returns>
		/// This method returns S_OK on success. Other possible return values include the following.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>The object is windowless.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Window</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>Frame</description>
		/// <description>The outermost main window where the container application's main menu resides.</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// <description>The window that displays the compound document containing the embedded object to the user.</description>
		/// </item>
		/// <item>
		/// <description>Pane</description>
		/// <description>
		/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Parent</description>
		/// <description>
		/// The container window that contains that object's view. The object application installs its window as a child of this window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>In-place</description>
		/// <description>
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
		/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
		/// parent windows.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT GetWindow(out HWND phwnd);

		/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
		/// name="fEnterMode"/>. Other possible return values include the following. <br/>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Applications can invoke context-sensitive help when the user:</para>
		/// <list type="bullet">
		/// <item>presses SHIFT+F1, then clicks a topic</item>
		/// <item>presses F1 when a menu item is selected</item>
		/// </list>
		/// <para>
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		/// <summary>Translates keyboard shortcut (accelerator) key strokes when a namespace extension's view has the focus.</summary>
		/// <param name="lpmsg">The address of the message to be translated.</param>
		new void TranslateAccelerator(in MSG lpmsg);

		/// <summary>Enables or disables modeless dialog boxes. This method is not currently implemented.</summary>
		/// <param name="enable"><c>true</c> to enable modeless dialog box windows or <c>false</c> to disable them.</param>
		new void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool enable);

		/// <summary>
		/// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For
		/// example, if the TAB key is pressed when the tree has the focus, the view should be given the focus.
		/// </summary>
		/// <param name="uState">Flag specifying the activation state of the window.</param>
		new void UIActivate(SVUIA uState);

		/// <summary>Refreshes the view's contents in response to user input.</summary>
		new void Refresh();

		/// <summary>
		/// Creates a view window. This can be either the right pane of Windows Explorer or the client window of a folder window.
		/// </summary>
		/// <param name="psvPrevious">
		/// The address of the IShellView interface of the view window being exited. Views can use this parameter to communicate with a
		/// previous view of the same implementation. This interface can be used to optimize browsing between like views. This pointer
		/// may be NULL.
		/// </param>
		/// <param name="pfs">The address of a FOLDERSETTINGS structure. The view should use this when creating its view.</param>
		/// <param name="psb">
		/// The address of the current instance of the IShellBrowser interface. The view should call this interface's AddRef method and
		/// keep the interface pointer to allow communication with the Windows Explorer window.
		/// </param>
		/// <param name="prcView">The dimensions of the new view, in client coordinates.</param>
		/// <returns>The address of the window handle being created.</returns>
		new HWND CreateViewWindow(IShellView? psvPrevious, in FOLDERSETTINGS pfs, IShellBrowser psb, in RECT prcView);

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
		/// <param name="uFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		new void SelectItem(IntPtr pidlItem, SVSIF uFlags);

		/// <summary>Gets an interface that refers to data presented in the view.</summary>
		/// <param name="uItem">The constants that refer to an aspect of the view.</param>
		/// <param name="riid">The identifier of the COM interface being requested.</param>
		/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)]
		new object? GetItemObject(SVGIO uItem, in Guid riid);

		/// <summary>
		/// Requests the current or default Shell view, together with all other valid view identifiers (VIDs) supported by this
		/// implementation of IShellView2.
		/// </summary>
		/// <param name="pvid">A pointer to the GUID of the requested view.</param>
		/// <param name="uView">The type of view requested.</param>
		void GetView(in Guid pvid, SV2GV uView);

		/// <summary>
		/// Used to request the creation of a new Shell view window. It can be either the right pane of Windows Explorer or the client
		/// window of a folder window.
		/// </summary>
		/// <param name="lpParams">A pointer to an SV2CVW2_PARAMS structure that defines the new view window.</param>
		void CreateViewWindow2(SV2CVW2_PARAMS lpParams);

		/// <summary>Used to change an item's identifier.</summary>
		/// <param name="pidlNew">
		/// A pointer to an ITEMIDLIST structure. The current identifier is passed in and is replaced by the new one.
		/// </param>
		void HandleRename(IntPtr pidlNew);

		/// <summary>Selects and positions an item in a Shell View.</summary>
		/// <param name="pidlItem">A pointer to an ITEMIDLIST structure that uniquely identifies the item of interest.</param>
		/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		/// <param name="point">A pointer to a POINT structure containing the new position.</param>
		void SelectAndPositionItem(IntPtr pidlItem, SVSIF flags, in POINT point);
	}

	/// <summary>
	/// <para>Extends the capabilities of IShellView2 by providing a method to replace IShellView2::CreateViewWindow2.</para>
	/// </summary>
	/// <remarks>
	/// <para>This interface also provides the methods of the IShellView and IShellView2 interfaces, from which it inherits.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl/nn-shobjidl-ishellview3
	[PInvokeData("shobjidl.h", MSDNShortId = "96b61e84-0d31-494d-a922-cd3dcd5735b9")]
	[ComImport(), Guid("ec39fa88-f8af-41c5-8421-38bed28f4673"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellView3 : IShellView2
	{
		/// <summary>
		/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
		/// </summary>
		/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
		/// <returns>
		/// This method returns S_OK on success. Other possible return values include the following.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>The object is windowless.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Window</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>Frame</description>
		/// <description>The outermost main window where the container application's main menu resides.</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// <description>The window that displays the compound document containing the embedded object to the user.</description>
		/// </item>
		/// <item>
		/// <description>Pane</description>
		/// <description>
		/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Parent</description>
		/// <description>
		/// The container window that contains that object's view. The object application installs its window as a child of this window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>In-place</description>
		/// <description>
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
		/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
		/// parent windows.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT GetWindow(out HWND phwnd);

		/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
		/// name="fEnterMode"/>. Other possible return values include the following. <br/>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Applications can invoke context-sensitive help when the user:</para>
		/// <list type="bullet">
		/// <item>presses SHIFT+F1, then clicks a topic</item>
		/// <item>presses F1 when a menu item is selected</item>
		/// </list>
		/// <para>
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		/// <summary>Translates keyboard shortcut (accelerator) key strokes when a namespace extension's view has the focus.</summary>
		/// <param name="lpmsg">The address of the message to be translated.</param>
		new void TranslateAccelerator(in MSG lpmsg);

		/// <summary>Enables or disables modeless dialog boxes. This method is not currently implemented.</summary>
		/// <param name="enable"><c>true</c> to enable modeless dialog box windows or <c>false</c> to disable them.</param>
		new void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool enable);

		/// <summary>
		/// Called when the activation state of the view window is changed by an event that is not caused by the Shell view itself. For
		/// example, if the TAB key is pressed when the tree has the focus, the view should be given the focus.
		/// </summary>
		/// <param name="uState">Flag specifying the activation state of the window.</param>
		new void UIActivate(SVUIA uState);

		/// <summary>Refreshes the view's contents in response to user input.</summary>
		new void Refresh();

		/// <summary>
		/// Creates a view window. This can be either the right pane of Windows Explorer or the client window of a folder window.
		/// </summary>
		/// <param name="psvPrevious">
		/// The address of the IShellView interface of the view window being exited. Views can use this parameter to communicate with a
		/// previous view of the same implementation. This interface can be used to optimize browsing between like views. This pointer
		/// may be NULL.
		/// </param>
		/// <param name="pfs">The address of a FOLDERSETTINGS structure. The view should use this when creating its view.</param>
		/// <param name="psb">
		/// The address of the current instance of the IShellBrowser interface. The view should call this interface's AddRef method and
		/// keep the interface pointer to allow communication with the Windows Explorer window.
		/// </param>
		/// <param name="prcView">The dimensions of the new view, in client coordinates.</param>
		/// <returns>The address of the window handle being created.</returns>
		new HWND CreateViewWindow(IShellView? psvPrevious, in FOLDERSETTINGS pfs, IShellBrowser psb, in RECT prcView);

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
		/// <param name="uFlags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		new void SelectItem(IntPtr pidlItem, SVSIF uFlags);

		/// <summary>Gets an interface that refers to data presented in the view.</summary>
		/// <param name="uItem">The constants that refer to an aspect of the view.</param>
		/// <param name="riid">The identifier of the COM interface being requested.</param>
		/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)]
		new object? GetItemObject(SVGIO uItem, in Guid riid);

		/// <summary>
		/// Requests the current or default Shell view, together with all other valid view identifiers (VIDs) supported by this
		/// implementation of IShellView2.
		/// </summary>
		/// <param name="pvid">A pointer to the GUID of the requested view.</param>
		/// <param name="uView">The type of view requested.</param>
		new void GetView(in Guid pvid, SV2GV uView);

		/// <summary>
		/// Used to request the creation of a new Shell view window. It can be either the right pane of Windows Explorer or the client
		/// window of a folder window.
		/// </summary>
		/// <param name="lpParams">A pointer to an SV2CVW2_PARAMS structure that defines the new view window.</param>
		new void CreateViewWindow2(SV2CVW2_PARAMS lpParams);

		/// <summary>Used to change an item's identifier.</summary>
		/// <param name="pidlNew">
		/// A pointer to an ITEMIDLIST structure. The current identifier is passed in and is replaced by the new one.
		/// </param>
		new void HandleRename(IntPtr pidlNew);

		/// <summary>Selects and positions an item in a Shell View.</summary>
		/// <param name="pidlItem">A pointer to an ITEMIDLIST structure that uniquely identifies the item of interest.</param>
		/// <param name="flags">One of the _SVSIF constants that specify the type of selection to apply.</param>
		/// <param name="point">A pointer to a POINT structure containing the new position.</param>
		new void SelectAndPositionItem(IntPtr pidlItem, SVSIF flags, in POINT point);

		/// <summary>
		/// Requests the creation of a new Shell view window. The view can be either the right pane of Windows Explorer or the client
		/// window of a folder window. This method replaces CreateViewWindow2.
		/// </summary>
		/// <param name="psbOwner">A pointer to an IShellBrowser interface to provide namespace extension services.</param>
		/// <param name="psvPrevious">
		/// A pointer to an IShellView interface that represents the previous view in the Windows Explorer or folder window.
		/// </param>
		/// <param name="dwViewFlags">Flags that specify details of the view being created.</param>
		/// <param name="dwMask">A bitwise mask that specifies which folder options specified in dwFlags are to be used.</param>
		/// <param name="dwFlags">A bitwise value that contains the folder options, as FOLDERFLAGS, to use in the new view.</param>
		/// <param name="fvMode">A bitwise value that contains the folder view mode options, as FOLDERVIEWMODE, to use in the new view.</param>
		/// <param name="pvid">A pointer to Shell view ID as a GUID.</param>
		/// <param name="prcView">A pointer to a RECT structure that provides the dimensions of the view window.</param>
		/// <returns>A value that receives a pointer to the handle of the new Shell view window.</returns>
		HWND CreateViewWindow3(IShellBrowser psbOwner, IShellView psvPrevious, SV3CVW3_FLAGS dwViewFlags, FOLDERFLAGS dwMask,
			FOLDERFLAGS dwFlags, FOLDERVIEWMODE fvMode, in Guid pvid, in RECT prcView);
	}

	/// <summary>Gets an interface that refers to data presented in the view.</summary>
	/// <typeparam name="T">The type of the COM interface being requested.</typeparam>
	/// <param name="sv">The <see cref="IShellView"/> instance.</param>
	/// <param name="uItem">The constants that refer to an aspect of the view.</param>
	/// <returns>The address that receives the interface pointer. If an error occurs, the pointer returned must be NULL.</returns>
	public static T? GetItemObject<T>(this IShellView sv, SVGIO uItem) where T : class => (T?)sv.GetItemObject(uItem, typeof(T).GUID);

	/// <summary>Contains folder view information.</summary>
	[PInvokeData("Shobjidl.h")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FOLDERSETTINGS
	{
		/// <summary>Folder view mode.</summary>
		public FOLDERVIEWMODE ViewMode;

		/// <summary>A set of flags that indicate the options for the folder.</summary>
		public FOLDERFLAGS fFlags;

		/// <summary>Initializes a new instance of the <see cref="FOLDERSETTINGS"/> struct.</summary>
		/// <param name="viewMode">Folder view mode.</param>
		/// <param name="flags">A set of flags that indicate the options for the folder.</param>
		public FOLDERSETTINGS(FOLDERVIEWMODE viewMode, FOLDERFLAGS flags)
		{
			ViewMode = viewMode;
			fFlags = flags;
		}
	}

	/// <summary>Contains folder view information.</summary>
	[PInvokeData("Shobjidl.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class PFOLDERSETTINGS
	{
		private FOLDERSETTINGS settings;

		/// <summary>Folder view mode.</summary>
		public FOLDERVIEWMODE ViewMode { get => settings.ViewMode; set => settings.ViewMode = value; }

		/// <summary>A set of flags that indicate the options for the folder.</summary>
		public FOLDERFLAGS fFlags { get => settings.fFlags; set => settings.fFlags = value; }

		/// <summary>Initializes a new instance of the <see cref="FOLDERSETTINGS"/> struct.</summary>
		/// <param name="viewMode">Folder view mode.</param>
		/// <param name="flags">A set of flags that indicate the options for the folder.</param>
		public PFOLDERSETTINGS(FOLDERVIEWMODE viewMode, FOLDERFLAGS flags)
		{
			settings.ViewMode = viewMode;
			settings.fFlags = flags;
		}

		/// <summary>Performs an implicit conversion from <see cref="PFOLDERSETTINGS"/> to <see cref="FOLDERSETTINGS"/>.</summary>
		/// <param name="r">The <see cref="PFOLDERSETTINGS"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator FOLDERSETTINGS(PFOLDERSETTINGS r) => r.settings;

		/// <summary>Performs an implicit conversion from <see cref="FOLDERSETTINGS"/> to <see cref="PFOLDERSETTINGS"/>.</summary>
		/// <param name="r">The <see cref="FOLDERSETTINGS"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PFOLDERSETTINGS(in FOLDERSETTINGS r) => new(r.ViewMode, r.fFlags);
	}

	/// <summary>
	/// <para>Holds the parameters for the IShellView2::CreateViewWindow2 method.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/ns-shobjidl_core-_sv2cvw2_params typedef struct
	// _SV2CVW2_PARAMS { DWORD cbSize; IShellView *psvPrev; LPCFOLDERSETTINGS pfs; IShellBrowser *psbOwner; RECT *prcView; const
	// SHELLVIEWID *pvid; HWND hwndView; } SV2CVW2_PARAMS, *LPSV2CVW2_PARAMS;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "7e165654-74ea-4d8b-81b7-11257f87af53")]
	[StructLayout(LayoutKind.Sequential)]
	public class SV2CVW2_PARAMS : IDisposable
	{
		/// <summary>The size of the structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A pointer to the IShellView interface of the previous view. A Shell view can use this parameter to communicate with a
		/// previous view with the same implementation. It can also be used to optimize browsing between like views. This parameter may
		/// be NULL.
		/// </summary>
		public IShellView? psvPrev;

		/// <summary>A FOLDERSETTINGS structure with information needed to create the view.</summary>
		private IntPtr _pfs;

		/// <summary>
		/// A pointer to the current instance of the IShellBrowser interface of the parent Shell browser. IShellView2::CreateViewWindow2
		/// should call this interface's AddRef method and store the interface pointer. It can be used for communication with the
		/// Windows Explorer window.
		/// </summary>
		public IShellBrowser psbOwner;

		/// <summary>A RECT structure that defines the view's display area.</summary>
		private IntPtr _prcView;

		/// <summary>
		/// A pointer to a view ID. The view ID can be one of the Windows-defined VIDs or a custom, view-defined VID. This value takes
		/// precedence over the view mode designated in the FOLDERSETTINGS structure pointed to by pfs.
		/// </summary>
		private IntPtr _pvid;

		/// <summary>A window handle to the new Shell view.</summary>
		public HWND hwndView;

		/// <summary>Initializes a new instance of the <see cref="SV2CVW2_PARAMS"/> class.</summary>
		/// <param name="viewMode">Folder view mode.</param>
		/// <param name="flags">A set of flags that indicate the options for the folder.</param>
		/// <param name="owner">The current instance of the IShellBrowser interface of the parent Shell browser.</param>
		/// <param name="displayArea">The view's display area.</param>
		/// <param name="prevView">
		/// Optional. The IShellView interface of the previous view. A Shell view can use this parameter to communicate with a previous
		/// view with the same implementation. It can also be used to optimize browsing between like views.
		/// </param>
		public SV2CVW2_PARAMS(FOLDERVIEWMODE viewMode, FOLDERFLAGS flags, IShellBrowser owner, ref RECT displayArea, IShellView? prevView = null)
		{
			cbSize = (uint)Marshal.SizeOf(typeof(SV2CVW2_PARAMS));
			psvPrev = prevView;
			psbOwner = owner;
			pfs = new FOLDERSETTINGS(viewMode, flags);
			prcView = displayArea;
		}

		/// <summary>A FOLDERSETTINGS structure with information needed to create the view.</summary>
		public FOLDERSETTINGS pfs
		{
			get => _pfs.ToStructure<FOLDERSETTINGS>();
			set { Marshal.FreeCoTaskMem(_pfs); _pfs = InteropExtensions.MarshalToPtr(value, Marshal.AllocCoTaskMem, out var _); }
		}

		/// <summary>A RECT structure that defines the view's display area.</summary>
		public RECT prcView
		{
			get => _prcView.ToStructure<RECT>();
			set { Marshal.FreeCoTaskMem(_prcView); _prcView = InteropExtensions.MarshalToPtr(value, Marshal.AllocCoTaskMem, out var _); }
		}

		/// <summary>
		/// A view ID. The view ID can be one of the Windows-defined VIDs or a custom, view-defined VID. This value takes precedence
		/// over the view mode designated in the FOLDERSETTINGS structure pointed to by pfs.
		/// </summary>
		public Guid pvid => _pvid.ToStructure<Guid>();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			Marshal.FreeCoTaskMem(_pfs);
			Marshal.FreeCoTaskMem(_prcView);
		}
	}
}