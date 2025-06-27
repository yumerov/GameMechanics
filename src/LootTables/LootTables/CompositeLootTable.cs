using System.Collections.Immutable;
using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables.Contracts;

namespace LootTables.LootTables;

public class CompositeLootTable(ImmutableList<ILootTable> lootTables) : ILootTable, ICompositeLootTable
{
    public override string ToString() => "Composite";

    public IReadOnlyCollection<Type> EnemyTypes => lootTables
        .SelectMany(lootTable => lootTable.EnemyTypes)
        .ToHashSet();

    public List<ILootItem> LootFor(ILootableEnemy enemy) => lootTables
        .SelectMany(lootTable => lootTable.LootFor(enemy))
        .ToList();
}