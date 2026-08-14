using System;

namespace Arcanarchy.Core
{
    public sealed class SeededRandomSource : IRandomSource
    {
        private readonly Random random;

        public SeededRandomSource(int seed)
        {
            random = new Random(seed);
        }

        public int Next(int minimumInclusive, int maximumExclusive)
        {
            return random.Next(minimumInclusive, maximumExclusive);
        }
    }
}