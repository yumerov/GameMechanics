using System.Collections.ObjectModel;
using LootTables.Enemies;
using LootTables.LootTableRegisters;
using LootTables.LootTables;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace LootTables.App;

public class App
{
    public static readonly Dim ColWidth = Dim.Percent(33)!;

    private readonly ObservableCollection<LootTable> _menuItems = [
        GuaranteeLootTableRegister.DefaultInit(),
        OneOfManyLootTableRegister.DefaultInit()
    ];

    private readonly ObservableCollection<LootableEnemy> _enemies = [];
    private readonly ObservableCollection<string> _logs = [];

    public void Run()
    {
        Application.Init();
        var container = new Container();

        var menuList = new ListView<LootTable>(_menuItems);
        menuList.OpenSelectedItem += (_, args) => OnLootTableTypeSelectedSelected(args);
        
        var enemyList = new ListView<LootableEnemy>(_enemies);
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
        foreach (var lootTable in _menuItems)
        {
            if (!lootTable.EnemyTypes.Contains(enemy.GetType()))
            {
                continue;
            }
                
            var loots = lootTable.LootFor(enemy);
            foreach (var loot in loots)
            {
                _logs.Add($"[{lootTable}] {enemy} loot: {loot}");
            }
        }
    }
    
    private void OnLootTableTypeSelectedSelected(ListViewItemEventArgs args)
    {
        var selectedLootTable = _menuItems[args.Item];

        _enemies.Clear();
        foreach (var enemyType in selectedLootTable.EnemyTypes)
        {
            _enemies.Add((Activator.CreateInstance(enemyType) as LootableEnemy)!);
        }
    }
}