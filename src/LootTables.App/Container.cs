using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace LootTables.App;

public class Container
{
    public readonly Toplevel Toplevel = new()
    {
        Width = Dim.Fill(),
        Height = Dim.Fill()
    };

    public void Add(params Window[]? views)
    {
        if (views is null)
        {
            return;
        }

        foreach (var view in views)
        {
            Toplevel.Add(view.BaseWindow);
        }
    }

}