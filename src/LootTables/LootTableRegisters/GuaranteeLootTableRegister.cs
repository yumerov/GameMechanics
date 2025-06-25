using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.LootTableRegisters;

public class GuaranteeLootTableRegister : LootTableRegister
{
    public static GuaranteeLootTable DefaultInit()
    {
        var table = new GuaranteeLootTable();
    
        table.RegisterFor(typeof(Rat), [typeof(SmallGoldBag), typeof(RatTail)]);
        table.RegisterFor(typeof(Slime), []);
        table.RegisterFor(typeof(Skeleton), []);
        
        return table;
    }
}