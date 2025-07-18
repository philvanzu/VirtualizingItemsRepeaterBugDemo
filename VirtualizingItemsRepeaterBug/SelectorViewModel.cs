using System;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VirtualizingItemsRepeaterBug.ViewModels;

namespace VirtualizingItemsRepeaterBug;

public partial class SelectorViewModel : ViewModelBase, ISelectItems
{
    public event EventHandler<SelectedItemChangedEventArgs>? SelectionChanged;
    public event EventHandler? SortOrderChanged;
    public event EventHandler<int>? ScrollToIndexRequested;

    [ObservableProperty] private SelectableViewModel? _selected;
    [ObservableProperty] private ObservableCollection<SelectableViewModel> _items = new ();

    public SelectorViewModel()
    {
        for (int i = 0; i < 10000; i++)
        {
            var item = new SelectableViewModel()
            {
                Index = i,
                Selector = this,
            };
            Items.Add(item);
        }
    }

    partial void OnSelectedChanged(SelectableViewModel? value)
    {
        foreach (var item in _items)
            if(item.IsSelected && item != value)
                item.IsSelected = false;
    }

    public void InvokeSelectionChanged(ISelectableItem? newItem, ISelectableItem? oldItem)
    {
        
    }

    public void InvokeSortOrderChanged()
    {
        
    }

    public void RequestScrollToIndex(int index)
    {
        
    }

    public int GetSelectedIndex()
    {
        if(Selected == null)return -1;
        return Items.IndexOf(Selected);
    }

    public int GetSelectedIndex(SelectableViewModel item)
    {
        return Items.IndexOf(item);
    }

    [RelayCommand]
    private void ItemPrepared(object? item)
    {
        //load thumbnail
        if(item is SelectableViewModel selectable)
            selectable.IsLoaded = true;
    }

    [RelayCommand]
    private void ItemClearing(object? item)
    {
        //Release Thumbnail
        if(item is SelectableViewModel selectable)
            selectable.IsLoaded = false;
    }
}