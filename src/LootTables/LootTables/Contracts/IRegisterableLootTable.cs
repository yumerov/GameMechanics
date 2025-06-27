using LootTables.LootItems;

namespace LootTables.LootTables.Contracts;

public interface IRegisterableLootTable
{
    public void RegisterFor(Type enemyType, List<Func<ILootItem>> itemFactories);
}