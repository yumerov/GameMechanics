using LootTables.LootItems;

namespace LootTables.LootTables.Contracts;

public interface IRegisterableLooTable
{
    public void RegisterFor(Type enemyType, List<Func<ILootItem>> itemFactories);
}