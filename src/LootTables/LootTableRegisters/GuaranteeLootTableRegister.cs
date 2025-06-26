using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.LootTableRegisters;

public static class GuaranteeLootTableRegister
{
    public static GuaranteeLootTable DefaultInit()
    {
        var table = new GuaranteeLootTable();
    
        table.RegisterFor(typeof(Rat), [() => new SmallGoldBag(), () => new RatTail()]);
        table.RegisterFor(typeof(Slime), [() => new AcidicSlimeBall()]);
        
        return table;
    }
}