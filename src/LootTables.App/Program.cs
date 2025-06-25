using System.Collections.ObjectModel;
using LootTables.Enemies;
using LootTables.LootTableRegisters;
using LootTables.LootTables;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

Application.Init();

var top = new Toplevel()
{
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

var guaranteeLootTable = GuaranteeLootTableRegister.DefaultInit();
ObservableCollection<LootTable> menuItems = [guaranteeLootTable];
var enemies = new ObservableCollection<LootableEnemy>();
var logs = new ObservableCollection<string>();

var menuList = new ListView
{
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    Source = new ListWrapper<LootTable>(menuItems)
};
menuList.OpenSelectedItem += (_, args) =>
{
    var selectedLootTable = menuItems[args.Item];
    if (selectedLootTable is GuaranteeLootTable)
    {
        enemies.Clear();
        enemies.Add(new Slime());
        enemies.Add(new Rat());
        enemies.Add(new Skeleton());
    }
};

var enemyList = new ListView
{
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    Source = new ListWrapper<LootableEnemy>(enemies)
};
enemyList.OpenSelectedItem += (_, args) =>
{
    var loot = guaranteeLootTable.LootFor(enemies[args.Item]);
    logs.Add(loot.Count > 0 ? $"Loots: {string.Join(", ", loot.DefaultIfEmpty())}" : "No loots found");
};

var logList = new ListView
{
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    Source = new ListWrapper<string>(logs)
};

var colWidth = Dim.Percent(33);

var menuView = new Window()
{
    Title = "Loot Tables types",
    X = 0,
    Y = 0,
    Width = colWidth,
    Height = Dim.Fill()
};
menuView.Add(menuList);

var enemyView = new Window()
{
    Title = "Enemies",
    X = Pos.Right(menuView),
    Y = 0,
    Width = colWidth,
    Height = Dim.Fill()
};
enemyView.Add(enemyList);

var logView = new Window()
{
    Title = "Logs",
    X = Pos.Right(enemyView),
    Y = 0,
    Width = Dim.Fill(),
    Height = Dim.Fill()
};
logView.Add(logList);

top.Add(menuView, enemyView, logView);

Application.Run(top);
Application.Shutdown();