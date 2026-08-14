using System;
using System.Collections.Generic;

namespace Arcanarchy.Core
{
    public sealed class ReelStrip
    {
        private readonly SymbolId[] symbols;

        public int Length => symbols.Length;

        public ReelStrip(IEnumerable<SymbolId> symbols)
        {
            this.symbols = new List<SymbolId>(symbols).ToArray();

            if (this.symbols.Length == 0)
            {
                throw new ArgumentException(
                    "A reel strip must contain at least one symbol.",
                    nameof(symbols)
                );
            }
        }

        public SymbolId GetSymbol(int position)
        {
            int wrappedPosition = position % symbols.Length;

            if (wrappedPosition < 0)
            {
                wrappedPosition += symbols.Length;
            }

            return symbols[wrappedPosition];
        }
    }
}