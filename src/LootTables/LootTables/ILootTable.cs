using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public interface ILootTable
{
    public IReadOnlyCollection<Type> EnemyTypes { get; }
    public void RegisterFor(Type enemyType, List<Func<ILootItem>> itemFactories);
    public List<ILootItem> LootFor(ILootableEnemy enemy);
}