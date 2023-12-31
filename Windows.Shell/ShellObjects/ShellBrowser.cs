using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>The direction argument for NavigateFromHistory()</summary>
public enum NavigationLogDirection
{
	/// <summary>Navigates forward through the navigation log</summary>
	Forward,

	/// <summary>Navigates backward through the travel log</summary>
	Backward
}

/// <summary>Undocumented Flags used by <see cref="IShellFolderViewCB.MessageSFVCB"/> Callback Handler.</summary>
public enum SFVMUD
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	SFVM_SELECTIONCHANGED = 8,
	SFVM_DRAWMENUITEM = 9,
	SFVM_MEASUREMENUITEM = 10,
	SFVM_EXITMENULOOP = 11,
	SFVM_VIEWRELEASE = 12,
	SFVM_GETNAMELENGTH = 13,

	SFVM_WINDOWCLOSING = 16,
	SFVM_LISTREFRESHED = 17,
	SFVM_WINDOWFOCUSED = 18,
	SFVM_REGISTERCOPYHOOK = 20,
	SFVM_COPYHOOKCALLBACK = 21,

	SFVM_ADDINGOBJECT = 29,
	SFVM_REMOVINGOBJECT = 30,

	SFVM_GETCOMMANDDIR = 33,
	SFVM_GETCOLUMNSTREAM = 34,
	SFVM_CANSELECTALL = 35,

	SFVM_ISSTRICTREFRESH = 37,
	SFVM_ISCHILDOBJECT = 38,

	SFVM_GETEXTVIEWS = 40,

	SFVM_GET_CUSTOMVIEWINFO = 77,
	SFVM_ENUMERATEDITEMS = 79,                  // It seems this msg never gets sent, using Win 10 at least.
	SFVM_GET_VIEW_DATA = 80,
	SFVM_GET_WEBVIEW_LAYOUT = 82,
	SFVM_GET_WEBVIEW_CONTENT = 83,
	SFVM_GET_WEBVIEW_TASKS = 84,
	SFVM_GET_WEBVIEW_THEME = 86,
	SFVM_GETDEFERREDVIEWSETTINGS = 92,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>Indicates the viewing mode of the ShellBrowser</summary>
public enum ShellBrowserViewMode
{
	/// <summary>Choose the best view mode for the folder</summary>
	Auto = FOLDERVIEWMODE.FVM_AUTO,

	/// <summary>(New for Windows7)</summary>
	Content = FOLDERVIEWMODE.FVM_CONTENT,

	/// <summary>Object names and other selected information, such as the size or date last updated, are shown.</summary>
	Details = FOLDERVIEWMODE.FVM_DETAILS,

	/// <summary>The view should display medium-size icons.</summary>
	Icon = FOLDERVIEWMODE.FVM_ICON,

	/// <summary>Object names are displayed in a list view.</summary>
	List = FOLDERVIEWMODE.FVM_LIST,

	/// <summary>The view should display small icons.</summary>
	SmallIcon = FOLDERVIEWMODE.FVM_SMALLICON,

	/// <summary>The view should display thumbnail icons.</summary>
	Thumbnail = FOLDERVIEWMODE.FVM_THUMBNAIL,

	/// <summary>The view should display icons in a filmstrip format.</summary>
	ThumbStrip = FOLDERVIEWMODE.FVM_THUMBSTRIP,

	/// <summary>The view should display large icons.</summary>
	Tile = FOLDERVIEWMODE.FVM_TILE
}

