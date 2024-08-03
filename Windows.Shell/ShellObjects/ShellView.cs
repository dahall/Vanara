using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Event argument for FilterItem event</summary>
public class FilterShellItemEventArgs : EventArgs
{
	/// <summary>Initializes a new instance of the <see cref="NavigatedEventArgs"/> class.</summary>
	/// <param name="item">The shell item.</param>
	public FilterShellItemEventArgs(ShellItem item) => Item = item;

	/// <summary>Gets or sets a value indicating whether a <see cref="ShellItem"/> is included by the filter.</summary>
	/// <value><see langword="true"/> if included; otherwise, <see langword="false"/>.</value>
	public bool Include { get; set; } = true;

	/// <summary>The new location of the explorer browser</summary>
	public ShellItem Item { get; private set; }
}

/// <summary>Event argument for The Navigated event</summary>
public class NavigatedEventArgs : EventArgs
{
	/// <summary>Initializes a new instance of the <see cref="NavigatedEventArgs"/> class.</summary>
	/// <param name="folder">The folder.</param>
	public NavigatedEventArgs(ShellFolder folder) => NewLocation = folder;

	/// <summary>The new location of the explorer browser</summary>
	public ShellItem NewLocation { get; private set; }
}

/// <summary>Event argument for The Navigating event</summary>
public class NavigatingEventArgs : CancelEventArgs
{
	/// <summary>Initializes a new instance of the <see cref="NavigatingEventArgs"/> class.</summary>
	/// <param name="pendingLocation">The pending location.</param>
	public NavigatingEventArgs(ShellItem pendingLocation) => PendingLocation = pendingLocation;

	/// <summary>The location being navigated to.</summary>
	public ShellItem PendingLocation { get; private set; }
}

/// <summary>Event argument for the NavigatinoFailed event</summary>
public class NavigationFailedEventArgs : EventArgs
{
	/// <summary>The location the browser would have navigated to.</summary>
	public ShellItem? FailedLocation { get; set; }
}

/// <summary>Encapsulates IShellView for display as a control.</summary>
/// <seealso cref="IComparable{T}"/>
/// <seealso cref="IDisposable"/>
/// <seealso cref="IEquatable{T}"/>
/// <seealso cref="IEquatable{T}"/>
/// <seealso cref="INotifyPropertyChanged"/>
// TODO: Fix problems with IShellView.CreateViewWindow returning E_FAIL
internal class ShellView : Control, INotifyPropertyChanged
{
	internal HWND shellViewWindow;
	private ShellFolder? currentFolder;
	private IShellBrowser? iBrowser;
	private IShellView? iShellView;

	/// <summary>Creates a new <see cref="ShellView"/> from a shell folder and assigns it to a window.</summary>
	/// <param name="folder">The shell folder.</param>
	/// <returns>A new <see cref="ShellView"/> instance for the supplied shell folder.</returns>
	public ShellView(ShellFolder folder) : this() => currentFolder = folder;

	/// <summary>Initializes a new instance of the <see cref="ShellView"/> class.</summary>
	public ShellView() => History = new ShellNavigationHistory();

	/// <summary>Initializes a new instance of the <see cref="ShellView"/> class.</summary>
	/// <param name="baseInterface">The base interface.</param>
	internal ShellView(IShellView baseInterface) : this() => IShellView = baseInterface;

	/// <summary>Fires when determining if an item should be shown in the view.</summary>
	[Category("Action"), Description("Filter items in the view.")]
	public event EventHandler<FilterShellItemEventArgs>? FilterItem;

	/// <summary>Fires when the Items collection changes.</summary>
	[Category("Action"), Description("Items changed.")]
	public event EventHandler? ItemsChanged;

	/// <summary>Fires when the ExplorerBrowser view has finished enumerating files.</summary>
	[Category("Behavior"), Description("View is done enumerating files.")]
	public event EventHandler? ItemsEnumerated;

	/// <summary>
	/// Fires when a navigation has been 'completed': no Navigating listener has canceled, and the ExplorerBrowser has created a new
	/// view. The view will be populated with new items asynchronously, and ItemsChanged will be fired to reflect this some time later.
	/// </summary>
	[Category("Action"), Description("Navigation complete.")]
	public event EventHandler<NavigatedEventArgs>? Navigated;

