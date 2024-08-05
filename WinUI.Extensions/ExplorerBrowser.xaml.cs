using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.InteropServices;
using System.Windows.Input;
using Vanara.PInvoke;
using Vanara.Windows.Shell;
using Visibility = Microsoft.UI.Xaml.Visibility;

namespace electrifier.Controls.Vanara;

// INFO: Care for this: // Remember! We're not the owner of the given PIDL, so we have to make our own copy for our own heap! See Issue #158
// TODO: INFO: See also https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.controls.image.source?view=windows-app-sdk-1.5#microsoft-ui-xaml-controls-image-source

// TODO: WARN: ExplorerBrowser doesn't show anything when hiding Shell32TreeView, cause of missing navigation

// https://github.com/dahall/Vanara/blob/master/Windows.Forms/Controls/ExplorerBrowser.cs
// TODO: See also https://github.com/dahall/Vanara/blob/ac0a1ac301dd4fdea9706688dedf96d596a4908a/Windows.Shell.Common/StockIcon.cs

/* TODO: Research this regarding Visual States
   [Microsoft.UI.Xaml.TemplatePart(Name="Image", Type=typeof(System.Object))]
   [Microsoft.UI.Xaml.TemplateVisualState(GroupName="CommonStates", Name="Loading")]
   [Microsoft.UI.Xaml.TemplateVisualState(GroupName="CommonStates", Name="Loaded")]
   [Microsoft.UI.Xaml.TemplateVisualState(GroupName="CommonStates", Name="Unloaded")]
   [Microsoft.UI.Xaml.TemplateVisualState(GroupName="CommonStates", Name="Failed")]
 */
public sealed partial class ExplorerBrowser : INotifyPropertyChanged
{
    // TODO: Use shell32 stock icons
    internal static readonly BitmapImage DefaultFileImage =
        new(new Uri("ms-appx:///Assets/Views/Workbench/Shell32 Default unknown File.ico"));

    internal static readonly BitmapImage DefaultFolderImage =
        new(new Uri("ms-appx:///Assets/Views/Workbench/Shell32 Default Folder.ico"));

    internal static readonly BitmapImage DefaultLibraryImage =
        new(new Uri("ms-appx:///Assets/Views/Workbench/Shell32 Library.ico"));

