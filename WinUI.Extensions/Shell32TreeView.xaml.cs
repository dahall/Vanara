using Visibility = Microsoft.UI.Xaml.Visibility;
using Vanara.Windows.Shell;
using Vanara.PInvoke;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CommunityToolkit.WinUI;
using CommunityToolkit.WinUI.Collections;

// TODO: For EnumerateChildren-Calls, add HWND handle
// TODO: See ShellItemCollection, perhaps use this instead of ObservableCollection
// https://github.com/dahall/Vanara/blob/master/Windows.Shell.Common/ShellObjects/ShellItemArray.cs

namespace electrifier.Controls.Vanara;

public sealed partial class Shell32TreeView : UserControl
{
    public TreeView NativeTreeView => TreeView;

    public object ItemsSource
    {
        get => NativeTreeView.ItemsSource;
        set => NativeTreeView.ItemsSource = value;
    }

    public ExplorerBrowserItem? SelectedItem
    {
        get => (ExplorerBrowserItem?)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }
    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(nameof(SelectedItem), typeof(ExplorerBrowserItem), typeof(Shell32TreeView),
            new PropertyMetadata(default(ExplorerBrowserItem?)));

    public TreeViewNode SelectedNode => NativeTreeView.SelectedNode;

    public Shell32TreeView()
    {
        InitializeComponent();
        DataContext = this;
    }

    // TODO: public object ItemFromContainer => NativeTreeView.ItemFromContainer()
}
