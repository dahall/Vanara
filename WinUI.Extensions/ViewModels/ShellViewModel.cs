using CommunityToolkit.Mvvm.ComponentModel;
using electrifier.Contracts.Services;
using electrifier.Views;
using Microsoft.UI.Xaml.Navigation;

namespace electrifier.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;

    [ObservableProperty]
    private object? selected;

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        //LazyInitializer.EnsureInitialized(ref _instance, () => this);
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
    }

    private void OnNavigated(object sender, NavigationEventArgs args)
    {
        try
        {
            if (args.SourcePageType == typeof(SettingsPage))
            {
                //Selected = NavigationViewService.SettingsItem;
                IsBackEnabled = true;
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in OnNavigated: {ex.Message}");

            IsBackEnabled = NavigationService.CanGoBack;

            var selectedItem = NavigationViewService.GetSelectedItem(args.SourcePageType);
            if (selectedItem != null)
            {
                Selected = selectedItem;
            }
        }
    }
}
