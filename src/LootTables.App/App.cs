using System.Collections.ObjectModel;
using LootTables.Enemies;
using LootTables.LootTableRegisters;
using LootTables.LootTables.Contracts;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace LootTables.App;

public class App
{
    public static readonly Dim ColWidth = Dim.Percent(33)!;
    public ILootTable? _lootTable;

    private readonly ObservableCollection<ILootTable> _menuItems =
    [
        GuaranteeLootTableRegister.DefaultInit(),
        OneOfManyLootTableRegister.DefaultInit(),
        CompositeLootTableRegister.DefaultInit()
    ];

    private readonly ObservableCollection<ILootableEnemy> _enemies = [];
    private readonly ObservableCollection<string> _logs = [];

    public void Run()
    {
        Application.Init();
        var container = new Container();

        var menuList = new ListView<ILootTable>(_menuItems);
        menuList.OpenSelectedItem += (_, args) => OnLootTableTypeSelectedSelected(args);

        var enemyList = new ListView<ILootableEnemy>(_enemies);
        enemyList.OpenSelectedItem += (_, args) => OnEnemySelected(args);

        var logList = new ListView<string>(_logs);

        var menuView = new Window("Loot Tables types").Add(menuList);
        var enemyView = new Window("Enemies", menuView).Add(enemyList);
        var logView = new Window("Logs", enemyView).Add(logList);

        container.Add(menuView, enemyView, logView);

        Application.Run(container.Toplevel);
        Application.Shutdown();
    }

    private void OnEnemySelected(ListViewItemEventArgs args)
    {
        var enemy = _enemies[args.Item];

        if (_lootTable == null)
        {
            return;
        }
        
        if (!_lootTable.EnemyTypes.Contains(enemy.GetType()))
        {
            return;
        }

        var loots = _lootTable!.LootFor(enemy);
        foreach (var loot in loots)
        {
            _logs.Add($"[{_lootTable}] {enemy} loot: {loot}");
        }
    }

    private void OnLootTableTypeSelectedSelected(ListViewItemEventArgs args)
    {
        _lootTable = _menuItems[args.Item];

        _enemies.Clear();
        foreach (var enemyType in _lootTable.EnemyTypes)
        {
            if (Activator.CreateInstance(enemyType) is ILootableEnemy enemy)
            {
                _enemies.Add(enemy);
            }
        }
    }
}