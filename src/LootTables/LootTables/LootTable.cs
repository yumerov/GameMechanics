using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public abstract class LootTable : ILootTable
{
    protected readonly Dictionary<Type, List<Func<LootItem>>> EnemyItemFactoriesMap = new();
    public IReadOnlyCollection<Type> EnemyTypes => EnemyItemFactoriesMap.Keys;

    public void RegisterFor(Type enemyType, List<Func<LootItem>> itemFactories) => EnemyItemFactoriesMap
        .TryAdd(enemyType, itemFactories);

    public List<Func<LootItem>> GetLootFactories(LootableEnemy enemy)
    {
        return !EnemyItemFactoriesMap.TryGetValue(enemy.GetType(), out var enemyItemTypes) ? [] : enemyItemTypes;
    }

    public abstract List<LootItem> LootFor(LootableEnemy enemy);
}