using System.Collections.ObjectModel;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;
using BaseListView = Terminal.Gui.Views.ListView;


namespace LootTables.App;

public class ListView<T>(ObservableCollection<T> items)
{
    public readonly BaseListView BaseListView = new()
    {
        Width = Dim.Fill(),
        Height = Dim.Fill(),
        Source = new ListWrapper<T>(items)
    };

    public event EventHandler<ListViewItemEventArgs> OpenSelectedItem
    {
        add => BaseListView.OpenSelectedItem += value;
        remove => BaseListView.OpenSelectedItem -= value;
    }
    
}