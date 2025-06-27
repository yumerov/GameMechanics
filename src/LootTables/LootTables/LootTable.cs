using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables.Contracts;

namespace LootTables.LootTables;

public abstract class LootTable : ILootTable, ISingleLootLootTable, IRegisterableLooTable
{
    private readonly Dictionary<Type, List<Func<ILootItem>>> _enemyItemFactoriesMap = new();
    public IReadOnlyCollection<Type> EnemyTypes => _enemyItemFactoriesMap.Keys;

    public void RegisterFor(Type enemyType, List<Func<ILootItem>> itemFactories) => _enemyItemFactoriesMap
        .TryAdd(enemyType, itemFactories);

    protected List<Func<ILootItem>> GetLootFactories(ILootableEnemy enemy) => !_enemyItemFactoriesMap
        .TryGetValue(enemy.GetType(), out var enemyItemTypes) ? [] : enemyItemTypes;

    public abstract List<ILootItem> LootFor(ILootableEnemy enemy);
}