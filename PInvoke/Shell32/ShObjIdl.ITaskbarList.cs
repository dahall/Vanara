using System.Security;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// When a button in a thumbnail toolbar is clicked, the window associated with that thumbnail is sent a WM_COMMAND message with the
	/// HIWORD of its wParam parameter set to THBN_CLICKED and the LOWORD to the button ID.
	/// </summary>
	public const uint THBN_CLICKED = 0x1800;

	/// <summary>DESTS_E_NO_MATCHING_ASSOC_HANDLER.  Win7 internal error code for Jump Lists.</summary>
	/// <remarks>There is no Assoc Handler for the given item registered by the specified application.</remarks>
	public static readonly HRESULT DESTS_E_NO_MATCHING_ASSOC_HANDLER = new(0x80040F03);

	/// <summary>DESTS_E_NORECDOCS.  Win7 internal error code for Jump Lists.</summary>
	/// <remarks>The given item is excluded from the recent docs folder by the NoRecDocs bit on its registration.</remarks>
	public static readonly HRESULT DESTS_E_NORECDOCS = new(0x80040F04);

	/// <summary>DESTS_E_NOTALLCLEARED.  Win7 internal error code for Jump Lists.</summary>
	/// <remarks>Not all of the items were successfully cleared</remarks>
	public static readonly HRESULT DESTS_E_NOTALLCLEARED = new(0x80040F05);

	/// <summary>Windows message indicating that the taskbar was created.</summary>
	public static readonly uint WM_TASKBARCREATED = User32.RegisterWindowMessage("TaskbarCreated");

	/// <summary>Windows message indicating that the taskbar button was created for the application window.</summary>
	public static readonly uint WM_TASKBARBUTTONCREATED = User32.RegisterWindowMessage("TaskbarButtonCreated");

	/// <summary>Used by the ITaskbarList4::SetTabProperties method to specify tab properties.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd562320")]
	[Flags]
	public enum STPFLAG
	{
		/// <summary>
		/// No specific property values are specified. The default behavior is used: the tab window provides a thumbnail and peek image,
		/// either live or static as appropriate.
		/// </summary>
		STPF_NONE = 0,

		/// <summary>
		/// Always use the thumbnail provided by the main application frame window rather than a thumbnail provided by the individual tab
		/// window. Do not combine this value with STPF_USEAPPTHUMBNAILWHENACTIVE; doing so will result in an error.
		/// </summary>
		STPF_USEAPPTHUMBNAILALWAYS = 1,

		/// <summary>
		/// When the application tab is active and a live representation of its window is available, use the main application's frame
		/// window thumbnail. At other times, use the tab window thumbnail. Do not combine this value with STPF_USEAPPTHUMBNAILALWAYS;
		/// doing so will result in an error.
		/// </summary>
		STPF_USEAPPTHUMBNAILWHENACTIVE = 2,

		/// <summary>
		/// Always use the peek image provided by the main application frame window rather than a peek image provided by the individual
		/// tab window. Do not combine this value with STPF_USEAPPPEEKWHENACTIVE; doing so will result in an error.
		/// </summary>
		STPF_USEAPPPEEKALWAYS = 4,

		/// <summary>
		/// When the application tab is active and a live representation of its window is available, show the main application frame in
		/// the peek feature. At other times, use the tab window. Do not combine this value with STPF_USEAPPPEEKALWAYS; doing so will
		/// result in an error.
		/// </summary>
		STPF_USEAPPPEEKWHENACTIVE = 8,
	}

	/// <summary>
	/// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually
	/// exclusive of all others.
	/// </summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd391697")]
	[Flags]
	public enum TBPFLAG
	{
		/// <summary>
		/// The progress indicator turns red to show that an error has occurred in one of the windows that is broadcasting progress. This
		/// is a determinate state. If the progress indicator is in the indeterminate state, it switches to a red determinate display of
		/// a generic percentage not indicative of actual progress.
		/// </summary>
		TBPF_ERROR = 4,

		/// <summary>
		/// The progress indicator does not grow in size, but cycles repeatedly along the length of the taskbar button. This indicates
		/// activity without specifying what proportion of the progress is complete. Progress is taking place, but there is no prediction
		/// as to how long the operation will take.
		/// </summary>
		TBPF_INDETERMINATE = 1,

		/// <summary>
		/// Stops displaying progress and returns the button to its normal state. Call this method with this flag to dismiss the progress
		/// bar when the operation is complete or canceled.
		/// </summary>
		TBPF_NOPROGRESS = 0,

		/// <summary>
		/// The progress indicator grows in size from left to right in proportion to the estimated amount of the operation completed.
		/// This is a determinate progress indicator; a prediction is being made as to the duration of the operation.
		/// </summary>
		TBPF_NORMAL = 2,

		/// <summary>
		/// The progress indicator turns yellow to show that progress is currently stopped in one of the windows but can be resumed by
		/// the user. No error condition exists and nothing is preventing the progress from continuing. This is a determinate state. If
		/// the progress indicator is in the indeterminate state, it switches to a yellow determinate display of a generic percentage not
		/// indicative of actual progress.
		/// </summary>
		TBPF_PAUSED = 8
	}

	/// <summary>Used by THUMBBUTTON to control specific states and behaviors of the button.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd562321")]
	[Flags]
	public enum THUMBBUTTONFLAGS : uint
	{
		/// <summary>
		/// The button is disabled. It is present, but has a visual state that indicates that it will not respond to user action.
		/// </summary>
		THBF_DISABLED = 1,

		/// <summary>When the button is clicked, the taskbar button's flyout closes immediately.</summary>
		THBF_DISMISSONCLICK = 2,

		/// <summary>The button is active and available to the user.</summary>
		THBF_ENABLED = 0,

		/// <summary>The button is not shown to the user.</summary>
		THBF_HIDDEN = 8,

		/// <summary>Do not draw a button border, use only the image.</summary>
		THBF_NOBACKGROUND = 4,

		/// <summary>
		/// The button is enabled but not interactive; no pressed button state is drawn. This value is intended for instances where the
		/// button is used in a notification.
		/// </summary>
		THBF_NONINTERACTIVE = 0x10
	}

	/// <summary>Used by the THUMBBUTTON structure to specify which members of that structure contain valid data.</summary>
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd562322")]
	[Flags]
	public enum THUMBBUTTONMASK : uint
	{
		/// <summary>The iBitmap member contains valid information.</summary>
		THB_BITMAP = 1,

		/// <summary>The dwFlags member contains valid information.</summary>
		THB_FLAGS = 8,

		/// <summary>The hIcon member contains valid information.</summary>
		THB_ICON = 2,

		/// <summary>The szTip member contains valid information.</summary>
		THB_TOOLTIP = 4
	}

	/// <summary>
	/// Exposes methods that allow an application to provide a custom Jump List, including destinations and tasks, for display in the taskbar.
	/// </summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6332debf-87b5-4670-90c0-5e57b408a49e"), CoClass(typeof(CDestinationList))]
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd378402")]
	public interface ICustomDestinationList
	{
		/// <summary>
		/// Specifies a unique Application User Model ID (AppUserModelID) for the application whose taskbar button will hold the custom
		/// Jump List built through the methods of this interface. This method is optional.
		/// </summary>
		/// <param name="pszAppID">
		/// A pointer to the AppUserModelID of the process or application whose taskbar representation receives the Jump List.
		/// </param>
		void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string? pszAppID);

		/// <summary>Initiates a building session for a custom Jump List.</summary>
		/// <param name="pcMaxSlots">
		/// A pointer that, when this method returns, points to the current user setting for the Number of recent items to display in
		/// Jump Lists option in the Taskbar and Start Menu Properties window. The default value is 10. This is the maximum number of
		/// destinations that will be shown, and it is a total of all destinations, regardless of category. More destinations can be
		/// added, but they will not be shown in the UI.
		/// <para>A Jump List will always show at least this many slots—destinations and, if there is room, tasks.</para>
		/// <para>
		/// This number does not include separators and section headers as long as the total number of separators and headers does not
		/// exceed four. Separators and section headers beyond the first four might reduce the number of destinations displayed if space
		/// is constrained. This number does not affect the standard command entries for pinning or unpinning, closing the window, or
		/// launching a new instance. It also does not affect tasks or pinned items, the number of which that can be displayed is based
		/// on the space available to the Jump List.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// A reference to the IID of an interface to be retrieved in ppv, typically IID_IObjectArray, that will represent all items
		/// currently stored in the list of removed destinations for the application. This information is used to ensure that removed
		/// items are not part of the new Jump List.
		/// </param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in riid. This is typically an IObjectArray, which
		/// represents a collection of IShellItem and IShellLink objects that represent the removed items.
		/// </returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 1)]
		object BeginList(out uint pcMaxSlots, in Guid riid);

		/// <summary>Defines a custom category and the destinations that it contains, for inclusion in a custom Jump List.</summary>
		/// <param name="pszCategory">
		/// A pointer to a string that contains the display name of the custom category. This string is shown in the category's header in
		/// the Jump List. The string can directly hold the display name or it can be an indirect string representation, such as
		/// "@shell32.dll,-1324", to use a stored string. An indirect string enables the category header to be displayed in the user's
		/// selected language. <note>Each custom category must have a unique name. Duplicate category names will cause presentation
		/// issues in the Jump List.</note>
		/// </param>
		/// <param name="poa">
		/// A pointer to an IObjectArray that represents one or more IShellItem objects that represent the destinations in the category.
		/// Some destinations in the list might also be represented by IShellLink objects, although less often. <note>Any IShellLink used
		/// here must declare an argument list through SetArguments. Adding an IShellLink object with no arguments to a custom category
		/// is not supported since a user cannot pin or unpin this type of item from a Jump List, nor can they be added or removed.</note>
		/// </param>
		void AppendCategory([MarshalAs(UnmanagedType.LPWStr)] string pszCategory, IObjectArray poa);

		/// <summary>Specifies that the Frequent or Recent category should be included in a custom Jump List.</summary>
		/// <param name="category">One of the KNOWNDESTCATEGORY values that indicate which known category to add to the list.</param>
		void AppendKnownCategory(KNOWNDESTCATEGORY category);

		/// <summary>Specifies items to include in the Tasks category of a custom Jump List.</summary>
		/// <param name="poa">
		/// A pointer to an IObjectArray that represents one or more IShellLink (or, more rarely, IShellItem) objects that represent the
		/// tasks. <note>Any IShellLink used here must declare an argument list through SetArguments. Adding an IShellLink object with no
		/// arguments to a custom category is not supported. A user cannot pin or unpin this type of item from a Jump List, nor can they
		/// be added or removed.</note>
		/// </param>
		void AddUserTasks(IObjectArray poa);

		/// <summary>
		/// Declares that the Jump List initiated by a call to ICustomDestinationList::BeginList is complete and ready for display.
		/// </summary>
		void CommitList();

		/// <summary>
		/// Retrieves the current list of destinations that have been removed by the user from the existing Jump List that this custom
		/// Jump List is meant to replace.
		/// </summary>
		/// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IObjectArray.</param>
		/// <returns>
		/// When this method returns, contains the interface pointer requested in riid. This is typically an IObjectArray, which
		/// represents a collection of IShellItem or IShellLink objects that represent the items in the list of removed destinations.
		/// </returns>
		[return: MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)]
		object GetRemovedDestinations(in Guid riid);

		/// <summary>Deletes a custom Jump List for a specified application.</summary>
		/// <param name="pszAppID">
		/// A pointer to the AppUserModelID of the process whose taskbar button representation displays the custom Jump List. In the beta
		/// release of Windows 7, this AppUserModelID must be explicitly provided because this method is intended to be called from an
		/// uninstaller, which runs in a separate process. Because it is in a separate process, the system cannot reliably deduce the
		/// AppUserModelID. This restriction is expected to be removed in later releases.
		/// </param>
		void DeleteList([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszAppID);

		/// <summary>
		/// Discontinues a Jump List building session initiated by ICustomDestinationList::BeginList without committing any changes.
		/// </summary>
		void AbortList();
	}

	/// <summary>Exposes methods that control the taskbar. It allows you to dynamically add, remove, and activate items on the taskbar.</summary>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("56FDF342-FD6D-11d0-958A-006097C9A090"), CoClass(typeof(CTaskbarList))]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb774652")]
	public interface ITaskbarList
	{
		/// <summary>
		/// Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.
		/// </summary>
		void HrInit();

		/// <summary>Adds an item to the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
		void AddTab(HWND hwnd);

		/// <summary>Deletes an item from the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
		void DeleteTab(HWND hwnd);

		/// <summary>
		/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed
		/// as active.
		/// </summary>
		/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
		void ActivateTab(HWND hwnd);

		/// <summary>Marks a taskbar button as active but does not visually activate it.</summary>
		/// <param name="hwnd">A handle to the window to be marked as active.</param>
		void SetActiveAlt(HWND hwnd);
	}

	/// <summary>Extends the ITaskbarList interface by exposing a method to mark a window as a full-screen display.</summary>
	/// <seealso cref="ITaskbarList"/>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("602D4995-B13A-429b-A66E-1935E44F4317"), CoClass(typeof(CTaskbarList))]
	[PInvokeData("Shobjidl.h", MSDNShortId = "bb774638")]
	public interface ITaskbarList2 : ITaskbarList
	{
		/// <summary>
		/// Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.
		/// </summary>
		new void HrInit();

		/// <summary>Adds an item to the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
		new void AddTab(HWND hwnd);

		/// <summary>Deletes an item from the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
		new void DeleteTab(HWND hwnd);

		/// <summary>
		/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed
		/// as active.
		/// </summary>
		/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
		new void ActivateTab(HWND hwnd);

		/// <summary>Marks a taskbar button as active but does not visually activate it.</summary>
		/// <param name="hwnd">A handle to the window to be marked as active.</param>
		new void SetActiveAlt(HWND hwnd);

		/// <summary>Marks a window as full-screen.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the window to be marked.</para>
		/// </param>
		/// <param name="fFullscreen">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean value marking the desired full-screen status of the window.</para>
		/// </param>
		/// <remarks>
		/// Setting the value of fFullscreen to <c>TRUE</c>, the Shell treats this window as a full-screen window, and the taskbar is
		/// moved to the bottom of the z-order when this window is active. Setting the value of fFullscreen to <c>FALSE</c> removes the
		/// full-screen marking, but does not cause the Shell to treat the window as though it were definitely not full-screen. With a
		/// <c>FALSE</c> fFullscreen value, the Shell depends on its automatic detection facility to specify how the window should be
		/// treated, possibly still flagging the window as full-screen.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-itaskbarlist2-markfullscreenwindow
		// HRESULT MarkFullscreenWindow( HWND hwnd, BOOL fFullscreen );
		void MarkFullscreenWindow(HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
	}

	/// <summary>
	/// Extends ITaskbarList2 by exposing methods that support the unified launching and switching taskbar button functionality added in
	/// Windows 7. This functionality includes thumbnail representations and switch targets based on individual tabs in a tabbed
	/// application, thumbnail toolbars, notification and status overlays, and progress indicators.
	/// </summary>
	/// <seealso cref="ITaskbarList2"/>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"), CoClass(typeof(CTaskbarList))]
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd391692", MinClient = PInvokeClient.Windows7)]
	public interface ITaskbarList3 : ITaskbarList2
	{
		/// <summary>
		/// Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.
		/// </summary>
		new void HrInit();

		/// <summary>Adds an item to the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
		new void AddTab(HWND hwnd);

		/// <summary>Deletes an item from the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
		new void DeleteTab(HWND hwnd);

		/// <summary>
		/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed
		/// as active.
		/// </summary>
		/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
		new void ActivateTab(HWND hwnd);

		/// <summary>Marks a taskbar button as active but does not visually activate it.</summary>
		/// <param name="hwnd">A handle to the window to be marked as active.</param>
		new void SetActiveAlt(HWND hwnd);

		/// <summary>Marks a window as full-screen.</summary>
		/// <param name="hwnd">The handle of the window to be marked.</param>
		/// <param name="fFullscreen">A Boolean value marking the desired full-screen status of the window.</param>
		new void MarkFullscreenWindow(HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		/// <summary>
		/// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
		/// </summary>
		/// <param name="hwnd">The handle of the window whose associated taskbar button is being used as a progress indicator.</param>
		/// <param name="ullCompleted">
		/// An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.
		/// </param>
		/// <param name="ullTotal">
		/// An application-defined value that specifies the value ullCompleted will have when the operation is complete.
		/// </param>
		void SetProgressValue(HWND hwnd, ulong ullCompleted, ulong ullTotal);

		/// <summary>Sets the type and state of the progress indicator displayed on a taskbar button.</summary>
		/// <param name="hwnd">
		/// The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will
		/// display the progress bar.
		/// </param>
		/// <param name="tbpFlags">
		/// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually
		/// exclusive of all others.
		/// </param>
		void SetProgressState(HWND hwnd, TBPFLAG tbpFlags);

		/// <summary>
		/// Informs the taskbar that a new tab or document thumbnail has been provided for display in an application's taskbar group flyout.
		/// </summary>
		/// <param name="hwndTab">Handle of the tab or document window. This value is required and cannot be NULL.</param>
		/// <param name="hwndMDI">
		/// Handle of the application's main window. This value tells the taskbar which application's preview group to attach the new
		/// thumbnail to. This value is required and cannot be NULL.
		/// </param>
		/// <remarks>
		/// By itself, registering a tab thumbnail alone will not result in its being displayed. You must also call
		/// ITaskbarList3::SetTabOrder to instruct the group where to display it.
		/// </remarks>
		void RegisterTab(HWND hwndTab, HWND hwndMDI);

		/// <summary>Removes a thumbnail from an application's preview group when that tab or document is closed in the application.</summary>
		/// <param name="hwndTab">
		/// The handle of the tab window whose thumbnail is being removed. This is the same value with which the thumbnail was registered
		/// as part the group through ITaskbarList3::RegisterTab. This value is required and cannot be NULL.
		/// </param>
		/// <remarks>
		/// It is the responsibility of the calling application to free hwndTab through DestroyWindow. UnregisterTab must be called
		/// before the handle is freed.
		/// </remarks>
		void UnregisterTab(HWND hwndTab);

		/// <summary>
		/// Inserts a new thumbnail into a tabbed-document interface (TDI) or multiple-document interface (MDI) application's group
		/// flyout or moves an existing thumbnail to a new position in the application's group.
		/// </summary>
		/// <param name="hwndTab">
		/// The handle of the tab window whose thumbnail is being placed. This value is required, must already be registered through
		/// ITaskbarList3::RegisterTab, and cannot be NULL.
		/// </param>
		/// <param name="hwndInsertBefore">
		/// The handle of the tab window whose thumbnail that hwndTab is inserted to the left of. This handle must already be registered
		/// through ITaskbarList3::RegisterTab. If this value is NULL, the new thumbnail is added to the end of the list.
		/// </param>
		/// <remarks>This method must be called for the thumbnail to be shown in the group. Call it after you have called ITaskbarList3::RegisterTab.</remarks>
		void SetTabOrder(HWND hwndTab, [Optional] HWND hwndInsertBefore);

		/// <summary>Informs the taskbar that a tab or document window has been made the active window.</summary>
		/// <param name="hwndTab">
		/// Handle of the active tab window. This handle must already be registered through ITaskbarList3::RegisterTab. This value can be
		/// NULL if no tab is active.
		/// </param>
		/// <param name="hwndMDI">
		/// Handle of the application's main window. This value tells the taskbar which group the thumbnail is a member of. This value is
		/// required and cannot be NULL.
		/// </param>
		/// <param name="dwReserved">Reserved; set to 0.</param>
		void SetTabActive([Optional] HWND hwndTab, HWND hwndMDI, uint dwReserved = 0);

		/// <summary>
		/// Adds a thumbnail toolbar with a specified set of buttons to the thumbnail image of a window in a taskbar button flyout.
		/// </summary>
		/// <param name="hwnd">
		/// The handle of the window whose thumbnail representation will receive the toolbar. This handle must belong to the calling process.
		/// </param>
		/// <param name="cButtons">
		/// The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7.
		/// </param>
		/// <param name="pButtons">
		/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button to be added to the toolbar.
		/// Buttons cannot be added or deleted later, so this must be the full defined set. Buttons also cannot be reordered, so their
		/// order in the array, which is the order in which they are displayed left to right, will be their permanent order.
		/// </param>
		void ThumbBarAddButtons(HWND hwnd, uint cButtons, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		/// <summary>
		/// Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail
		/// toolbar is a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.
		/// </summary>
		/// <param name="hwnd">The handle of the window whose thumbnail representation contains the toolbar.</param>
		/// <param name="cButtons">
		/// The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7. This array
		/// contains only structures that represent existing buttons that are being updated.
		/// </param>
		/// <param name="pButtons">
		/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button. If the button already exists
		/// (the iId value is already defined), then that existing button is updated with the information provided in the structure.
		/// </param>
		void ThumbBarUpdateButtons(HWND hwnd, uint cButtons, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		/// <summary>
		/// Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a taskbar
		/// button flyout.
		/// </summary>
		/// <param name="hwnd">
		/// The handle of the window whose thumbnail representation contains the toolbar to be updated. This handle must belong to the
		/// calling process.
		/// </param>
		/// <param name="himl">The handle of the image list that contains all button images to be used in the toolbar.</param>
		/// <remarks>
		/// Applications must provide these button images:
		/// <list type="bullet">
		/// <item>
		/// <term>The button in its default active state.</term>
		/// </item>
		/// <item>
		/// <term>Images suitable for use with high-dpi (dots per inch) displays.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Images must be 32-bit and of dimensions GetSystemMetrics(SM_CXICON) x GetSystemMetrics(SM_CYICON). The toolbar itself
		/// provides visuals for a button's clicked, disabled, and hover states.
		/// </para>
		/// </remarks>
		void ThumbBarSetImageList(HWND hwnd, HIMAGELIST himl);

		/// <summary>Applies an overlay to a taskbar button to indicate application status or a notification to the user.</summary>
		/// <param name="hwnd">
		/// The handle of the window whose associated taskbar button receives the overlay. This handle must belong to a calling process
		/// associated with the button's application and must be a valid HWND or the call is ignored.
		/// </param>
		/// <param name="hIcon">
		/// The handle of an icon to use as the overlay. This should be a small icon, measuring 16x16 pixels at 96 dpi. If an overlay
		/// icon is already applied to the taskbar button, that existing overlay is replaced.
		/// <para>
		/// This value can be NULL.How a NULL value is handled depends on whether the taskbar button represents a single window or a
		/// group of windows.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the taskbar button represents a single window, the overlay icon is removed from the display.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the taskbar button represents a group of windows and a previous overlay is still available (received earlier than the
		/// current overlay, but not yet freed by a NULL value), then that previous overlay is displayed in place of the current overlay.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// It is the responsibility of the calling application to free hIcon when it is no longer needed.This can generally be done
		/// after you call SetOverlayIcon because the taskbar makes and uses its own copy of the icon.
		/// </para>
		/// </param>
		/// <param name="pszDescription">
		/// A pointer to a string that provides an alt text version of the information conveyed by the overlay, for accessibility purposes.
		/// </param>
		void SetOverlayIcon(HWND hwnd, [Optional] HICON hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

		/// <summary>
		/// Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview
		/// thumbnail in a taskbar button flyout.
		/// </summary>
		/// <param name="hwnd">
		/// The handle to the window whose thumbnail displays the tooltip. This handle must belong to the calling process.
		/// </param>
		/// <param name="pszTip">
		/// The pointer to the text to be displayed in the tooltip. This value can be NULL, in which case the title of the window
		/// specified by hwnd is used as the tooltip.
		/// </param>
		void SetThumbnailTooltip(HWND hwnd, [MarshalAs(UnmanagedType.LPWStr)] string? pszTip);

		/// <summary>Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.</summary>
		/// <param name="hwnd">The handle to a window represented in the taskbar.</param>
		/// <param name="prcClip">
		/// A pointer to a RECT structure that specifies a selection within the window's client area, relative to the upper-left corner
		/// of that client area. To clear a clip that is already in place and return to the default display of the thumbnail, set this
		/// parameter to NULL.
		/// </param>
		void SetThumbnailClip(HWND hwnd, [Optional] PRECT? prcClip);
	}

	/// <summary>
	/// Extends ITaskbarList3 by providing a method that allows the caller to control two property values for the tab thumbnail and peek feature.
	/// </summary>
	/// <seealso cref="ITaskbarList3"/>
	[SuppressUnmanagedCodeSecurity]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf"), CoClass(typeof(CTaskbarList))]
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd562040")]
	public interface ITaskbarList4 : ITaskbarList3
	{
		/// <summary>
		/// Initializes the taskbar list object. This method must be called before any other ITaskbarList methods can be called.
		/// </summary>
		new void HrInit();

		/// <summary>Adds an item to the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be added to the taskbar.</param>
		new void AddTab(HWND hwnd);

		/// <summary>Deletes an item from the taskbar.</summary>
		/// <param name="hwnd">A handle to the window to be deleted from the taskbar.</param>
		new void DeleteTab(HWND hwnd);

		/// <summary>
		/// Activates an item on the taskbar. The window is not actually activated; the window's item on the taskbar is merely displayed
		/// as active.
		/// </summary>
		/// <param name="hwnd">A handle to the window on the taskbar to be displayed as active.</param>
		new void ActivateTab(HWND hwnd);

		/// <summary>Marks a taskbar button as active but does not visually activate it.</summary>
		/// <param name="hwnd">A handle to the window to be marked as active.</param>
		new void SetActiveAlt(HWND hwnd);

		/// <summary>Marks a window as full-screen.</summary>
		/// <param name="hwnd">The handle of the window to be marked.</param>
		/// <param name="fFullscreen">A Boolean value marking the desired full-screen status of the window.</param>
		new void MarkFullscreenWindow(HWND hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

		/// <summary>
		/// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
		/// </summary>
		/// <param name="hwnd">The handle of the window whose associated taskbar button is being used as a progress indicator.</param>
		/// <param name="ullCompleted">
		/// An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.
		/// </param>
		/// <param name="ullTotal">
		/// An application-defined value that specifies the value ullCompleted will have when the operation is complete.
		/// </param>
		new void SetProgressValue(HWND hwnd, ulong ullCompleted, ulong ullTotal);

		/// <summary>Sets the type and state of the progress indicator displayed on a taskbar button.</summary>
		/// <param name="hwnd">
		/// The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will
		/// display the progress bar.
		/// </param>
		/// <param name="tbpFlags">
		/// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually
		/// exclusive of all others.
		/// </param>
		new void SetProgressState(HWND hwnd, TBPFLAG tbpFlags);

		/// <summary>
		/// Informs the taskbar that a new tab or document thumbnail has been provided for display in an application's taskbar group flyout.
		/// </summary>
		/// <param name="hwndTab">Handle of the tab or document window. This value is required and cannot be NULL.</param>
		/// <param name="hwndMDI">
		/// Handle of the application's main window. This value tells the taskbar which application's preview group to attach the new
		/// thumbnail to. This value is required and cannot be NULL.
		/// </param>
		/// <remarks>
		/// By itself, registering a tab thumbnail alone will not result in its being displayed. You must also call
		/// ITaskbarList3::SetTabOrder to instruct the group where to display it.
		/// </remarks>
		new void RegisterTab(HWND hwndTab, HWND hwndMDI);

		/// <summary>Removes a thumbnail from an application's preview group when that tab or document is closed in the application.</summary>
		/// <param name="hwndTab">
		/// The handle of the tab window whose thumbnail is being removed. This is the same value with which the thumbnail was registered
		/// as part the group through ITaskbarList3::RegisterTab. This value is required and cannot be NULL.
		/// </param>
		/// <remarks>
		/// It is the responsibility of the calling application to free hwndTab through DestroyWindow. UnregisterTab must be called
		/// before the handle is freed.
		/// </remarks>
		new void UnregisterTab(HWND hwndTab);

		/// <summary>
		/// Inserts a new thumbnail into a tabbed-document interface (TDI) or multiple-document interface (MDI) application's group
		/// flyout or moves an existing thumbnail to a new position in the application's group.
		/// </summary>
		/// <param name="hwndTab">
		/// The handle of the tab window whose thumbnail is being placed. This value is required, must already be registered through
		/// ITaskbarList3::RegisterTab, and cannot be NULL.
		/// </param>
		/// <param name="hwndInsertBefore">
		/// The handle of the tab window whose thumbnail that hwndTab is inserted to the left of. This handle must already be registered
		/// through ITaskbarList3::RegisterTab. If this value is NULL, the new thumbnail is added to the end of the list.
		/// </param>
		/// <remarks>This method must be called for the thumbnail to be shown in the group. Call it after you have called ITaskbarList3::RegisterTab.</remarks>
		new void SetTabOrder(HWND hwndTab, [Optional] HWND hwndInsertBefore);

		/// <summary>Informs the taskbar that a tab or document window has been made the active window.</summary>
		/// <param name="hwndTab">
		/// Handle of the active tab window. This handle must already be registered through ITaskbarList3::RegisterTab. This value can be
		/// NULL if no tab is active.
		/// </param>
		/// <param name="hwndMDI">
		/// Handle of the application's main window. This value tells the taskbar which group the thumbnail is a member of. This value is
		/// required and cannot be NULL.
		/// </param>
		/// <param name="dwReserved">Reserved; set to 0.</param>
		new void SetTabActive([Optional] HWND hwndTab, HWND hwndMDI, uint dwReserved = 0);

		/// <summary>
		/// Adds a thumbnail toolbar with a specified set of buttons to the thumbnail image of a window in a taskbar button flyout.
		/// </summary>
		/// <param name="hwnd">
		/// The handle of the window whose thumbnail representation will receive the toolbar. This handle must belong to the calling process.
		/// </param>
		/// <param name="cButtons">
		/// The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7.
		/// </param>
		/// <param name="pButtons">
		/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button to be added to the toolbar.
		/// Buttons cannot be added or deleted later, so this must be the full defined set. Buttons also cannot be reordered, so their
		/// order in the array, which is the order in which they are displayed left to right, will be their permanent order.
		/// </param>
		new void ThumbBarAddButtons(HWND hwnd, uint cButtons, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		/// <summary>
		/// Shows, enables, disables, or hides buttons in a thumbnail toolbar as required by the window's current state. A thumbnail
		/// toolbar is a toolbar embedded in a thumbnail image of a window in a taskbar button flyout.
		/// </summary>
		/// <param name="hwnd">The handle of the window whose thumbnail representation contains the toolbar.</param>
		/// <param name="cButtons">
		/// The number of buttons defined in the array pointed to by pButton. The maximum number of buttons allowed is 7. This array
		/// contains only structures that represent existing buttons that are being updated.
		/// </param>
		/// <param name="pButtons">
		/// A pointer to an array of THUMBBUTTON structures. Each THUMBBUTTON defines an individual button. If the button already exists
		/// (the iId value is already defined), then that existing button is updated with the information provided in the structure.
		/// </param>
		new void ThumbBarUpdateButtons(HWND hwnd, uint cButtons, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

		/// <summary>
		/// Specifies an image list that contains button images for a toolbar embedded in a thumbnail image of a window in a taskbar
		/// button flyout.
		/// </summary>
		/// <param name="hwnd">
		/// The handle of the window whose thumbnail representation contains the toolbar to be updated. This handle must belong to the
		/// calling process.
		/// </param>
		/// <param name="himl">The handle of the image list that contains all button images to be used in the toolbar.</param>
		/// <remarks>
		/// Applications must provide these button images:
		/// <list type="bullet">
		/// <item>
		/// <term>The button in its default active state.</term>
		/// </item>
		/// <item>
		/// <term>Images suitable for use with high-dpi (dots per inch) displays.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Images must be 32-bit and of dimensions GetSystemMetrics(SM_CXICON) x GetSystemMetrics(SM_CYICON). The toolbar itself
		/// provides visuals for a button's clicked, disabled, and hover states.
		/// </para>
		/// </remarks>
		new void ThumbBarSetImageList(HWND hwnd, HIMAGELIST himl);

		/// <summary>Applies an overlay to a taskbar button to indicate application status or a notification to the user.</summary>
		/// <param name="hwnd">
		/// The handle of the window whose associated taskbar button receives the overlay. This handle must belong to a calling process
		/// associated with the button's application and must be a valid HWND or the call is ignored.
		/// </param>
		/// <param name="hIcon">
		/// The handle of an icon to use as the overlay. This should be a small icon, measuring 16x16 pixels at 96 dpi. If an overlay
		/// icon is already applied to the taskbar button, that existing overlay is replaced.
		/// <para>
		/// This value can be NULL.How a NULL value is handled depends on whether the taskbar button represents a single window or a
		/// group of windows.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the taskbar button represents a single window, the overlay icon is removed from the display.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the taskbar button represents a group of windows and a previous overlay is still available (received earlier than the
		/// current overlay, but not yet freed by a NULL value), then that previous overlay is displayed in place of the current overlay.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// It is the responsibility of the calling application to free hIcon when it is no longer needed.This can generally be done
		/// after you call SetOverlayIcon because the taskbar makes and uses its own copy of the icon.
		/// </para>
		/// </param>
		/// <param name="pszDescription">
		/// A pointer to a string that provides an alt text version of the information conveyed by the overlay, for accessibility purposes.
		/// </param>
		new void SetOverlayIcon(HWND hwnd, [Optional] HICON hIcon, [MarshalAs(UnmanagedType.LPWStr)] string? pszDescription);

		/// <summary>
		/// Specifies or updates the text of the tooltip that is displayed when the mouse pointer rests on an individual preview
		/// thumbnail in a taskbar button flyout.
		/// </summary>
		/// <param name="hwnd">
		/// The handle to the window whose thumbnail displays the tooltip. This handle must belong to the calling process.
		/// </param>
		/// <param name="pszTip">
		/// The pointer to the text to be displayed in the tooltip. This value can be NULL, in which case the title of the window
		/// specified by hwnd is used as the tooltip.
		/// </param>
		new void SetThumbnailTooltip(HWND hwnd, [MarshalAs(UnmanagedType.LPWStr)] string? pszTip);

		/// <summary>Selects a portion of a window's client area to display as that window's thumbnail in the taskbar.</summary>
		/// <param name="hwnd">The handle to a window represented in the taskbar.</param>
		/// <param name="prcClip">
		/// A pointer to a RECT structure that specifies a selection within the window's client area, relative to the upper-left corner
		/// of that client area. To clear a clip that is already in place and return to the default display of the thumbnail, set this
		/// parameter to NULL.
		/// </param>
		new void SetThumbnailClip(HWND hwnd, [Optional] PRECT? prcClip);

		/// <summary>
		/// Allows a tab to specify whether the main application frame window or the tab window should be used as a thumbnail or in the
		/// peek feature under certain circumstances.
		/// </summary>
		/// <param name="hwndTab">
		/// The handle of the tab window that is to have properties set. This handle must already be registered through RegisterTab.
		/// </param>
		/// <param name="stpFlags">
		/// One or more members of the STPFLAG enumeration that specify the displayed thumbnail and peek image source of the tab thumbnail.
		/// </param>
		void SetTabProperties(HWND hwndTab, STPFLAG stpFlags);
	}

	/// <summary>Initiates a building session for a custom Jump List.</summary>
	/// <typeparam name="T">
	/// A type of an interface to be retrieved, typically IID_IObjectArray, that will represent all items currently stored in the list of
	/// removed destinations for the application. This information is used to ensure that removed items are not part of the new Jump List.
	/// </typeparam>
	/// <param name="cdl">The <see cref="ICustomDestinationList"/> instance.</param>
	/// <param name="pcMaxSlots">
	/// A pointer that, when this method returns, points to the current user setting for the Number of recent items to display in Jump
	/// Lists option in the Taskbar and Start Menu Properties window. The default value is 10. This is the maximum number of destinations
	/// that will be shown, and it is a total of all destinations, regardless of category. More destinations can be added, but they will
	/// not be shown in the UI.
	/// <para>A Jump List will always show at least this many slots—destinations and, if there is room, tasks.</para>
	/// <para>
	/// This number does not include separators and section headers as long as the total number of separators and headers does not exceed
	/// four. Separators and section headers beyond the first four might reduce the number of destinations displayed if space is
	/// constrained. This number does not affect the standard command entries for pinning or unpinning, closing the window, or launching
	/// a new instance. It also does not affect tasks or pinned items, the number of which that can be displayed is based on the space
	/// available to the Jump List.
	/// </para>
	/// </param>
	/// <returns>
	/// When this method returns, contains the interface pointer requested. This is typically an IObjectArray, which represents a
	/// collection of IShellItem and IShellLink objects that represent the removed items.
	/// </returns>
	public static T BeginList<T>(this ICustomDestinationList cdl, out uint pcMaxSlots) where T : class => (T)cdl.BeginList(out pcMaxSlots, typeof(T).GUID);

	/// <summary>
	/// Retrieves the current list of destinations that have been removed by the user from the existing Jump List that this custom Jump
	/// List is meant to replace.
	/// </summary>
	/// <typeparam name="T">The type of the interface to retrieve, typically IID_IObjectArray.</typeparam>
	/// <param name="cdl">The <see cref="ICustomDestinationList"/> instance.</param>
	/// <returns>
	/// When this method returns, contains the interface pointer requested. This is typically an IObjectArray, which represents a
	/// collection of IShellItem or IShellLink objects that represent the items in the list of removed destinations.
	/// </returns>
	public static T GetRemovedDestinations<T>(this ICustomDestinationList cdl) where T : class => (T)cdl.GetRemovedDestinations(typeof(T).GUID);

	/// <summary>
	/// Used by methods of the ITaskbarList3 interface to define buttons used in a toolbar embedded in a window's thumbnail representation.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
	[PInvokeData("Shobjidl.h", MSDNShortId = "dd391559")]
	public struct THUMBBUTTON
	{
		/// <summary>The THBN clicked</summary>
		public const int THBN_CLICKED = 0x1800;

		/// <summary>
		/// A combination of THUMBBUTTONMASK values that specify which members of this structure contain valid data; other members are
		/// ignored, with the exception of iId, which is always required.
		/// </summary>
		public THUMBBUTTONMASK dwMask;

		/// <summary>The application-defined identifier of the button, unique within the toolbar.</summary>
		public uint iId;

		/// <summary>The zero-based index of the button image within the image list set through ITaskbarList3::ThumbBarSetImageList.</summary>
		public uint iBitmap;

		/// <summary>The handle of an icon to use as the button image.</summary>
		public HICON hIcon;

		/// <summary>
		/// A wide character array that contains the text of the button's tooltip, displayed when the mouse pointer hovers over the button.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szTip;

		/// <summary>A combination of THUMBBUTTONFLAGS values that control specific states and behaviors of the button.</summary>
		public THUMBBUTTONFLAGS dwFlags;

		/// <summary>The default</summary>
		public static THUMBBUTTON Default = new() { dwMask = THUMBBUTTONMASK.THB_FLAGS, dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN };
	}

	/// <summary>Class interface for ICustomDestinationList.</summary>
	[ComImport, Guid("77f10cf0-3db5-4966-b520-b7c54fd35ed6"), ClassInterface(ClassInterfaceType.None)]
	public class CDestinationList { }

	/// <summary>Class interface for ITaskbarList and derivatives.</summary>
	[ComImport, Guid("56FDF344-FD6D-11d0-958A-006097C9A090"), ClassInterface(ClassInterfaceType.None)]
	public class CTaskbarList { }
}