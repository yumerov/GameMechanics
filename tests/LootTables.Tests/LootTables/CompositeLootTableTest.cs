using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.Tests.LootTables;

public class CompositeLootTableTest
{
    private static readonly Type Skeleton = typeof(Skeleton);
    private static readonly Type Slime = typeof(Slime);

    [Fact]
    public void EnemyTypes()
    {
        // Arrange
        var goldLootTable = new GuaranteeLootTable();
        goldLootTable.RegisterFor(Skeleton, [() => new SmallGoldBag()]);
        goldLootTable.RegisterFor(Slime, [() => new SmallGoldBag()]);
        var experienceLootTable = new GuaranteeLootTable();
        experienceLootTable.RegisterFor(Skeleton, [() => new SmallExperiencePack()]);
        
        var table = new CompositeLootTable([goldLootTable, experienceLootTable]);
        
        // Act
        var enemyTypes = table.EnemyTypes;
        
        // Assert
        Assert.Equal([Skeleton, Slime], enemyTypes);
    }

    [Fact]
    public void LootFor()
    {
        // Arrange
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
        
        // Act
        var loots = table.LootFor(new Skeleton());
        Assert.Equal(3, loots.Count);
        Assert.Equal(new SmallGoldBag().ToString(), loots[0].ToString());
        Assert.Equal(new SmallExperiencePack().ToString(), loots[1].ToString());
        Assert.True(
            new List<ILootItem>([new BoneDagger(), new BoneClub(), new SkullHelmet()])
                .Any(item => item.ToString() == loots[2].ToString()),
            $"Expected one of [BoneDagger, BoneClub, SkullHelmet] but got {loots[2]}"
        );
    }
}