/// <summary>
/// Encapsulates a <see cref="IShellBrowser"/>-Implementation within an <see cref="UserControl"/>. <br/><br/> Implements the following
/// Interfaces: <br/>
/// - <seealso cref="IWin32Window"/><br/>
/// - <seealso cref="IShellBrowser"/><br/>
/// - <seealso cref="Shell32.IServiceProvider"/><br/><br/> For more Information on used techniques see: <br/>
/// - <seealso href="https://www.codeproject.com/Articles/28961/Full-implementation-of-IShellBrowser"/><br/><br/><br/> Known Issues: <br/>
/// - Using windows 10, the virtual Quick-Access folder doesn't get displayed properly. It has to be grouped by "Group" (as shown in
/// Windows Explorer UI), but I couldn't find the OLE-Property for this. Also, if using Groups, the Frequent Files List doesn't have its
/// Icons. Maybe we have to bind to another version of ComCtrls to get this rendered properly - That's just an idea though, cause the
/// Collapse-/Expand-Icons of the Groups have the Windows Vista / Windows 7-Theme, not the Windows 10 Theme as I can see. <br/>
/// - DONE: Keyboard input doesn't work so far. <br/>
/// - DONE: Only Details-Mode should have column headers: (Using Shell32.FOLDERFLAGS.FWF_NOHEADERINALLVIEWS) <br/> https://stackoverflow.com/questions/11776266/ishellview-columnheaders-not-hidden-if-autoview-does-not-choose-details
/// - TODO: CustomDraw, when currently no shellView available <br/>
/// - DONE: Network folder: E_FAIL =&gt; DONE: Returning HRESULT.E_NOTIMPL from MessageSFVCB fixes this <br/>
/// - DONE: Disk Drive (empty): E_CANCELLED_BY_USER <br/>
/// - DONE: Disable header in Details view when grouping is enabled
/// - DONE: Creating ViewWindow using '.CreateViewWindow()' fails on Zip-Folders; =&gt; Fixed again by returning HRESULT.E_NOTIMPL from MessageSFVCB
/// - TODO: internal static readonly bool IsMinVista = Environment.OSVersion.Version.Major &gt;= 6; // TODO: We use one interface,
/// afaik, that only works in vista and above: IFolderView2
/// - TODO: Windows 10' Quick Access folder has a special type of grouping, can't find out how this works yet. As soon as we would be
/// able to get all the available properties for an particular item, we would be able found out how this grouping works. However, it
/// seems to be a special group, since folders are Tiles, whereas files are shown in Details mode.
/// - NOTE: The grouping is done by 'Group'. Activate it using "Group by-&gt;More-&gt;Group", and then do the grouping. However, the
/// Icons for 'Recent Files'-Group get lost.
/// - TODO: ViewMode-Property, Thumbnailsize =&gt; Set ThumbnailSize for Large, ExtraLarge, etc.
/// - DONE: Keyboard-Handling
/// - DONE: BrowseObject -&gt;Parent -&gt; Relative
/// - TODO: Properties in design editor!!!
/// - TODO: Write History correctly!
/// - TODO: Check getting / losing Focus! again
/// - TODO: Context-Menu -&gt; "Open File Location" doesn't work on folder "Quick Access"
/// - TODO: When columns get reordered in details mode, then navigate to another folder, then back =&gt; column content gets messed
///
/// NOTE: https://stackoverflow.com/questions/7698602/how-to-get-embedded-explorer-ishellview-to-be-browsable-i-e-trigger-browseobje
/// NOTE: https://stackoverflow.com/questions/54390268/getting-the-current-ishellview-user-is-interacting-with
/// NOTE: https://www.codeproject.com/Articles/35197/Undocumented-List-View-Features // IMPORTANT!
/// NOTE: https://answers.microsoft.com/en-us/windows/forum/windows_10-files-winpc/windows-10-quick-access-folders-grouped-separately/ecd4be4a-1847-4327-8c44-5aa96e0120b8
/// </summary>
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
[Description("A Shell object that displays a list of Shell Items.")]
[Guid("B8B0F852-9527-4CA8-AB1D-648AE95B618E")]
public class ShellBrowser : UserControl, IWin32Window, IShellBrowser, Shell32.IServiceProvider
{
	private const string defEmptyFolderText = "This folder is empty.";
	internal const int defaultThumbnailSize = 32;
	private const string processCmdKeyClassNameEdit = "Edit";
	private const int processCmdKeyClassNameMaxLength = 31;

	private readonly StringBuilder processCmdKeyClassName = new(processCmdKeyClassNameMaxLength + 1);

	/// <summary>Required designer variable.</summary>
	private IContainer components;

	private string emptyFolderText = defEmptyFolderText;
	private FOLDERSETTINGS folderSettings = new(FOLDERVIEWMODE.FVM_AUTO, FOLDERFLAGS.FWF_NOHEADERINALLVIEWS | FOLDERFLAGS.FWF_NOWEBVIEW | FOLDERFLAGS.FWF_USESEARCHFOLDER);
	private IStream? viewStateStream;
	private string? viewStateStreamIdentifier;

	/// <summary>Initializes a new instance of the <see cref="ShellBrowser"/> class.</summary>
	public ShellBrowser() : base()
	{
		InitializeComponent();

		History = new ShellNavigationHistory();
		Items = new ShellItemCollection(this, SVGIO.SVGIO_ALLVIEW);
		SelectedItems = new ShellItemCollection(this, SVGIO.SVGIO_SELECTION);
	}

	/// <summary>Fires when the Items collection changes.</summary>
	[Category("Action"), Description("Items changed.")]
	public event EventHandler? ItemsChanged;

	/// <summary>Fires when ShellBrowser has navigated to a new folder.</summary>
	[Category("Action"), Description("ShellBowser has navigated to a new folder.")]
	public event EventHandler<ShellBrowserNavigatedEventArgs>? Navigated;

	/// <summary>Fires when the SelectedItems collection changes.</summary>
	[Category("Behavior"), Description("Selection changed.")]
	public event EventHandler? SelectionChanged;

	/// <summary>The default text that is displayed when an empty folder is shown</summary>
	[Category("Appearance"), DefaultValue(defEmptyFolderText), Description("The default text that is displayed when an empty folder is shown.")]
	public string EmptyFolderText
	{
		get => emptyFolderText;
		set
		{
			emptyFolderText = value;

			if (IsHandlerValid)
				ViewHandler!.Text = value;
		}
	}

	/// <summary>Contains the navigation history of the ShellBrowser</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ShellNavigationHistory History { get; private set; }

	/// <summary>The set of ShellItems in the ShellBrowser</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IReadOnlyList<ShellItem> Items { get; }

	/// <summary>The set of selected ShellItems in the ShellBrowser</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IReadOnlyList<ShellItem> SelectedItems { get; }

