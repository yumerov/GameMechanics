using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public class GuaranteeLootTable : LootTable
{
    public override string ToString() => "Guarantee";

    public List<LootItem> LootFor(LootableEnemy enemy)
    {
        List<Type>? enemyItemTypes = EnemyItemsMap[enemy.GetType()];
        if (enemyItemTypes == null) return [];
        
        return enemyItemTypes
            .Select(type => Activator.CreateInstance(type) as LootItem)!
            .ToList<LootItem>();
    }
}