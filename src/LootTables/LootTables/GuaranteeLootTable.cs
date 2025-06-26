using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public class GuaranteeLootTable : LootTable
{
    public override string ToString() => "Guarantee";

    public override List<LootItem> LootFor(LootableEnemy enemy) => GetLootFactories(enemy)
        .Select(factory => factory())
        .ToList();
}