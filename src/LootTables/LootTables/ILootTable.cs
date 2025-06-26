using LootTables.Enemies;
using LootTables.LootItems;

namespace LootTables.LootTables;

public interface ILootTable
{
    public void RegisterFor(Type enemyType, List<Func<LootItem>> itemFactories);
    public List<LootItem> LootFor(LootableEnemy enemy);
}