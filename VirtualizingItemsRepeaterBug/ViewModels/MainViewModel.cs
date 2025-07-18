using CommunityToolkit.Mvvm.ComponentModel;

namespace VirtualizingItemsRepeaterBug.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";

    public SelectorViewModel SelectorViewModel { get; init; } = new();
}