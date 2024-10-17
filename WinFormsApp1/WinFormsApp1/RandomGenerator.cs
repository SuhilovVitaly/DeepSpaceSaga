using System;
using System.Linq;

namespace OutlandSpace.Universe.Tools
{
    public class RandomGenerator
    {
        private Random _randomBase = new((int)DateTime.UtcNow.Ticks);

        public void Rebase(int randomBase)
        {
            _randomBase = new Random(randomBase);
        } 

        public int GetInteger(int min = 0, int max = 0)
        {
            return _randomBase.Next(min, max);
        }
    }

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
            return RandomString(6) + "-" + RandomNumber(4) + "-" + RandomNumber(4);
        }

        public double Direction()
        {
            return GetDouble(0, 359);
        }

        public double GetDouble(double minimum = 0, double maximum = 0)
        {
            return _randomBase.NextDouble() * (maximum - minimum) + minimum;
        }

        public float GetFloat(double minimum = 0, double maximum = 0)
        {
            return (float)(_randomBase.NextDouble() * (maximum - minimum) + minimum);
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
}