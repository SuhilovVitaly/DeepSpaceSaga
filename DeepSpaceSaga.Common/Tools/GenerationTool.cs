namespace DeepSpaceSaga.Common.Tools;

public class GenerationTool
{
    private Random _randomBase;

    public GenerationTool()
    {
        _randomBase = new Random((int)DateTime.UtcNow.Ticks);
    }

    public GenerationTool(int randomBase)
    {
        _randomBase = new Random(randomBase);
    }

    public int GetInteger(int min = 0, int max = 0)
    {
        return _randomBase.Next(min, max);
    }

    public string GenerateCelestialObjectName()
    {
        return RandomString(4) + "-" + RandomNumber(4) + "-" + RandomNumber(3);
    }

    public double Direction()
    {
        return GetDouble(0, 359);
    }

    public double GetDouble(double minimum = 0, double maximum = 0)
    {
        return _randomBase.NextDouble() * (maximum - minimum) + minimum;
    }

    public int GetId()
    {
        return _randomBase.Next(1000000000, int.MaxValue);
    }

    private string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_randomBase.Next(s.Length)]).ToArray());
    }

    public string RandomNumber(int length)
    {
        const string chars = "1234567890";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_randomBase.Next(s.Length)]).ToArray());
    }
}
