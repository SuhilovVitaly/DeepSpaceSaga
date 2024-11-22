namespace DeepSpaceSaga.Common.Tools;

public class RandomGenerator
{
    private static readonly Random RandomBase = new Random((int)DateTime.UtcNow.Ticks);

    public static int GetInteger(int min = 0, int max = 0)
    {
        return RandomBase.Next(min, max);
    }

    public static int GetInteger(int max)
    {
        return RandomBase.Next(max);
    }

    public static int GetId()
    {
        return RandomBase.Next(1000000000, int.MaxValue);
    }

    public static double GetDouble(double minimum = 0, double maximum = 0)
    {
        var baseValue = RandomBase.NextDouble();

        if ((maximum - minimum).CompareTo(0) == 0) return baseValue;

        return baseValue * (maximum - minimum) + minimum;

    }

    public static int DiceRoller(int numberOfSides = 100)
    {
        return GetInteger(1, numberOfSides);
    }

    public static double Direction()
    {
        return GetDouble(0, 359);
    }

    public static string GenerateCelestialObjectName()
    {
        return RandomString(6) + "-" + RandomNumber(4) + "-" + RandomNumber(4);
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[RandomBase.Next(s.Length)]).ToArray());
    }

    public static string RandomNumber(int length)
    {
        const string chars = "1234567890";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[RandomBase.Next(s.Length)]).ToArray());
    }
}
