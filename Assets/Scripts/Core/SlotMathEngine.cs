using System;
using System.Collections.Generic;

namespace Arcanarchy.Core
{
    public sealed class SlotMathEngine
    {
        private readonly ReelStrip[] reelStrips;
        private readonly int rowCount;
        private readonly IRandomSource randomSource;

        public SlotMathEngine(
            IEnumerable<ReelStrip> reelStrips,
            int rowCount,
            IRandomSource randomSource)
        {
            this.reelStrips = new List<ReelStrip>(reelStrips).ToArray();
            this.rowCount = rowCount;
            this.randomSource = randomSource
                ?? throw new ArgumentNullException(nameof(randomSource));

            if (this.reelStrips.Length == 0)
            {
                throw new ArgumentException(
                    "The engine requires at least one reel strip.",
                    nameof(reelStrips)
                );
            }

            if (rowCount <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(rowCount),
                    "Row count must be greater than zero."
                );
            }
        }

        public SpinResult Spin()
        {
            var visibleSymbols =
                new SymbolId[reelStrips.Length, rowCount];

            for (int reelIndex = 0;
                 reelIndex < reelStrips.Length;
                 reelIndex++)
            {
                ReelStrip reelStrip = reelStrips[reelIndex];

                int stopPosition = randomSource.Next(
                    0,
                    reelStrip.Length
                );

                for (int rowIndex = 0;
                     rowIndex < rowCount;
                     rowIndex++)
                {
                    visibleSymbols[reelIndex, rowIndex] =
                        reelStrip.GetSymbol(stopPosition + rowIndex);
                }
            }

            return new SpinResult(visibleSymbols);
        }
    }
}