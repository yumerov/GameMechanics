using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.LootTableRegisters;

public static class OneOfManyLootTableRegister
{
    public static ILootTable DefaultInit()
    {
        var table = new OneOfManyLootTable();
    
        table.RegisterFor(typeof(Skeleton), [
            () => new BoneDagger(),
            () => new BoneClub(),
            () => new SkullHelmet()
        ]);
        
        return table;
    }
}