	/// <summary>The size of the thumbnails in pixels.</summary>
	[Category("Appearance"), DefaultValue(defaultThumbnailSize), Description("The size of the thumbnails in pixels.")]
	public int ThumbnailSize
	{
		get => IsHandlerValid ? ViewHandler!.ThumbnailSize : defaultThumbnailSize;
		set
		{
			if (IsHandlerValid)
				ViewHandler!.ThumbnailSize = value;
		}
	}

	/// <summary>The viewing mode of the ShellBrowser</summary>
	/// <remarks>Internally, this uses LVM_SETVIEW and LVM_GETVIEW messages on the ListView control</remarks>
	[Category("Appearance"), DefaultValue(typeof(ShellBrowserViewMode), "Auto"), Description("The viewing mode of the ShellBrowser.")]
	public ShellBrowserViewMode ViewMode
	{
		get => (ShellBrowserViewMode)folderSettings.ViewMode;
		set
		{
			// TODO: Set ThumbnailSize accordingly?
			folderSettings.ViewMode = (FOLDERVIEWMODE)value;

			if (IsHandlerValid)
				ViewHandler!.ViewMode = folderSettings.ViewMode;
		}
	}

	/// <summary>The Registry Key where Browser ViewStates get serialized</summary>
	/// <example>Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Streams\\</example>
	[Category("Behavior"), Description("The Registry Key where Browser ViewStates get serialized.")]
	public string ViewStateRegistryKey { get; set; } =
		$"Software\\{Application.CompanyName}\\{Application.ProductName}\\ShellBrowser\\ViewStateStreams";