	/// <summary>Fires when a navigation has been initiated, but is not yet complete.</summary>
	[Category("Action"), Description("Navigation initiated, but not complete.")]
	public event EventHandler<NavigatingEventArgs>? Navigating;

	/// <summary>
	/// Fires when either a Navigating listener cancels the navigation, or if the operating system determines that navigation is not possible.
	/// </summary>
	[Category("Action"), Description("Navigation failed.")]
	public event EventHandler<NavigationFailedEventArgs>? NavigationFailed;

	/// <summary>Occurs when a property value changes.</summary>
	[Category("Behavior"), Description("Property changed.")]
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>Fires when the item selected in the view has changed (i.e., a rename ). This is not the same as SelectionChanged.</summary>
	[Category("Action"), Description("Selected item has changed.")]
	public event EventHandler? SelectedItemModified;

	/// <summary>Fires when the SelectedItems collection changes.</summary>
	[Category("Behavior"), Description("Selection changed.")]
	public event EventHandler? SelectionChanged;

	/// <summary>Gets or sets the <see cref="ShellFolder"/> currently being browsed by the <see cref="ShellView"/>.</summary>
	[Category("Data"), DefaultValue(typeof(ShellFolder), ""), Description("The folder currently being browsed.")]
	public ShellFolder CurrentFolder
	{
		get => currentFolder ??= IShellView is null ? ShellFolder.Desktop : new ShellFolder(GetFolderForView(IShellView)!);
		set => Navigate(value);
	}

	/// <summary>A set of flags that indicate the options for the folder.</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public FOLDERFLAGS Flags => IShellView?.GetCurrentInfo().fFlags ?? 0;

	/// <summary>Contains the navigation history of the ExplorerBrowser</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ShellNavigationHistory History { get; private set; }

	/// <summary>Gets the underlying <see cref="IShellView"/> instance.</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IShellView? IShellView
	{
		get => iShellView;
		private set
		{
			iShellView = value;
			//Items = new ShellItemArray(GetItemArray(iShellView, SVGIO.SVGIO_ALLVIEW));
		}
	}

	///// <summary>Gets all the items in the view.</summary>
	///// <value>An array with all the items.</value>
	//public ShellItemArray Items { get; private set; }

	/// <summary>Gets or sets the currently selected items in the view.</summary>
	/// <value>An array with the selected items.</value>
	/// <exception cref="ArgumentException">All items must belong to the folder hosted by this view. - SelectedItems</exception>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ShellItem[] SelectedItems
	{
		get => GetItems(IShellView, SVGIO.SVGIO_SELECTION);
		set
		{
			if (IShellView is null) return;
			// Deselect all
			IShellView.SelectItem(default, SVSIF.SVSI_DESELECTOTHERS);
			if (value is null || value.Length == 0) return;
			// Get parent folder of view items
			PIDL pidl = CurrentFolder.PIDL;
			// Ensure all have this parent
			if (!value.All(shi => shi.PIDL.Parent.Equals(pidl)))
				throw new ArgumentException("All items must belong to the folder hosted by this view.", nameof(SelectedItems));
			// Select all provided
			foreach (ShellItem item in value)
				IShellView.SelectItem((IntPtr)item.PIDL, SVSIF.SVSI_SELECT);
		}
	}

	/// <summary>Folder view mode.</summary>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public FOLDERVIEWMODE ViewMode => IShellView?.GetCurrentInfo().ViewMode ?? 0;

