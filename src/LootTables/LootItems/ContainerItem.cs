namespace LootTables.LootItems;

public class ContainerItem(int count, Type type) : LootItem
{
    public override string ToString() => $"{count} {Activator.CreateInstance(type)}s";
}