using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables.Contracts;

public interface ILootTable
{
    public IReadOnlyCollection<Type> EnemyTypes { get; }
    public List<ILootItem> LootFor(ILootableEnemy enemy);
}