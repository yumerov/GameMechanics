using Common;
using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public class OneOfManyLootTable : LootTable
{
    public override string ToString() => "One of Many";

    public override List<LootItem> LootFor(LootableEnemy enemy)
    {
        List<Type>? enemyItemTypes = EnemyItemsMap[enemy.GetType()];
        if (enemyItemTypes == null) return [];

        var dice = new Dice(0, enemyItemTypes.Count - 1);

        var selectedItem = enemyItemTypes[dice.Throw()];

        return [(Activator.CreateInstance(selectedItem) as LootItem)!];
    }
}