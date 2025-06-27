using Terminal.Gui.ViewBase;
using BaseWindow = Terminal.Gui.Views.Window;

namespace LootTables.App;

public class Window(string title, Window? nextTo = null)
{
    public readonly BaseWindow BaseWindow = new()
    {
        Title = title,
        X = nextTo == null ? 0 : Pos.Right(nextTo.BaseWindow),
        Y = 0,
        Width = App.ColWidth,
        Height = Dim.Fill()
    };

    public Window Add<T>(ListView<T> view)
    {
        BaseWindow.Add(view.BaseListView);
        
        return this;
    }

}