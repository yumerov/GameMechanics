namespace LootTables.LootTables;

public abstract class LootTable
{
    protected readonly Dictionary<Type, List<Type>> EnemyItemsMap = new();
    
    public bool RegisterFor(Type enemyType, List<Type> items) => EnemyItemsMap.TryAdd(enemyType, items);
}