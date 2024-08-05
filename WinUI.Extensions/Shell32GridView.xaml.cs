using CommunityToolkit.WinUI.Collections;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System;
using Vanara.Windows.Shell;
using Visibility = Microsoft.UI.Xaml.Visibility;

namespace electrifier.Controls.Vanara;

// ObservableRecipient ???
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(), nq}}")]
public sealed partial class Shell32GridView : INotifyPropertyChanged
{
    public GridView NativeGridView => GridView;
    public object ItemsSource
    {
        get => NativeGridView.ItemsSource;
        set => NativeGridView.ItemsSource = value;
    }

    public Shell32GridView()
    {
        InitializeComponent();
        DataContext = this;

    }

    //private void NativeGridView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    //{
    //    //Debug.WriteLine($".NativeGridView_ContainerContentChanging()");
    //}

    private string GetDebuggerDisplay()
    {
        return nameof(Shell32GridView) + ToString();
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    #endregion
}
