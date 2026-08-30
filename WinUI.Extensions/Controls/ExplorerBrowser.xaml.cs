using electrifier.Controls.Helpers;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using Vanara.Windows.Shell;

namespace electrifier.Controls;

public sealed partial class ExplorerBrowser : UserControl
{
    public ObservableCollection<ShellBrowserItem> CurrentItems;
    public event EventHandler<Vanara.Windows.Shell.NavigatedEventArgs> Navigated;
    public event EventHandler<Vanara.Windows.Shell.NavigationFailedEventArgs> NavigationFailed;

    private Task<HRESULT>? _currentNavigationTask;
    private bool _isLoading;


    public ExplorerBrowser()
    {
        InitializeComponent();
        DataContext = this;

        PrimaryShellTreeView.Navigated += PrimaryShellTreeView_Navigated;
        PrimaryShellListView.Navigated += PrimaryShellTreeView_Navigated;
    }

    internal async Task<HRESULT> Navigate(ShellBrowserItem target)
    {
        var shTargetItem = target.ShellItem;

        Debug.WriteLineIf(!shTargetItem.IsFolder, $".WARN: Navigate({target.DisplayName}) => is not a folder!");
        // TODO: If no folder, or drive empty, etc... show empty listview with error message

        // TODO: init ShellNamespaceService
        try
        {
            if (_currentNavigationTask is { IsCompleted: false })
            {
                Debug.Print("ERROR! <_currentNavigationTask> already running");
                // cancel current task
                //CurrentNavigationTask
            }

            // IsLoading = true;

            if (target.ChildItems.Count <= 0)
            {
                using var shFolder = new ShellFolder(target.ShellItem);

                target.ChildItems.Clear();
                PrimaryShellListView.Items.Clear();
                DispatcherQueue.TryEnqueue(() =>
                {
                    foreach (var child in shFolder)
                    {
                        var ebItem = new ShellBrowserItem(child);

                        target.ChildItems.Add(ebItem);
                        PrimaryShellListView.Items.Add(ebItem);
                    }
                });
            }
            else
            {
                Debug.WriteLine(".Navigate() => Cache hit!");
                PrimaryShellListView.Items.Clear();
                foreach (var child in target.ChildItems)
                {
                    PrimaryShellListView.Items.Add(child);
                }
            }

            // TODO: Load folder-open icon and overlays
        }
        catch (COMException comEx)
        {
            Debug.Fail(
                $"[Error] Navigate(<{target}>) failed. COMException: <HResult: {comEx.HResult}>: `{comEx.Message}`");

            return new HRESULT(comEx.HResult);
        }
        catch (Exception ex)
        {
            Debug.Fail($"[Error] Navigate(<{target}>) failed, reason unknown: {ex.Message}");
            throw;
        }
        finally
        {
            //IsLoading = false;
        }

        return HRESULT.S_OK;
    }


    private async void PrimaryShellTreeView_Navigated(object sender, NavigatedEventArgs e)
    {
        Debug.Print($".PrimaryShellTreeView_Navigated() to {e.NewLocation.Name}");

        _ = Navigate(new ShellBrowserItem(e.NewLocation));  // WARN: This is a fire-and-forget call, no await! // WARN: Use existing ShellBrowserItem from TreeView
    }
}
