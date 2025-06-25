using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public abstract class LootTable : ILootTable
{
    protected readonly Dictionary<Type, List<Type>> EnemyItemsMap = new();
    public IReadOnlyCollection<Type> EnemyTypes => EnemyItemsMap.Keys;

    public void RegisterFor(Type enemyType, List<Type> items) => EnemyItemsMap.TryAdd(enemyType, items);
    public abstract List<LootItem> LootFor(LootableEnemy enemy);
}