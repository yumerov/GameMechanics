using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.LootTableRegisters;

public class OneOfManyLootTableRegister : LootTableRegister
{
    public static OneOfManyLootTable DefaultInit()
    {
        var table = new OneOfManyLootTable();
    
        table.RegisterFor(typeof(Skeleton), [typeof(BoneDagger), typeof(BoneClub), typeof(SkullHelmet)]);
        
        return table;
    }
}