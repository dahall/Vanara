using electrifier.Controls.Contracts;
using electrifier.Controls.Services;
using Microsoft.UI.Xaml.Media.Imaging;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Vanara.PInvoke;
using Vanara.Windows.Shell;

namespace electrifier.Controls.Helpers;

public class BrowserItemFactory
{
    public static ShellBrowserItem FromPIDL(Shell32.PIDL pidl, List<ShellBrowserItem>? childItems = null) => new(new ShellItem(pidl), childItems);
    public static ShellBrowserItem FromKnownFolderId(Shell32.KNOWNFOLDERID knownFolderId) => new(new ShellFolder(knownFolderId));
    public static ShellBrowserItem FromShellFolder(ShellFolder shellFolder) => FromPIDL(shellFolder.PIDL);
    public static ShellBrowserItem HomeShellFolder()
    {
        using var homeShellFolder = new ShellItem("shell:::{679f85cb-0220-4080-b29b-5540cc05aab6}");
        return new ShellBrowserItem(homeShellFolder);
    }
}

/* This comes from: https://github.com/electrifier/electrifier-v1.25/compare/reconfigure...tajbender:electrifier.v1.25:IconExtractor-Branch
    /// <summary>
    /// ExtractChildItems uses ShellIconExtractor to asynchronously extract icons for all child items of the given targetFolder.
    /// </summary>
    /// <param name="targetFolder">The ExplorerBrowserItem representing the folder whose child items are to be extracted.</param>
    /// <param name="iconExtOnIconExtracted">An event handler that is called each time an icon is extracted for a child item.</param>
    /// <param name="iconExtOnComplete">An event handler that is called when the extraction process is complete.</param>
 public void ExtractChildItems(ExplorerBrowserItem targetFolder,
        EventHandler<ShellIconExtractedEventArgs>? iconExtOnIconExtracted,
        EventHandler? iconExtOnComplete)
    {
        Debug.Print($"ExtractChildItems <{targetFolder.DisplayName}> <{iconExtOnIconExtracted}> <{iconExtOnComplete}>");
        Debug.Assert(targetFolder is not null);
        if (targetFolder is null)
        {
            throw new ArgumentNullException(nameof(targetFolder));
        }

        Debug.Assert(targetFolder.IsFolder);
        Debug.Assert(targetFolder.ShellItem.PIDL != null);
        var shItemId = targetFolder.ShellItem.PIDL;
        var shFolder = new ShellFolder(shItemId);
        var shellIconExtractor = new ShellIconExtractor(shFolder);
        shellIconExtractor.IconExtracted += (sender, args) =>
        {
            var shItem = new ShellItem(args.ItemID);
            var ebItem = new ExplorerBrowserItem(shItem);

            if (ebItem.IsFolder)
            {
                ebItem.BitmapSource = _defaultFolderImageBitmapSource;
                targetFolder.Children?.Insert(0, ebItem);
                //folderCount++;
            }
            else
            {
                ebItem.BitmapSource = _defaultDocumentAssocImageBitmapSource;
                targetFolder.Children?.Add(ebItem);
                //fileCount++;
            }

            DispatcherQueue.TryEnqueue(() =>
            {
                CurrentFolderItems.Add(ebItem);
            });
        };
        shellIconExtractor.IconExtracted += iconExtOnIconExtracted;
        shellIconExtractor.Complete += iconExtOnComplete;
        shellIconExtractor.Start();
    }

    private void IconExtOnComplete(object? sender, EventArgs e)
    {
        var cnt = CurrentFolderItems.Count;
        Debug.Print($".IconExtOnComplete(): {cnt} items");

        //ShellTreeView.SetItemsSource(CurrentFolderItem, CurrentFolderItems);  // TODO: using root item here, should be target folder?!?
        //if (GridViewVisibility == Microsoft.UI.Xaml.Visibility.Visible)
        //{
        //    Debug.Print($".GridViewVisibility = {Microsoft.UI.Xaml.Visibility.Visible}");
        //    ShellGridView.SetItems(CurrentFolderItems);
        //}
    }
*/

// TODO: IDisposable
// TODO: IComparable
[DebuggerDisplay($"{{{nameof(ToString)}(),nq}}")]
public partial class ShellBrowserItem : AbstractBrowserItem<ShellItem>, INotifyPropertyChanged
{
    public string DisplayName => ShellItem.GetDisplayName(ShellItemDisplayString.NormalDisplay) ?? ShellItem.ToString();
    public Shell32.PIDL PIDL => ShellItem.PIDL;
    public ShellItem ShellItem;
    public SoftwareBitmapSource? SoftwareBitmap;
    public SoftwareBitmapSource? OverlaySoftwareBitmap;
    public ShellItemAttribute Attributes => ShellItem.Attributes;
    private bool _isSelected;

    public readonly new List<ShellBrowserItem> ChildItems;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (value == _isSelected)
            {
                return;
            }

            _isSelected = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// HasUnrealizedChildren checks for flag ´SFGAO_HASSUBFOLDER´.
    ///
    /// <seealso href="https://learn.microsoft.com/en-us/windows/win32/shell/sfgao"/>
    /// The specified folders have subfolders. The SFGAO_HASSUBFOLDER attribute is only advisory and might be returned by Shell folder implementations even if they do not contain subfolders. Note, however, that the converse—failing to return SFGAO_HASSUBFOLDER—definitively states that the folder objects do not have subfolders.
    /// Returning SFGAO_HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any subfolders exist. For example, the Shell always returns SFGAO_HASSUBFOLDER when a folder is located on a network drive.
    /// </summary>
    public bool HasUnrealizedChildren => Attributes.HasFlag(ShellItemAttribute.HasSubfolder);
    public new bool IsFolder => ShellItem.IsFolder;
    public bool IsHidden => Attributes.HasFlag(ShellItemAttribute.Hidden);
    public bool IsLink => ShellItem.IsLink;

    // TODO: Listen for ShellItem Property changes

    public ShellBrowserItem(ShellItem shItem,
        List<ShellBrowserItem> childItems = null) : base()
    {
        ShellItem = shItem;
        ChildItems = childItems ?? [];

        //ChildItems = childItems ?? []; note: base ctor
        //SoftwareBitmap = ConfiguredTaskAwaitable GetStockIconBitmapSource()


        // if IsHidden... do overlay
        // is IsLink... do overlay
        // Shell32.SHSTOCKICONID shStockIconId;
        if (IsFolder)
        {
            // TODO: Drives?
            _ = GetStockIconBitmapAsync(Shell32.SHSTOCKICONID.SIID_FOLDER);
        }
        else
        {
            // var assoc = shItem.Association;
            // TODO: SIID_DOCNOASSOC SIID_APPLICATION 
            _ = GetStockIconBitmapAsync(Shell32.SHSTOCKICONID.SIID_DOCASSOC);
        }
    }

    private async Task<SoftwareBitmapSource> GetStockIconOverlayBitmapAsync(Shell32.SHSTOCKICONID stockIconId)
    {
        var softwareBitmapSource = await Shel32NamespaceService.GetStockIconBitmapSource(stockIconId);
        SetField(ref OverlaySoftwareBitmap, softwareBitmapSource, nameof(OverlaySoftwareBitmap));

        return softwareBitmapSource;
    }

    private async Task<SoftwareBitmapSource> GetStockIconBitmapAsync(Shell32.SHSTOCKICONID stockIconId)
    {
        var softwareBitmapSource = await Shel32NamespaceService.GetStockIconBitmapSource(stockIconId);
        SetField(ref SoftwareBitmap, softwareBitmapSource, nameof(SoftwareBitmap));

        return softwareBitmapSource;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
