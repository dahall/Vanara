using System.Collections.ObjectModel;
using System.Diagnostics;
using electrifier.Controls.Helpers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Vanara.PInvoke;
using Vanara.Windows.Shell;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace electrifier.Controls;

public sealed partial class ShellNamespaceTreeControl : UserControl
{
    private TreeView NativeTreeView => TreeView;
    internal ObservableCollection<ShellBrowserItem> Items;

    public TreeViewNode? SelectedItem => NativeTreeView.SelectedNode as TreeViewNode;

    public delegate void NavigatedEventHandler(object sender, NavigatedEventArgs e);
    public event NavigatedEventHandler? Navigated;

    // todo: public event TypedEventHandler<ShellNamespaceTreeControl, TreeViewNode> SelectionChanged
    // todo: public event EventHandler FolderItemsChanged

    public ShellNamespaceTreeControl()
    {
        InitializeComponent();
        DataContext = this;
        Items = [];

        Loading += OnLoading;
        NativeTreeView.SelectionChanged += OnSelectionChanged;
    }

    private void OnLoading(FrameworkElement sender, object args)
    { // HomeShellFolder
        var folderItem = new ShellFolder(@"shell:::{679f85cb-0220-4080-b29b-5540cc05aab6}");
        var newItem = BrowserItemFactory.FromShellFolder(folderItem);
        Items.Add(newItem);
        /*
public static ShellBrowserItem HomeShellFolder() => new(new ShellItem("shell:::{679f85cb-0220-4080-b29b-5540cc05aab6}").PIDL);
         */

        //Items.Add(new ShellBrowserItem(folderItem);
        // TODO: Items.Add(new ShellBrowserItem(/* Home */, isFolder: true));
        // TODO: Items.Add(new ShellBrowserItem(/* Gallery */, isFolder: true));
        Items.Add(BrowserItemFactory.FromKnownFolderId(Shell32.KNOWNFOLDERID.FOLDERID_SkyDrive));
        // TODO: Add separator and add this as child items of the rootItem as second view option
        // INFO: The following items are quick access items
        Items.Add(new ShellBrowserItem(ShellFolder.Desktop));
        Items.Add(BrowserItemFactory.FromKnownFolderId(Shell32.KNOWNFOLDERID.FOLDERID_Downloads));
        Items.Add(BrowserItemFactory.FromKnownFolderId(Shell32.KNOWNFOLDERID.FOLDERID_Documents));
        Items.Add(BrowserItemFactory.FromKnownFolderId(Shell32.KNOWNFOLDERID.FOLDERID_Pictures));
        Items.Add(BrowserItemFactory.FromKnownFolderId(Shell32.KNOWNFOLDERID.FOLDERID_Music));
        Items.Add(BrowserItemFactory.FromKnownFolderId(Shell32.KNOWNFOLDERID.FOLDERID_Videos));

        Items[0].IsSelected = true;
    }

    private void OnSelectionChanged(TreeView sender, TreeViewSelectionChangedEventArgs e)
    {
        Debug.WriteIf((e.AddedItems.Count < 1 && e.RemovedItems.Count < 1), "None or less Items added nor removed", ".OnSelectionChanged() parameter mismatch.");
        if (e.AddedItems[0] is not ShellBrowserItem shellBrowserItem)
        {
            Debug.Fail(".OnSelectionChanged(): Invalid item");
            return;
        }
        Navigated?.Invoke(this, new NavigatedEventArgs(new ShellFolder(shellBrowserItem.ShellItem)));
    }
}