    /// <summary>
    /// 
    /// </summary>
    public ExplorerBrowserItem? CurrentFolderBrowserItem
    {
        get => GetValue(CurrentFolderBrowserItemProperty) as ExplorerBrowserItem;
        set => SetValue(CurrentFolderBrowserItemProperty, value);
    }
    public static readonly DependencyProperty CurrentFolderBrowserItemProperty = DependencyProperty.Register(
        nameof(CurrentFolderBrowserItem),
        typeof(ObservableCollection<ExplorerBrowserItem>),
        typeof(ExplorerBrowser),
        new PropertyMetadata(null, new PropertyChangedCallback(OnCurrentFolderBrowserItemChanged))
    );
    private static void OnCurrentFolderBrowserItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //ImageWithLabelControl iwlc = d as ImageWithLabelControl; //null checks omitted
        var s = e.NewValue; //null checks omitted
        if (s is ExplorerBrowserItem ebItem)
        {
            Debug.WriteLine($".OnCurrentFolderBrowserItemChanged(<'{ebItem.DisplayName}'>) DependencyObject <'{d.ToString()}'>");
        }
        else
        {
            Debug.WriteLine($"[E].OnCurrentFolderBrowserItemChanged(): `{s.ToString()}` -> ERROR:UNKNOWN TYPE! Should be <ExplorerBrowserItem>");
        }
    }

    /// <summary>
    /// Represents the current's folder content.
    /// Each Item is an <see cref="ExplorerBrowserItem"/>.
    /// It is then used as DataSource of <see cref="ShellGridView"/>.
    /// </summary>
    public ObservableCollection<ExplorerBrowserItem> CurrentFolderItems
    {
        get => (ObservableCollection<ExplorerBrowserItem>)GetValue(CurrentFolderItemsProperty);
        set => SetValue(CurrentFolderItemsProperty, value);
    }
    public static readonly DependencyProperty CurrentFolderItemsProperty = DependencyProperty.Register(
        nameof(CurrentFolderItems),
        typeof(ObservableCollection<ExplorerBrowserItem>),
        typeof(ExplorerBrowser),
        new PropertyMetadata(null,
            new PropertyChangedCallback(OnCurrentFolderItemsChanged)));
    private static void OnCurrentFolderItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        //ImageWithLabelControl iwlc = d as ImageWithLabelControl; //null checks omitted
        var s = e.NewValue; //null checks omitted
        Debug.Print($".OnCurrentFolderItemsChanged(): {s}");
    }

    public string NavigationFailure
    {
        get => (string)GetValue(NavigationFailureProperty);
        set => SetValue(NavigationFailureProperty, value);
    }
    public static readonly DependencyProperty NavigationFailureProperty = DependencyProperty.Register(
        nameof(NavigationFailure),
        typeof(string),
        typeof(ExplorerBrowser),
        new PropertyMetadata(string.Empty));

    /// <summary>
    /// HResult code for <code><see cref="System.Runtime.InteropServices.COMException"/> 0x80070490</code>
    /// <remarks>Fired when `Element not found`</remarks>
    /// </summary>
    public HRESULT HResultElementNotFound = 0x80070490;

    private ShellIconExtractor? _iconExtractor;
    public ShellIconExtractor? IconExtractor
    {
        get => _iconExtractor;
        private set
        {
            _iconExtractor?.Cancel();
            _iconExtractor = value;
        }
    }

    public ImageCache? ImageCache
    {
        get; set;
    }

    public bool IsLoading
    {
        get; set;
    }

    public Visibility GridViewVisibility
    {
        get; set;
    }

    public Visibility TreeViewVisibility
    {
        get => (Visibility)GetValue(TreeViewVisibilityProperty);
        set => SetValue(TreeViewVisibilityProperty, value);
    }
    public static readonly DependencyProperty TreeViewVisibilityProperty = DependencyProperty.Register(
        nameof(TreeViewVisibility),
        typeof(Visibility),
        typeof(ExplorerBrowser),
        new PropertyMetadata(default(object)));

    public Visibility TopCommandBarVisibility
    {
        get; set;
    }

    public Visibility BottomAppBarVisibility
    {
        get; set;
    }

    public Visibility BottomCommandBarVisibility
    {
        get; set;
    }

    public Visibility ArenaGridSplitterVisibility =>
        ((TreeViewVisibility == Visibility.Visible) && (GridViewVisibility == Visibility.Visible))
            ? Visibility.Visible
            : Visibility.Collapsed;

    public ICommand RefreshViewCommand
    {
        get;
    }

    /// <summary>Raises the <see cref="NavigationFailed"/> event.</summary>
    internal void OnNavigationFailed(ExtNavigationFailedEventArgs nfevent)
    {
        if (nfevent?.FailedLocation is null)
        {
            return;
        }

        NavigationFailed?.Invoke(this, nfevent);
    }

    /// <summary>
    /// Fires when either a Navigating listener cancels the navigation, or if the operating system determines that navigation is not possible.
    /// </summary>
    [Category("Action"), Description("Navigation failed.")]
    public event EventHandler<ExtNavigationFailedEventArgs>? NavigationFailed;

    public ExplorerBrowser()
    {
        InitializeComponent();
        DataContext = this;

        ImageCache = new ImageCache();
        CurrentFolderItems = [];
        CurrentFolderBrowserItem = new ExplorerBrowserItem(ShellFolder.Desktop);
        RefreshViewCommand = new RelayCommand(() => OnRefreshViewCommand(this, new RoutedEventArgs()));

        NavigationFailed += ExplorerBrowser_NavigationFailed;

        ShellTreeView.NativeTreeView.SelectionChanged += NativeTreeViewOnSelectionChanged;
        ShellGridView.NativeGridView.SelectionChanged += NativeGridView_SelectionChanged;
        //TODO: Should be ShellTreeView.SelectionChanged += ShellTreeView_SelectionChanged;

        _ = InitializeViewModel();
    }

    private async Task InitializeViewModel()
    {
        //ShellGridView.DataContext = this;
        //ShellTreeView.DataContext = this;

        CurrentFolderBrowserItem = new ExplorerBrowserItem(ShellFolder.Desktop);
        var rootItems = new List<ExplorerBrowserItem>
        {
            CurrentFolderBrowserItem,
        };

        // add second root folder as dummy
        var galleryFolder = new ShellFolder(Shell32.KNOWNFOLDERID.FOLDERID_PicturesLibrary);
        var galleryEbItem = new ExplorerBrowserItem(galleryFolder);
        rootItems.Add(galleryEbItem);

        InitializeStockIcons();

        ShellTreeView.ItemsSource = rootItems;
        CurrentFolderBrowserItem.IsExpanded = true;
        CurrentFolderBrowserItem.IsSelected = true;
    }

    private SoftwareBitmapSource _defaultFolderImageBitmapSource;

    /// <summary>
    /// DUMMY: TODO: InitializeStockIcons()
    ///
    /// Added code:
    /// <see cref="GetWinUi3BitmapSourceFromIcon"/>
    /// <see cref="GetWinUi3BitmapSourceFromGdiBitmap"/>
    /// </summary>
    public void InitializeStockIcons()
    {
        try
        {
            using var siFolder = new StockIcon(Shell32.SHSTOCKICONID.SIID_FOLDER);
            //using var siFolderOpen = new StockIcon(Shell32.SHSTOCKICONID.SIID_FOLDEROPEN);
            // TODO: Opened Folder Icon, use for selected TreeViewItems
            //using var siVar = new StockIcon(Shell32.SHSTOCKICONID.SIID_DOCASSOC);

            var icnHandle = siFolder.IconHandle.ToIcon();
            HICON handle = siFolder.IconHandle;
            var icon = siFolder.IconHandle.ToIcon();
            //if (icnHandle != null)
            {
                //var icon = Icon.FromHandle((nint)icnHandle);
                var bmpSource = GetWinUi3BitmapSourceFromIcon(icon);
                //_defaultFolderImageBitmapSource = bmpSource;
            }

            //System.Drawing.Icon icn = Icon.FromHandle((IntPtr)siFolder.IconHandle);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void ExplorerBrowser_NavigationFailed(object? sender, ExtNavigationFailedEventArgs e)
    {
        var location = e.FailedLocation;

        NavigationFailure = $"Navigation failed: '{location}' cannot be navigated to. <Show More Info> <Report a Bug>";
        NavigationFailedInfoBar.IsOpen = true;
        NavigationFailedInfoBar.Message = NavigationFailure;
        var childElement = new TextBox();
        NavigationFailedInfoBar.Content = childElement;
        IsLoading = false;
        e.IsHandled = true;
    }

    public void ExtractChildItems(ExplorerBrowserItem targetFolder)
    {
        var itemCount = 0;
        Debug.Print($".ExtractChildItems(<{targetFolder?.DisplayName}>) extracting...");
        Debug.Assert(targetFolder is not null);
        if (targetFolder is null)
        {
            throw new ArgumentNullException(nameof(targetFolder));
        }

        try
        {
            Debug.Assert(targetFolder.ShellItem.PIDL != Shell32.PIDL.Null);
            var shItemId = targetFolder.ShellItem.PIDL;
            using var shFolder = new ShellFolder(shItemId);

            if ((shFolder.Attributes & ShellItemAttribute.Removable) != 0)
            {
                // TODO: Check for Disc in Drive, fail only if device not present
                // TODO: Add `Eject-Buttons` to TreeView (right side, instead of Pin header) and GridView
                Debug.WriteLine($"GetChildItems: IsRemovable = true");
                var eventArgs = new NavigationFailedEventArgs();
                // TODO: Switch PresentationView to `Error`
                return;
            }

            var children = shFolder.EnumerateChildren(FolderItemFilter.Folders | FolderItemFilter.NonFolders);
            var shellItems = children as ShellItem[] ?? children.ToArray();
            itemCount = shellItems.Length;
            targetFolder.Children = new List<ExplorerBrowserItem>();

            if (shellItems.Length > 0)
            {
                foreach (var child in shellItems)
                {
                    var ebItem = new ExplorerBrowserItem(child);
                    targetFolder.Children.Add(ebItem);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Debug.Print($".ExtractChildItems(<{targetFolder?.DisplayName}>) extracted: {itemCount} items.");
    }

    private void NativeTreeViewOnSelectionChanged(TreeView sender, TreeViewSelectionChangedEventArgs args)
    {
        var selectedItem = args.AddedItems.FirstOrDefault();
        if (selectedItem != null)
        {
            if (selectedItem is ExplorerBrowserItem ebItem)
            {
                Debug.Print($".NativeTreeViewOnSelectionChanged() {ebItem.DisplayName}");

                Navigate(ebItem);

                // TODO: If ebItem.PIDL.Compare(CurrentFolderBrowserItem.ShellItem.PIDL) => Just Refresh()
            }
            // TODO: else
            //{
            //    Debug.Fail($"ERROR: NativeTreeViewOnSelectionChanged() addedItem {selectedItem.ToString()} is NOT of type <ExplorerBrowserItem>!");
            //    throw new ArgumentOutOfRangeException(
            //        "$ERROR: NativeTreeViewOnSelectionChanged() addedItem {selectedItem.ToString()} is NOT of type <ExplorerBrowserItem>!");
            //}
        }
    }

    private void NativeGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var addedItems = e.AddedItems;
        var newTarget = addedItems?.FirstOrDefault();
        if (newTarget == null)
        {
            Debug.Print($".NativeGridView_SelectionChanged(`<newTarget==null>`");
            return;
        }
        else
        {
            if (newTarget is ExplorerBrowserItem ebItem)
            {
                Debug.Print($".NativeGridView_SelectionChanged(`{ebItem.DisplayName}`)");

                Navigate(ebItem, selectTreeViewNode: true);

                // TODO: If ebItem.PIDL.Compare(CurrentFolderBrowserItem.ShellItem.PIDL) => Just Refresh()
            }
            // TODO: else 
            //{
            //    Debug.Fail(
            //        $"ERROR: NativeGridView_SelectionChanged() addedItem {newTarget.ToString()} is NOT of type <ExplorerBrowserItem>!");
            //    throw new ArgumentOutOfRangeException(
            //        "$ERROR: NativeGridView_SelectionChanged() addedItem {selectedItem.ToString()} is NOT of type <ExplorerBrowserItem>!");
            //}

            Debug.Print($".NativeGridView_SelectionChanged({newTarget})");
        }
    }

    public void Navigate(ExplorerBrowserItem ebItem, bool selectTreeViewNode = false)
    {
        try
        {
            Debug.Print($".Navigate(`{ebItem.DisplayName}`)");
            CurrentFolderBrowserItem = ebItem;
            if (selectTreeViewNode)
            {
                ebItem.IsSelected = true;
            }
            CurrentFolderItems.Clear();
            IsLoading = true;
            ExtractChildItems(ebItem);

            if (!(ebItem.Children?.Count > 0))
            {
                return;
            }

            foreach (var childItem in ebItem.Children)
            {
                CurrentFolderItems.Add(childItem);
            }
        }

        catch (COMException comEx)
        {
            var navFailedEventArgs = new ExtNavigationFailedEventArgs();
            navFailedEventArgs.Hresult = comEx.HResult;
            navFailedEventArgs.FailedLocation = ebItem.ShellItem;

            if (comEx.HResult == HResultElementNotFound)
            {
                Debug.WriteLine($"[Error] {comEx.HResult}: {navFailedEventArgs}");
                //NavigationFailure = msg;
                //HasNavigationFailure = true;
                navFailedEventArgs.IsHandled = false;

                OnNavigationFailed(navFailedEventArgs);

                if (navFailedEventArgs.IsHandled)
                {
                    return;
                }
            }

            Debug.Fail($"[Error] Navigate(<{ebItem}>) failed. COMException: {comEx.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Debug.Fail($"[Error] Navigate(<{ebItem}>) failed. Exception: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Taken from <see href="https://stackoverflow.com/questions/76640972/convert-system-drawing-icon-to-microsoft-ui-xaml-imagesource"/>
    /// </summary>
    /// <param name="icon"></param>
    /// <returns></returns>
    public static async Task<SoftwareBitmapSource> GetWinUi3BitmapSourceFromIcon(System.Drawing.Icon icon)
    {
        if (icon == null)
            return null;

        // convert to bitmap
        using var bmp = icon.ToBitmap();
        return await GetWinUi3BitmapSourceFromGdiBitmap(bmp);
    }

    /// <summary>
    /// Taken from <see href="https://stackoverflow.com/questions/76640972/convert-system-drawing-icon-to-microsoft-ui-xaml-imagesource"/>
    /// </summary>
    /// <param name="icon"></param>
    /// <returns></returns>
    public static async Task<SoftwareBitmapSource> GetWinUi3BitmapSourceFromGdiBitmap(System.Drawing.Bitmap bmp)
    {
        if (bmp == null)
            return null;

        // get pixels as an array of bytes
        var data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
        var bytes = new byte[data.Stride * data.Height];
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        bmp.UnlockBits(data);

        // get WinRT SoftwareBitmap
        var softwareBitmap = new Windows.Graphics.Imaging.SoftwareBitmap(
            Windows.Graphics.Imaging.BitmapPixelFormat.Bgra8,
            bmp.Width,
            bmp.Height,
            Windows.Graphics.Imaging.BitmapAlphaMode.Premultiplied);
        softwareBitmap.CopyFromBuffer(bytes.AsBuffer());

        // build WinUI3 SoftwareBitmapSource
        var source = new SoftwareBitmapSource();
        await source.SetBitmapAsync(softwareBitmap);
        return source;
    }

    public void OnRefreshViewCommand(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine($".OnRefreshViewCommand(sender <{sender}>, RoutedEventArgs <{e.ToString()}>)");
        /* // TODO: TryNavigate(CurrentFolderBrowserItem); */
    }

    #region Property stuff

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    #endregion Property stuff
}

/// <summary>Extended Event argument for the <see cref="NavigationFailedEventArgs"/> event</summary>
public class ExtNavigationFailedEventArgs : NavigationFailedEventArgs
{
    public bool IsHandled
    {
        get; set;
    }
    public HRESULT? Hresult
    {
        get;
        set;
    }
}

/// <summary>Event argument for The Navigated event</summary>
public class ExtNavigatedEventArgs : NavigatedEventArgs
{
    public int ItemCount { get; set; } = 0;
    public int FolderCount { get; set; } = 0;
    public int FileCount { get; set; } = 0;

    /// <summary>Initializes a new instance of the <see cref="T:Vanara.Windows.Shell.NavigatedEventArgs" /> class.</summary>
    /// <param name="folder">The folder.</param>
    public ExtNavigatedEventArgs(ShellFolder folder) : base(folder)
    {
        //NewLocation = folder;   // TODO: ?!?
    }
}

#region The following is original copy & paste from Vanara

/// <summary>Event argument for The Navigating event</summary>
public class NavigatingEventArgs : EventArgs
{
    /// <summary>Set to 'True' to cancel the navigation.</summary>
    public bool Cancel
    {
        get; set;
    }

    /// <summary>The location being navigated to</summary>
    public ShellItem? PendingLocation
    {
        get; set;
    }
}

#endregion
