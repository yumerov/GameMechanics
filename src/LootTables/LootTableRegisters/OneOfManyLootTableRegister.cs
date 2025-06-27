using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;
using LootTables.LootTables.Contracts;

namespace LootTables.LootTableRegisters;

/// <summary>
/// Simulates reading from a file edited by the game designer/balancer
/// </summary>
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