	/// <summary>
	/// <inheritdoc/><br/><br/>
	/// Note: I've tried using ComCtl32.ListViewMessage.LVM_SETBKIMAGE, but this doesn't work properly. That's why this property has
	/// been hidden.
	/// </summary>
	[Bindable(false), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Image BackgroundImage => base.BackgroundImage!;

	/// <inheritdoc/>
	protected override Size DefaultSize => new(200, 150);

	/// <summary>The <see cref="ShellBrowserViewHandler"/> that is currently in use.</summary>
	protected ShellBrowserViewHandler? ViewHandler { get; private set; }

	/// <summary></summary>
	/// <param name="pidl"></param>
	/// <param name="wFlags"></param>
	/// <returns>HRESULT.STG_E_PATHNOTFOUND if path n found</returns>
	public HRESULT BrowseObject(IntPtr pidl, SBSP wFlags)
	{
		ShellItem? shellObject = null;

		// The given PIDL equals Desktop, so ignore the other flags
		if (ShellFolder.Desktop.PIDL.Equals(pidl))
		{
			shellObject = new ShellItem(ShellFolder.Desktop.PIDL);
		}

		// SBSP_NAVIGATEBACK stands for the last item in the navigation history list (and ignores the pidl)
		else if (wFlags.HasFlag(SBSP.SBSP_NAVIGATEBACK))
		{
			if (History.CanSeekBackward)
				shellObject = History.SeekBackward();
			else
				return HRESULT.STG_E_PATHNOTFOUND;
		}

		// SBSP_NAVIGATEFORWARD stands for the next item in the navigation history list (and ignores the pidl)
		else if (wFlags.HasFlag(SBSP.SBSP_NAVIGATEFORWARD))
		{
			if (History.CanSeekForward)
				shellObject = History.SeekForward();
			else
				return HRESULT.STG_E_PATHNOTFOUND;
		}

		// SBSP_RELATIVE stands for a pidl relative to the current folder
		else if (wFlags.HasFlag(SBSP.SBSP_RELATIVE))
		{
			ShellItem? currentObject = History.Current;
			if (currentObject is null)
				return HRESULT.STG_E_PATHNOTFOUND;

			shellObject = new ShellItem(ILCombine((IntPtr)currentObject.PIDL, pidl));
		}

		// SBSP_PARENT stands for the parent folder (and ignores the pidl)
		else if (wFlags.HasFlag(SBSP.SBSP_PARENT))
		{
			ShellItem? currentObject = History.Current;
			ShellFolder? parentObject = currentObject?.Parent;

			if ((parentObject is not null) && parentObject.PIDL.IsParentOf(currentObject!.PIDL))
				shellObject = parentObject;
			else
				return HRESULT.STG_E_PATHNOTFOUND;
		}

		// SBSP_ABSOLUTE as the remaining option stands for an absolute pidl that is given
		else
		{
			// Remember we are not the owner of this pidl, so clone it to have our own copy on the heap.
			shellObject = new ShellItem(new PIDL(pidl, true));
		}

		if (InvokeRequired)
			BeginInvoke(() => BrowseShellItemInternal(shellObject!));
		else
			BrowseShellItemInternal(shellObject!);

		return HRESULT.S_OK;

		void BrowseShellItemInternal(ShellItem shellItem)
		{
			// Save ViewState of current folder
			GetValidHandler()?.ShellView?.SaveViewState();

			if (viewStateStream is not null)
				Marshal.ReleaseComObject(viewStateStream);

			viewStateStreamIdentifier = shellItem.ParsingName;

			var viewHandler = new ShellBrowserViewHandler(this, new ShellFolder(shellItem), folderSettings, emptyFolderText);

			// Clone the PIDL, to have our own object copy on the heap!
			if (!wFlags.HasFlag(SBSP.SBSP_WRITENOHISTORY))
				History.Add(new ShellItem(new PIDL(viewHandler.ShellFolder.PIDL)));

			ShellBrowserViewHandler? oldViewHandler = ViewHandler;
			ViewHandler = viewHandler;
			oldViewHandler?.UIDeactivate();
			viewHandler.UIActivate();
			oldViewHandler?.DestroyView();

			OnNavigated(viewHandler.ShellFolder);
			OnSelectionChanged();
		}
	}

	/// <inheritdoc/>
	public HRESULT ContextSensitiveHelp(bool fEnterMode) => HRESULT.E_NOTIMPL;

	/// <inheritdoc/>
	public HRESULT EnableModelessSB(bool fEnable) => HRESULT.E_NOTIMPL;

	/// <inheritdoc/>
	public HRESULT GetControlWindow(FCW id, out HWND hwnd)
	{
		hwnd = HWND.NULL;
		return HRESULT.E_NOTIMPL;
	}

	/// <inheritdoc/>
	public HRESULT GetViewStateStream(STGM grfMode, [MaybeNull] out IStream stream)
	{
		if (viewStateStream is not null)
			Marshal.ReleaseComObject(viewStateStream);
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		stream = viewStateStream = ShlwApi.SHOpenRegStream2(HKEY.HKEY_CURRENT_USER, ViewStateRegistryKey, viewStateStreamIdentifier, grfMode);
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
		return stream is null ? HRESULT.E_FAIL : HRESULT.S_OK;
	}

	/// <inheritdoc/>
	public HRESULT GetWindow(out HWND phwnd)
	{
		phwnd = Handle;
		return HRESULT.S_OK;
	}

	/// <inheritdoc/>
	public HRESULT InsertMenusSB(HMENU hmenuShared, ref Ole32.OLEMENUGROUPWIDTHS lpMenuWidths) => HRESULT.E_NOTIMPL;

	/// <summary>
	/// Navigates to the last item in the navigation history list. This does not change the set of locations in the navigation log.
	/// </summary>
	/// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
	public bool NavigateBack() => BrowseObject(IntPtr.Zero, SBSP.SBSP_NAVIGATEBACK).Succeeded;

	/// <summary>
	/// Navigates to the next item in the navigation history list. This does not change the set of locations in the navigation log.
	/// </summary>
	/// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
	public bool NavigateForward() => BrowseObject(IntPtr.Zero, SBSP.SBSP_NAVIGATEFORWARD).Succeeded;

	/// <summary>
	/// Navigate within the navigation log in a specific direciton. This does not change the set of locations in the navigation log.
	/// </summary>
	/// <param name="direction">The direction to navigate within the navigation logs collection.</param>
	/// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
	public bool NavigateFromHistory(NavigationLogDirection direction) => direction switch
	{
		NavigationLogDirection.Backward => NavigateBack(),
		NavigationLogDirection.Forward => NavigateForward(),
		_ => false,
	};

	/// <summary>Navigates to the parent folder.</summary>
	/// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
	public bool NavigateParent() => BrowseObject(IntPtr.Zero, SBSP.SBSP_PARENT).Succeeded;

	/// <summary>Navigate within the navigation log. This does not change the set of locations in the navigation log.</summary>
	/// <param name="historyIndex">An index into the navigation logs Locations collection.</param>
	/// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
	public bool NavigateToHistoryIndex(int historyIndex)
	{
		using ShellItem? shellFolder = History.Seek(historyIndex, SeekOrigin.Current);
		return shellFolder is not null && BrowseObject((IntPtr)shellFolder.PIDL, SBSP.SBSP_ABSOLUTE | SBSP.SBSP_WRITENOHISTORY).Succeeded;
	}

	/// <inheritdoc/>
	public HRESULT OnViewWindowActive(IShellView ppshv) => HRESULT.E_NOTIMPL;

	/// <inheritdoc/>
	public HRESULT QueryActiveShellView([MaybeNull] out IShellView shellView)
	{
		if (IsHandlerValid)
		{
			Marshal.AddRef(Marshal.GetIUnknownForObject(ViewHandler!.ShellView!));
			shellView = ViewHandler.ShellView;
			return HRESULT.S_OK;
		}

		shellView = null;
		return HRESULT.E_PENDING;
	}

	/// <inheritdoc/>
	public HRESULT RemoveMenusSB(HMENU hmenuShared) => HRESULT.E_NOTIMPL;

	/// <summary>Selects all items in the current view.</summary>
	public void SelectAll()
	{
		ShellBrowserViewHandler? viewHandler = GetValidHandler();
		if (viewHandler is not null)
		{
			// NOTE: The for-loop is rather slow, so send (Ctrl+A)-KeyDown-Message instead and let the ShellView do the work for (var i
			// = 0; i < viewHandler.FolderView2.ItemCount(SVGIO.SVGIO_ALLVIEW); i++) viewHandler.FolderView2.SelectItem(i, SVSIF.SVSI_SELECT);
			//
			// TODO: Another way would be to use this Windows Message-Pattern (Workaround #2): https://stackoverflow.com/questions/9039989/how-to-selectall-in-a-winforms-virtual-listview

			var msg = new Message()
			{
				HWnd = (IntPtr)viewHandler.ViewWindow,
				Msg = (int)User32.WindowMessage.WM_KEYDOWN,
			};

			ProcessCmdKey(ref msg, Keys.Control | Keys.A);
		}
	}

	/// <inheritdoc/>
	public HRESULT SendControlMsg(FCW id, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr pret)
	{
		pret = IntPtr.Zero;
		return HRESULT.E_NOTIMPL;
	}

	/// <inheritdoc/>
	public HRESULT SetMenuSB(HMENU hmenuShared, IntPtr holemenuRes, HWND hwndActiveObject) => HRESULT.E_NOTIMPL;

	/// <inheritdoc/>
	public HRESULT SetStatusTextSB(string pszStatusText) => HRESULT.E_NOTIMPL;

	/// <inheritdoc/>
	public HRESULT SetToolbarItems(ComCtl32.TBBUTTON[]? lpButtons, uint nButtons, FCT uFlags) => HRESULT.E_NOTIMPL;

	/// <inheritdoc/>
	public HRESULT TranslateAcceleratorSB(ref MSG pmsg, ushort wID) => HRESULT.E_NOTIMPL;

	/// <summary>Unselects all items in the current view.</summary>
	public void UnselectAll() => GetValidHandler()?.FolderView2?.SelectItem(-1, SVSIF.SVSI_DESELECTOTHERS);

	/// <summary>
	/// <see cref="Shell32.IServiceProvider"/>-Interface Implementation for <see cref="ShellBrowser"/>. <br/><br/> Responds to the
	/// following Interfaces: <br/>
	/// - <see cref="IShellBrowser"/><br/>
	/// - <see cref="IShellFolderViewCB"/><br/>
	/// </summary>
	/// <param name="guidService">The service's unique identifier (SID).</param>
	/// <param name="riid">The IID of the desired service interface.</param>
	/// <param name="ppvObject">
	/// When this method returns, contains the interface pointer requested riid. If successful, the calling application is responsible
	/// for calling IUnknown::Release using this value when the service is no longer needed. In the case of failure, this value is NULL.
	/// </param>
	/// <returns><see cref="HRESULT.S_OK"/> or <br/><see cref="HRESULT.E_NOINTERFACE"/></returns>
	HRESULT Shell32.IServiceProvider.QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject)
	{
		// IShellBrowser: Guid("000214E2-0000-0000-C000-000000000046")
		if (riid.Equals(typeof(IShellBrowser).GUID))
		{
			ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IShellBrowser));

