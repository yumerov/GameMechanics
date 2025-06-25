namespace Common;

public class Dice(int min, int max)
{
    private static readonly Random Random = new();

    public int Throw() => Random.Next(min, max + 1);
}