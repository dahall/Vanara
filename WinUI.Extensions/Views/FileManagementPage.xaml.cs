using electrifier.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace electrifier.Views;

public sealed partial class FileManagementPage : Page
{
    private readonly FileManagementViewModel viewModel;

    public FileManagementViewModel ViewModel => viewModel;

    public FileManagementPage()
    {
        viewModel = App.GetService<FileManagementViewModel>();
        InitializeComponent();
    }
}
