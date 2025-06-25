namespace Common;

public class Dice(int min, int max)
{
    private readonly Random _random = new Random();

    public int Throw() => _random.Next(min, max + 1);
}