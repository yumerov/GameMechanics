using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.Tests.LootTables;

public class CompositeLootTableTest
{
    private readonly Type _skeleton = typeof(Skeleton);
    private readonly Type _slime = typeof(Slime);

    [Fact]
    public void EnemyTypes()
    {
        // Arrange
        var goldLootTable = new GuaranteeLootTable();
        goldLootTable.RegisterFor(_skeleton, [() => new SmallGoldBag()]);
        goldLootTable.RegisterFor(_slime, [() => new SmallGoldBag()]);
        var experienceLootTable = new GuaranteeLootTable();
        experienceLootTable.RegisterFor(_skeleton, [() => new SmallExperiencePack()]);
        
        var table = new CompositeLootTable([goldLootTable, experienceLootTable]);
        
        // Act
        var enemyTypes = table.EnemyTypes;
        
        // Assert
        Assert.Equal([_skeleton, _slime], enemyTypes);
    }

    [Fact]
    public void LootFor()
    {
        // Arrange
        var goldLootTable = new GuaranteeLootTable();
        goldLootTable.RegisterFor(_skeleton, [() => new SmallGoldBag()]);
        goldLootTable.RegisterFor(_slime, [() => new SmallGoldBag()]);
        var experienceLootTable = new GuaranteeLootTable();
        experienceLootTable.RegisterFor(_skeleton, [() => new SmallExperiencePack()]);
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
        Assert.Contains<ILootItem>(
            [new BoneDagger(), new BoneClub(), new SkullHelmet()],
            item => item.ToString() == loots[2].ToString()
        );
    }
}