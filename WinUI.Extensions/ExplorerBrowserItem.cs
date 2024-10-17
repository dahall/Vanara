using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Windows.Shell;

namespace electrifier.Controls.Vanara;

/// <summary>
/// A ViewModel for both <see cref="Shell32GridView"/> and <see cref="Shell32TreeView"/> Items.
/// </summary>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(), nq}}")]
public class ExplorerBrowserItem /* : INotifyPropertyChanged */
{
    public List<ExplorerBrowserItem>? Children;
    public string DisplayName
    {
        get;
    }
    /// <summary>
    /// HasUnrealizedChildren checks for flag ´SFGAO_HASSUBFOLDER´.
    ///
    /// <seealso href="https://learn.microsoft.com/en-us/windows/win32/shell/sfgao"/>
    /// The specified folders have subfolders. The SFGAO_HASSUBFOLDER attribute is only advisory and might be returned by Shell folder implementations even if they do not contain subfolders. Note, however, that the converse—failing to return SFGAO_HASSUBFOLDER—definitively states that the folder objects do not have subfolders.
    /// Returning SFGAO_HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any subfolders exist. For example, the Shell always returns SFGAO_HASSUBFOLDER when a folder is located on a network drive.
    /// </summary>
    public bool HasUnrealizedChildren
    {
        get
        {
            try
            {
                if (ShellItem.Attributes.HasFlag(ShellItemAttribute.HasSubfolder))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                Debug.Print("HasUnrealizedChildren failed!");
            }
            return false;
        }
    }
    public ImageEx? ImageIconSource
    {
        get;
        internal set;
    }
    public bool IsExpanded
    {
        get; set;
    }
    public bool IsFolder => ShellItem.IsFolder;
    public bool IsLink => ShellItem.IsLink;
    public bool IsSelected
    {
        get; set;
    }
    public ShellItem ShellItem
    {
        get;
    }


    // TODO: TreeViewNode - Property
    // TODO: GridViewItem - Property
    public ExplorerBrowserItem(ShellItem shItem)
    {
        ShellItem = new ShellItem(shItem.PIDL);
        DisplayName = ShellItem.Name ?? ":error: <DisplayName.get()>";
        IsExpanded = false;
        // TODO: If IsSelected, add overlay of opened folder icon to TreeView
        IsSelected = false;

        //Debug.Print($"ExplorerBrowserItem <{GetDebuggerDisplay()}> created.");
    }

    #region GetDebuggerDisplay()
    private string GetDebuggerDisplay()
    {
        var sb = new StringBuilder();
        sb.Append($"<{nameof(ExplorerBrowserItem)}> `{DisplayName}`");

        if (IsFolder) { sb.Append(", [folder]"); }

        return sb.ToString();
    }
    #endregion

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