	/// <summary>
	/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
	/// </summary>
	/// <returns>The window handle.</returns>
	[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HWND WindowHandle => shellViewWindow;

	/// <summary>Gets the default size of the control.</summary>
	protected override Size DefaultSize => new(250, 200);

	private IShellBrowser Browser => iBrowser ??= new ShellBrowser(/* this */);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(ShellView? left, ShellView? right) => !(left == right);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(ShellView? left, ShellView? right) => EqualityComparer<ShellView?>.Default.Equals(left, right);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	/// <exception cref="NotImplementedException"></exception>
	public bool Equals(IShellView? other)
	{
		HWND w1 = HWND.NULL, w2 = HWND.NULL;
		other?.GetWindow(out w1);
		IShellView?.GetWindow(out w2);
		return w1 == w2;
	}

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><see langword="true"/> if the specified <see cref="object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
	public override bool Equals(object? obj) => ReferenceEquals(this, obj) || (obj is ShellView sv && Equals(sv.IShellView)) || (obj is IShellView isv && Equals(isv));

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => (int)(IntPtr)WindowHandle;

	/// <summary>
	/// Clears the view of existing content, fills it with content from the specified container, and adds a new item to the history.
	/// </summary>
	/// <param name="folder">The shell folder to navigate to.</param>
	public void Navigate(ShellFolder folder)
	{
		if (!OnNavigating(folder)) return;

		ShellFolder? previous = currentFolder;
		currentFolder = folder;

		try
		{
			RecreateShellView();
			History.Add(new ShellItem(folder.PIDL));
			OnNavigated();
		}
		catch (Exception)
		{
			currentFolder = previous;
			RecreateShellView();
			throw;
		}
		OnPropertyChanged(nameof(CurrentFolder));
	}

	/// <summary>
	/// Navigates to the last item in the navigation history list. This does not change the set of locations in the navigation log.
	/// </summary>
	public bool NavigateBack() { if (History.CanSeekBackward) { Navigate(new ShellFolder(History.SeekBackward()!)); return true; } return false; }

	/// <summary>
	/// Navigates to the next item in the navigation history list. This does not change the set of locations in the navigation log.
	/// </summary>
	/// <returns>True if the navigation succeeded, false if it failed for any reason.</returns>
	public bool NavigateForward() { if (History.CanSeekForward) { Navigate(new ShellFolder(History.SeekForward()!)); return true; } return false; }

	/// <summary>Navigates to the parent of the currently displayed folder.</summary>
	public void NavigateParent() { if (CurrentFolder is not null && CurrentFolder != ShellFolder.Desktop) Navigate(CurrentFolder.Parent!); }

	/// <summary>Refreshes the view's contents in response to user input.</summary>
	public override void Refresh() => IShellView?.Refresh();

	/// <summary>Saves the Shell's view settings so the current state can be restored during a subsequent browsing session.</summary>
	public void SaveState() => IShellView?.SaveViewState();

	/// <summary>Called to determine if an item should be shown in the view. Calls the <see cref="FilterItem"/> event if defined.</summary>
	/// <param name="pidl">The PIDL of the child item.</param>
	/// <returns><see langword="true"/> if the item should be included (this is the default); otherwise <see langword="false"/>.</returns>
	protected internal virtual bool IncludeItem(PIDL pidl)
	{
		if (FilterItem is null)
			return true;

		var e = new FilterShellItemEventArgs(ShellItem.Open(CurrentFolder.IShellFolder, pidl));
		FilterItem?.Invoke(this, e);
		return e.Include;
	}

	/// <summary>Raises the <see cref="Control.DoubleClick"/> event.</summary>
	/// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
	protected internal new virtual void OnDoubleClick(EventArgs e) => base.OnDoubleClick(e);

	/// <summary>Raises the <see cref="ItemsChanged"/> event.</summary>
	protected internal virtual void OnItemsChanged() => ItemsChanged?.Invoke(this, EventArgs.Empty);

	/// <summary>Raises the <see cref="ItemsEnumerated"/> event.</summary>
	protected internal virtual void OnItemsEnumerated() => ItemsEnumerated?.Invoke(this, EventArgs.Empty);

	/// <summary>Raises the <see cref="Navigated"/> event.</summary>
	protected internal virtual void OnNavigated() => Navigated?.Invoke(this, new NavigatedEventArgs(CurrentFolder));

	/// <summary>Raises the <see cref="Navigating"/> event.</summary>
	protected internal virtual bool OnNavigating(ShellFolder pendingLocation)
	{
		var e = new NavigatingEventArgs(pendingLocation);
		Navigating?.Invoke(this, e);
		return !e.Cancel;
	}

	/// <summary>Raises the <see cref="NavigationFailed"/> event.</summary>
	protected internal virtual void OnNavigationFailed(NavigationFailedEventArgs nfevent)
	{
		if (nfevent?.FailedLocation is null) return;
		NavigationFailed?.Invoke(this, nfevent);
	}

	/// <summary>Raises the <see cref="SelectedItemModified"/> event.</summary>
	protected internal virtual void OnSelectedItemModified() => SelectedItemModified?.Invoke(this, EventArgs.Empty);

	/// <summary>Raises the <see cref="SelectionChanged"/> event.</summary>
	protected internal virtual void OnSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

	/// <summary>
	/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"/> and its child controls and optionally
	/// releases the managed resources.
	/// </summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (!shellViewWindow.IsNull)
			{
				User32.DestroyWindow(shellViewWindow);
				shellViewWindow = HWND.NULL;
			}
			iBrowser = null;
			History.Clear();
			IShellView = null;
		}
		base.Dispose(disposing);
	}

	/// <summary>Raises the <see cref="Control.CreateControl"/> method.</summary>
	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		CreateShellView();
		History.Add(new ShellItem(CurrentFolder.PIDL));
		OnNavigated();
	}

	/// <summary>Raises the <see cref="Control.Resize"/> event.</summary>
	/// <param name="eventargs">The <see cref="EventArgs"/> instance containing the event data.</param>
	protected override void OnResize(EventArgs eventargs)
	{
		base.OnResize(eventargs);
		if (!shellViewWindow.IsNull)
			User32.SetWindowPos(shellViewWindow, HWND.HWND_TOP, 0, 0, ClientRectangle.Width, ClientRectangle.Height, 0);
	}

	/// <summary>Processes Windows messages.</summary>
	/// <param name="m">The Windows <see cref="Message"/> to process.</param>
	protected override void WndProc(ref Message m)
	{
		const int CWM_GETISHELLBROWSER = 0x407;

		// Windows 9x sends the CWM_GETISHELLBROWSER message and expects the IShellBrowser for the window to be returned or an Access
		// Violation occurs. This is pseudo-documented in knowledge base article Q157247.
		if (m.Msg == CWM_GETISHELLBROWSER && iBrowser is not null)
		{
			m.Result = Marshal.GetComInterfaceForObject(iBrowser, typeof(IShellBrowser));
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	private static IShellView CreateViewObject(ShellFolder folder, HWND owner) =>
		folder.IShellFolder.CreateViewObject<IShellView>(owner)!;

	private static ShellFolder? GetFolderForView(IShellView? iView) => GetItems(iView, SVGIO.SVGIO_ALLVIEW).FirstOrDefault()?.Parent;

	private static IShellItemArray GetItemArray(IShellView iView, SVGIO uItem) => ((IFolderView)iView).Items<IShellItemArray>(uItem)!;

	private static ShellItem[] GetItems(IShellView? iView, SVGIO uItem)
	{
		if (iView is null) return new ShellItem[0];
		using ComReleaser<IDataObject> ido = ComReleaserFactory.Create(iView.GetItemObject<IDataObject>(uItem)!);
		var shdo = new ShellDataObject(ido.Item);
		return shdo.GetShellIdList()?.ToArray() ?? new ShellItem[0];
	}

	private void CreateShellView()
	{
		IShellView? prev = IShellView;
		IShellView = CreateViewObject(CurrentFolder, Handle);
		try
		{
			var fsettings = prev?.GetCurrentInfo() ?? new FOLDERSETTINGS(ViewMode, Flags);
			shellViewWindow = IShellView.CreateViewWindow(prev, fsettings, Browser, ClientRectangle);
		}
		catch (COMException ex)
		{
			// If the operation was cancelled by the user (for example because an empty removable media drive was selected, then
			// "Cancel" pressed in the resulting dialog) convert the exception into something more meaningfil.
			if (ex.ErrorCode == unchecked((int)0x800704C7U))
			{
				throw new OperationCanceledException("User cancelled.", ex);
			}
		}

		if (prev != null)
		{
			prev.UIActivate(SVUIA.SVUIA_DEACTIVATE);
			prev.DestroyViewWindow();
			prev = null;
		}

		IShellView.UIActivate(SVUIA.SVUIA_ACTIVATE_NOFOCUS);

		if (DesignMode) User32.EnableWindow(shellViewWindow, false);
	}

	private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	private void RecreateShellView()
	{
		if (IShellView != null)
		{
			CreateShellView();
			OnNavigated();
		}
	}
}