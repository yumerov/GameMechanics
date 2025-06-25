using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public abstract class LootTable
{
    protected readonly Dictionary<Type, List<Type>> EnemyItemsMap = new();

    public List<Type> EnemyTypes => EnemyItemsMap.Keys.ToList();

    public bool RegisterFor(Type enemyType, List<Type> items) => EnemyItemsMap.TryAdd(enemyType, items);
    
    public List<LootItem> LootFor(LootableEnemy enemy)
    {
        List<Type>? enemyItemTypes = EnemyItemsMap[enemy.GetType()];
        if (enemyItemTypes == null) return [];
        
        return enemyItemTypes
            .Select(type => Activator.CreateInstance(type) as LootItem)!
            .ToList<LootItem>();
    }
}