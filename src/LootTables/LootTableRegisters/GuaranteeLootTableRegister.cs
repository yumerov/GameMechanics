using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;
using LootTables.LootTables.Contracts;

namespace LootTables.LootTableRegisters;

/// <summary>
/// Simulates reading from a file edited by the game designer/balancer
/// </summary>
public static class GuaranteeLootTableRegister
{
    public static ILootTable DefaultInit()
    {
        var table = new GuaranteeLootTable();
    
        table.RegisterFor(typeof(Rat), [() => new SmallGoldBag(), () => new RatTail()]);
        table.RegisterFor(typeof(Slime), [() => new AcidicSlimeBall()]);
        
        return table;
    }
}