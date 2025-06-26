namespace LootTables.LootItems;

public class ContainerItem<TContainedItem>(int count) : LootItem where TContainedItem : ILootItem, new()
{
    public override string ToString() => $"{count} {typeof(TContainedItem).Name}s";
}