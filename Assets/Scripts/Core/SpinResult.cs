using System;

namespace Arcanarchy.Core
{
    public sealed class SpinResult
    {
        private readonly SymbolId[,] symbols;

        public int ReelCount { get; }
        public int RowCount { get; }

        public SpinResult(SymbolId[,] symbols)
        {
            this.symbols = symbols
                ?? throw new ArgumentNullException(nameof(symbols));

            ReelCount = symbols.GetLength(0);
            RowCount = symbols.GetLength(1);
        }

        public SymbolId GetSymbol(int reelIndex, int rowIndex)
        {
            return symbols[reelIndex, rowIndex];
        }
    }
}