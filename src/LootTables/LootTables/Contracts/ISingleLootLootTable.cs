using LootTables.LootItems;

namespace LootTables.LootTables.Contracts;

public interface ISingleLootLootTable
{
    public void RegisterFor(Type enemyType, List<Func<ILootItem>> itemFactories);
}