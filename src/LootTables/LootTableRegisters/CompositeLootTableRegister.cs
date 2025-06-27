using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;
using LootTables.LootTables.Contracts;

namespace LootTables.LootTableRegisters;

public static class CompositeLootTableRegister
{
    private static readonly Type Skeleton = typeof(Skeleton);
    private static readonly Type Slime = typeof(Slime);

    public static ILootTable DefaultInit()
    {
        var goldLootTable = new GuaranteeLootTable();
        goldLootTable.RegisterFor(Skeleton, [() => new SmallGoldBag()]);
        goldLootTable.RegisterFor(Slime, [() => new SmallGoldBag()]);
        var experienceLootTable = new GuaranteeLootTable();
        experienceLootTable.RegisterFor(Skeleton, [() => new SmallExperiencePack()]);
        var weaponLootTable = new OneOfManyLootTable();
        weaponLootTable.RegisterFor(typeof(Skeleton), [
            () => new BoneDagger(),
            () => new BoneClub(),
            () => new SkullHelmet()
        ]);
        var table = new CompositeLootTable([goldLootTable, experienceLootTable, weaponLootTable]);
        
        return table;
    }
}