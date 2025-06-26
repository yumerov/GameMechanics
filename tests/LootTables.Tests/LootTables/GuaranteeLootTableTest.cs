using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.Tests.LootTables;

public class GuaranteeLootTableTest
{
    [Fact]
    public void RegisterFor()
    {
        // Arrange
        var table = new GuaranteeLootTable();
        var skeleton = typeof(Skeleton);
        
        // Act
        table.RegisterFor(skeleton, [() => new BoneClub(), () => new SkullHelmet()]);
        
        // Assert
        Assert.Equal([skeleton], table.EnemyTypes);
        
        // Arrange
        var slime = typeof(Slime);
        
        // Act
        table.RegisterFor(slime, [() => new AcidicSlimeBall()]);
        
        // Assert
        Assert.Equal([skeleton, slime], table.EnemyTypes);
    }
    
    [Fact]
    public void LootFor()
    {
        // Arrange
        var table = new GuaranteeLootTable();
        var skeleton = new Skeleton();
        var club = new BoneClub();
        var helmet = new SkullHelmet();
        table.RegisterFor(typeof(Skeleton), [() => new BoneClub(), () => new SkullHelmet()]);
        
        // Act
        var loots = table.LootFor(skeleton);
        
        // Assert
        Assert.Equal(club.GetType(), loots[0].GetType());
        Assert.Equal(helmet.GetType(), loots[1].GetType());
    }
}