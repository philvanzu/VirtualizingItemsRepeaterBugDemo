
using CommunityToolkit.Mvvm.ComponentModel;
using VirtualizingItemsRepeaterBug.ViewModels;

namespace VirtualizingItemsRepeaterBug;

public partial class SelectableViewModel: ViewModelBase, ISelectableItem
{
    public SelectorViewModel? Selector { get; init; }
    [ObservableProperty] private bool _isLoaded;
    [ObservableProperty] private string _itemText;
    partial void OnIsLoadedChanged(bool value)
    {
        ItemText = value ? $"{Index} is loaded" : $"{Index} is NOT LOADED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
    }

    public int Index { get; init; }
    
    public bool IsSelected { get; set; }
    public bool IsFirstItem => Selector?.GetSelectedIndex(this)==0;
}