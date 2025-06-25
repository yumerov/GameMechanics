using LootTables.Enemies;
using LootTables.LootItems;
using LootTables.LootTables;

namespace LootTables.Tests.LootTables;

public class OneOfManyLootTableTest
{
    [Fact]
    public void RegisterFor()
    {
        // Arrange
        var table = new OneOfManyLootTable();
        var rat = typeof(Rat);
        
        // Act
        table.RegisterFor(rat, [typeof(RatTail), typeof(SmallGoldBag)]);
        
        // Assert
        Assert.Equal([rat], table.EnemyTypes);
        
        // Arrange
        var slime = typeof(Slime);
        
        // Act
        table.RegisterFor(slime, [typeof(AcidicSlimeBall)]);
        
        // Assert
        Assert.Equal([rat, slime], table.EnemyTypes);
    }
    
    [Fact]
    public void LootFor()
    {
        // Arrange
        var table = new OneOfManyLootTable();
        var skeleton = new Skeleton();
        var club = new BoneClub();
        var helmet = new SkullHelmet();
        table.RegisterFor(typeof(Skeleton), [typeof(BoneClub), typeof(SkullHelmet)]);
        
        // Act
        var clubCount = 0;
        var helmetCount = 0;
        const double delta = 0.02;
        const int sampleSize = 10_000;

        for (var index = 0; index < 2 * sampleSize; index++)
        {
            var loot = table.LootFor(skeleton)[0].ToString()!;
            if (loot.Equals(club.ToString()))
            {
                clubCount++;
            } else if (loot.Equals(helmet.ToString()))
            {
                helmetCount++;
            }
            else
            {
                Assert.Fail("Unexpected item");
            }

        }

        // Assert
        Assert.InRange(clubCount, sampleSize * (1 - delta), sampleSize * (1 + delta));
        Assert.InRange(helmetCount, sampleSize * (1 - delta), sampleSize * (1 + delta));
    }
}