			return HRESULT.S_OK;
		}

		// IShellFolderViewCB: Guid("2047E320-F2A9-11CE-AE65-08002B2E1262")
		if (riid.Equals(typeof(IShellFolderViewCB).GUID))
		{
			ShellBrowserViewHandler? shvwHandler = GetValidHandler();
			if (shvwHandler is not null)
			{
				ppvObject = Marshal.GetComInterfaceForObject(shvwHandler, typeof(IShellFolderViewCB));
				return HRESULT.S_OK;
			}
		}

		ppvObject = IntPtr.Zero;
		return HRESULT.E_NOINTERFACE;
	}

	/// <summary>Gets the items in the ShellBrowser as an IShellItemArray</summary>
	/// <returns>An <see cref="IShellItemArray"/> instance or <see langword="null"/> if not available.</returns>
	internal IShellItemArray? GetItemsArray(SVGIO opt)
	{
		try
		{
			return GetValidHandler()?.FolderView2?.Items<IShellItemArray>(opt) ?? null;
		}
		catch { return null; }
	}

	/// <summary>Raises the <see cref="ItemsChanged"/> event.</summary>
	protected internal virtual void OnItemsChanged() => ItemsChanged?.Invoke(this, EventArgs.Empty);

	/// <summary>Raises the <see cref="Navigated"/> event.</summary>
	protected internal virtual void OnNavigated(ShellFolder shellFolder)
	{
		if (Navigated is not null)
		{
			ShellBrowserNavigatedEventArgs eventArgs = new(shellFolder);

			Navigated.Invoke(this, eventArgs);
		}
	}

	/// <summary>Raises the <see cref="SelectionChanged"/> event.</summary>
	protected internal virtual void OnSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

	/// <summary>Clean up any resources being used.</summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components is not null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	/// <summary>Raises the <see cref="E:HandleDestroyed"/> event. Saves ViewState when ShellBrowser gets closed.</summary>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected override void OnHandleDestroyed(EventArgs e)
	{
		GetValidHandler()?.ShellView?.SaveViewState();
		base.OnHandleDestroyed(e);
	}

	/// <summary>Raises the <see cref="E:Resize"/> event. Resize ViewWindow when ShellBrowser gets resized.</summary>
	/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected override void OnResize(EventArgs e)
	{
		ViewHandler?.MoveWindow(0, 0, ClientRectangle.Width, ClientRectangle.Height, false);
		base.OnResize(e);
	}

	/// <summary>Process known command keys of the ShellBrowser.</summary>
	/// <param name="msg">Windows Message</param>
	/// <param name="keyData">Key codes and modifiers</param>
	/// <returns>true if character was processed by the control; otherwise, false</returns>
	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		// We have to take special care when the ShellView is currently renaming an item: If message's sender equals class 'Edit', and
		// its parent window is our ViewWindow, the ShellView is currently showing an Edit-field to let the User edit an item's name.
		// Thus, we have to pass all Key Strokes directly to the ShellView.

		if (IsHandlerValid)
		{
			// Note: I tried using the LVM_GETEDITCONTROL message for finding the edit control without luck
			if (User32.GetClassName(msg.HWnd,
				processCmdKeyClassName,
				processCmdKeyClassNameMaxLength) > 0)
			{
				if (processCmdKeyClassName.ToString().Equals(processCmdKeyClassNameEdit))
				{
					// Try to get Edit field's parent 'SysListView32' handle
					HWND hSysListView32 = User32.GetParent(msg.HWnd);

					if (!hSysListView32.IsNull)
					{
						// Try to get SysListView32's parent 'SHELLDLL_DefView' handle
						HWND hShellDllDefViewWindow = User32.GetParent(hSysListView32);

						if (!hShellDllDefViewWindow.IsNull && (hShellDllDefViewWindow == ViewHandler!.ViewWindow))
						{
							ViewHandler.ShellView!.TranslateAccelerator(new MSG(msg.HWnd, (uint)msg.Msg, msg.WParam, msg.LParam));
							return true;
						}
					}
				}
			}
		}

		// Process tab key for control focus cycle: Tab => Focus next control Tab + Shift => Focus previous control
		if ((keyData & Keys.KeyCode) == Keys.Tab)
		{
			var forward = (keyData & Keys.Shift) != Keys.Shift;

			Parent!.SelectNextControl(ActiveControl, forward: forward, tabStopOnly: true, nested: true, wrap: true);

			return true;
		}

		// Process folder navigation shortcuts: Alt + Left OR BrowserBack => Navigate back in history Alt + Right OR BrowserForward =>
		// Navigate forward in history Backspace => Navigate to parent folder
		switch (keyData)
		{
			case Keys.BrowserBack:
			case Keys.Alt | Keys.Left:
				NavigateBack();

				return true;

			case Keys.BrowserForward:
			case Keys.Alt | Keys.Right:
				NavigateForward();

				return true;

			case Keys.Back:
				NavigateParent();

				return true;
		}

		// Let the ShellView process all other keystrokes
		if (IsHandlerValid)
		{
			ViewHandler!.ShellView!.TranslateAccelerator(new MSG(msg.HWnd, (uint)msg.Msg, msg.WParam, msg.LParam));
			return true;
		}

		return base.ProcessCmdKey(ref msg, keyData);
	}

	/// <summary>Required method for Designer support - do not modify the contents of this method with the code editor.</summary>
	[MemberNotNull(nameof(components))]
	private void InitializeComponent()
	{
		components = new Container();
		AutoScaleMode = AutoScaleMode.Font;
	}

	private ShellBrowserViewHandler? GetValidHandler() => IsHandlerValid ? ViewHandler : null;

	private bool IsHandlerValid => ViewHandler is not null && IsHandlerValid;

	/// <summary>Represents a collection of <see cref="ShellItem"/> attached to an <see cref="ShellBrowser"/>.</summary>
	private class ShellItemCollection : IReadOnlyList<ShellItem>
	{
		private readonly SVGIO option;
		private readonly ShellBrowser shellBrowser;

		internal ShellItemCollection(ShellBrowser shellBrowser, SVGIO opt)
		{
			this.shellBrowser = shellBrowser;
			option = opt;
		}

		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>Returns a <see cref="int"/> value.</value>
		public int Count => shellBrowser.GetValidHandler()?.FolderView2!.ItemCount(option) ?? 0;

		private IShellItemArray? Array => shellBrowser.GetItemsArray(option);

		private IEnumerable<IShellItem> Items
		{
			get
			{
				IShellItemArray? array = Array;

				if (array is null)
					yield break;
				try
				{
					for (uint i = 0; i < array.GetCount(); i++)
						yield return array.GetItemAt(i);
				}
				finally
				{
					Marshal.ReleaseComObject(array);
				}
			}
		}

		/// <summary>Gets the <see cref="ShellItem"/> at the specified index.</summary>
		/// <value>The <see cref="ShellItem"/>.</value>
		/// <param name="index">The zero-based index of the element to get.</param>
		public ShellItem this[int index]
		{
			get
			{
				IShellItemArray? array = Array;
				try
				{
					if (array is not null)
						return ShellItem.Open(array.GetItemAt((uint)index));
				}
				catch { }
				finally
				{
					if (array is not null)
						Marshal.ReleaseComObject(array);
				}
				throw new ArgumentOutOfRangeException(nameof(index));
			}
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<ShellItem> GetEnumerator() => Items.Select(ShellItem.Open).GetEnumerator();

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

/// <summary>Event argument for The Navigated event.</summary>
public class ShellBrowserNavigatedEventArgs : EventArgs
{
	/// <summary>Initializes a new instance of the <see cref="ShellBrowserNavigatedEventArgs"/> class.</summary>
	public ShellBrowserNavigatedEventArgs(ShellFolder currentFolder) => CurrentFolder = currentFolder ?? throw new ArgumentNullException(nameof(currentFolder));

	/// <summary>The new location of the ShellBrowser</summary>
	public ShellFolder CurrentFolder { get; }
}

/// <summary>
/// Encapsulates an <see cref="IShellFolderViewCB">IShellFolderViewCB</see>-Implementation within an <see cref="IDisposable"/>-Object.
/// Beside that it's implemented as a Wrapper-Object that is responsible for creating and disposing the following objects aka
/// Interface-Instances: <br/>
/// - <seealso cref="Shell.ShellFolder"/><br/>
/// - <seealso cref="IShellView"/><br/>
/// - <seealso cref="IFolderView2"/><br/><br/> While doing that, it also handles some common error cases: <br/>
/// - When there's no disk in a disk drive <br/><br/> Implements the following Interfaces: <br/>
/// - <seealso cref="IShellFolderViewCB"/><br/><br/> This class make use of some <see cref="SFVMUD">undocumented Messages</see> in its
/// <see cref="IShellFolderViewCB.MessageSFVCB"/> Callback Handler. <br/><br/> For more Information on these see: <br/>
/// - Google Drive Shell Extension: <seealso href="https://github.com/google/google-drive-shell-extension/blob/master/DriveFusion/ShellFolderViewCBHandler.cpp"> ShellFolderViewCBHandler.cpp</seealso><br/>
/// - ReactOS: <seealso href="https://doxygen.reactos.org/d2/dbb/IShellFolderViewCB_8cpp.html">IShellFolderViewCB.cpp File Reference
/// </seealso>, <seealso href="https://doxygen.reactos.org/d2/dbb/IShellFolderViewCB_8cpp_source.html">IShellFolderViewCB.cpp</seealso>
/// </summary>
public class ShellBrowserViewHandler : IShellFolderViewCB
{
	/// <summary>
	/// <code>{"The operation was canceled by the user. (Exception from HRESULT: 0x800704C7)"}</code>
	/// is the result of a call to <see cref="IShellView.CreateViewWindow"/> on a Shell Item that targets a removable Disk Drive when
	/// currently no Media is present. Let's catch these to use our own error handling for this.
	/// </summary>
	internal static readonly HRESULT HRESULT_CANCELLED = new(0x800704C7);

	private string? text;
	private int thumbnailSize = ShellBrowser.defaultThumbnailSize;

	/// <summary>Create an instance of <see cref="ShellBrowserViewHandler"/> to handle Callback messages for the given ShellFolder.</summary>
	/// <param name="owner">The <see cref="ShellBrowser"/> that is owner of this instance.</param>
	/// <param name="shellFolder">The ShellFolder for the view.</param>
	/// <param name="folderSettings">The folder settings for the view.</param>
	/// <param name="emptyFolderText">Text to display if the folder is empty.</param>
	public ShellBrowserViewHandler(ShellBrowser owner, ShellFolder shellFolder, FOLDERSETTINGS folderSettings, string emptyFolderText)
	{
		Owner = owner ?? throw new ArgumentNullException(nameof(owner));
		ShellFolder = shellFolder ?? throw new ArgumentNullException(nameof(shellFolder));

		// Create ShellView and FolderView2 objects, then its ViewWindow
		try
		{
			SFV_CREATE sfvCreate = new()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(SFV_CREATE)),
				pshf = shellFolder.IShellFolder,
				psvOuter = null,
				psfvcb = this,
			};
#pragma warning disable IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
			SHCreateShellFolderView(sfvCreate, out IShellView? shellView).ThrowIfFailed();
#pragma warning restore IL2050 // Correctness of COM interop cannot be guaranteed after trimming. Interfaces and interface members might be removed.
			ShellView = shellView ?? throw new InvalidComObjectException(nameof(ShellView));

			FolderView2 = ShellView as IFolderView2 ?? throw new InvalidComObjectException(nameof(FolderView2));

			// Try to create ViewWindow and take special care of Exception {"The operation was canceled by the user. (Exception from
			// HRESULT: 0x800704C7)"} cause this happens when there's no disk in a drive.
			try
			{
				ViewWindow = ShellView.CreateViewWindow(null, folderSettings, owner, owner.ClientRectangle);

				IsValid = true;

				Text = emptyFolderText;
			}
			catch (COMException ex)
			{
				// TODO: Check if the target folder IS actually a drive with removable disks in it!
				if (HRESULT_CANCELLED.Equals(ex.ErrorCode))
					NoDiskInDriveError = true;
				throw;
			}
		}
		catch (COMException ex)
		{
			// TODO: e.g. C:\Windows\CSC => Permission denied! 0x8007 0005 E_ACCESSDENIED
			ValidationError = ex;
		}
	}

	/// <summary>The <see cref="IFolderView2"/>.</summary>
	public IFolderView2? FolderView2 { get; private set; }

	/// <summary>Indicates that no error occured while creating this instance, i.e. the View is fully functional.</summary>
	public bool IsValid { get; private set; }

	/// <summary>Indicates that an "No Disk In Drive"-error occured while creating this instance.</summary>
	public bool NoDiskInDriveError { get; }

	/// <summary>The owner of this instance of <see cref="ShellBrowserViewHandler"/>, i.e. the <see cref="ShellBrowser"/>.</summary>
	public ShellBrowser Owner { get; }

	/// <summary>The <see cref="ShellFolder"/>.</summary>
	public ShellFolder ShellFolder { get; private set; }

	/// <summary>The <see cref="IShellView"/>.</summary>
	public IShellView? ShellView { get; private set; }

	/// <summary>The default text to be used when there are no items in the view.</summary>
	public string? Text
	{
		get => text;
		set
		{
			text = value;

			if (IsValid)
				FolderView2!.SetText(FVTEXTTYPE.FVST_EMPTYTEXT, value);
		}
	}

	/// <summary>The size of the thumbnails in pixels.</summary>
	public int ThumbnailSize
	{
		get
		{
			if (IsValid)
				FolderView2!.GetViewModeAndIconSize(out _, out thumbnailSize);

			return thumbnailSize;
		}
		set
		{
			if (IsValid)
			{
				FolderView2!.GetViewModeAndIconSize(out FOLDERVIEWMODE fvm, out _);
				FolderView2!.SetViewModeAndIconSize(fvm, thumbnailSize = value);
			}
		}
	}

	/// <summary>The <see cref="COMException"/> that occured, if creation of the instance failed.</summary>
	public COMException? ValidationError { get; private set; }

	/// <summary>The viewing mode of the ShellBrowser.</summary>
	public FOLDERVIEWMODE ViewMode
	{
		get
		{
			if (IsValid)
			{
				return FolderView2!.GetCurrentViewMode();
				// TODO: Check ThumbNailSize for new ViewModes with larger sized icons
			}

			return FOLDERVIEWMODE.FVM_AUTO;     // TODO!
		}
		set
		{
			if (IsValid)
				FolderView2!.SetCurrentViewMode(value);
		}
	}

	/// <summary>The ViewWindow.</summary>
	public HWND ViewWindow { get; private set; }

	/// <summary>Destroy the view.</summary>
	public void DestroyView()
	{
		IsValid = false;

		// TODO: Remove MessageSFVCB here!

		// Destroy ShellView's ViewWindow
		ViewWindow = HWND.NULL;
		ShellView?.DestroyViewWindow();

		FolderView2 = null;
		ShellView = null;
		//this.ShellFolder = null;      // NOTE: I >>think<< this one causes RPC-Errors
	}

	/// <summary>Changes the position and dimensions of this <see cref="ViewWindow"/>.</summary>
	/// <param name="X">Left</param>
	/// <param name="Y">Top</param>
	/// <param name="nWidth">Width</param>
	/// <param name="nHeight">Height</param>
	/// <param name="bRepaint">Force redraw</param>
	/// <returns>If the function succeeds, the return value is nonzero.</returns>
	public bool MoveWindow(int X, int Y, int nWidth, int nHeight, bool bRepaint) =>
		ViewWindow != HWND.NULL && User32.MoveWindow(ViewWindow, X, Y, nWidth, nHeight, bRepaint);

	/// <summary>Activate the ShellView of this ShellBrowser.</summary>
	/// <param name="uState">The <seealso cref="SVUIA"/> to be set</param>
	public void UIActivate(SVUIA uState = SVUIA.SVUIA_ACTIVATE_NOFOCUS) => ShellView?.UIActivate(uState);

	/// <summary>Deactivate the ShellView of this ShellBrowser.</summary>
	public void UIDeactivate() => UIActivate(SVUIA.SVUIA_DEACTIVATE);

	/// <summary>Allows communication between the system folder view object and a system folder view callback object.</summary>
	/// <param name="uMsg">One of the SFVM_* notifications.</param>
	/// <param name="wParam">Additional information. See the individual notification pages for specific requirements.</param>
	/// <param name="lParam">Additional information. See the individual notification pages for specific requirements.</param>
	/// <param name="plResult">TODO: @dahall: Where does this come from?</param>
	/// <returns><b>S_OK</b> if the notification has been handled. <b>E_NOTIMPL</b> otherwise.</returns>
	HRESULT IShellFolderViewCB.MessageSFVCB(SFVM uMsg, IntPtr wParam, IntPtr lParam, ref IntPtr plResult)
	{
		switch ((SFVMUD)uMsg)
		{
			case SFVMUD.SFVM_SELECTIONCHANGED:
				Owner.OnSelectionChanged();
				return HRESULT.S_OK;

			case SFVMUD.SFVM_LISTREFRESHED:
				Owner.OnItemsChanged();
				return HRESULT.S_OK;

			default:
				// TODO: What happens when the ViewMode gets changed via Context-Menu? => Msg #33, #18
				return HRESULT.E_NOTIMPL;
		}
	}
}