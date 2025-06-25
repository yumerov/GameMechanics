using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public class GuaranteeLootTable : LootTable
{
    public override string ToString() => "Guarantee";

    public override List<LootItem> LootFor(LootableEnemy enemy)
    {
        if (!EnemyItemsMap.TryGetValue(enemy.GetType(), out var enemyItemTypes))
        {
            return [];
        }
        
        return enemyItemTypes
            .Select(type => Activator.CreateInstance(type) as LootItem)
            .OfType<LootItem>()
            .ToList();
    }
}