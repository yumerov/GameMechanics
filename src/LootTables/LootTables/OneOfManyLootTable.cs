using Common;
using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public class OneOfManyLootTable : LootTable
{
    public override string ToString() => "One of Many";

    public override List<ILootItem> LootFor(ILootableEnemy enemy)
    {
        var enemyItemTypes = GetLootFactories(enemy);
        if (enemyItemTypes.Count == 0)
        {
            return [];
        }

        var selectedIndex = new Dice(0, enemyItemTypes.Count - 1).Throw();
        var selectedItemFactory = enemyItemTypes[selectedIndex];

        return [selectedItemFactory()];
    }
}