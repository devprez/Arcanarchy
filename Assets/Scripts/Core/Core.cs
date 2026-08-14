namespace Arcanarchy.Core
{
    public enum SymbolId
    {
        Fool,
        Magician,
        HighPriestess,
        Empress,
        Emperor,
        Star,
        Wild
    }

       public interface IRandomSource
    {
        int Next(int minimumInclusive, int maximumExclusive);
    }
}