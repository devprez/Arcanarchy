using System.Text;
using Arcanarchy.Core;
using UnityEngine;
using Arcanarchy.Presentation;

namespace Arcanarchy.Debugging
{
    public sealed class SlotMathTester : MonoBehaviour
    {
        [SerializeField] private int seed = 12345;
        [SerializeField] private ReelGridView reelGridView;

        private SlotMathEngine engine;

        private void Start()
        {
            ReelStrip[] reels = CreateReelStrips();

            var randomSource = new SeededRandomSource(seed);

            engine = new SlotMathEngine(
                reels,
                rowCount: 3,
                randomSource
            );

            Spin();
        }

        public void Spin()
        {
            SpinResult result = engine.Spin();

            reelGridView.Display(result);

            UnityEngine.Debug.Log(FormatResult(result));
        }

        private static ReelStrip[] CreateReelStrips()
        {
            SymbolId[] temporaryStrip =
            {
                SymbolId.Fool,
                SymbolId.Magician,
                SymbolId.Fool,
                SymbolId.HighPriestess,
                SymbolId.Empress,
                SymbolId.Fool,
                SymbolId.Emperor,
                SymbolId.Star,
                SymbolId.Magician,
                SymbolId.Wild
            };

            return new[]
            {
                new ReelStrip(temporaryStrip),
                new ReelStrip(temporaryStrip),
                new ReelStrip(temporaryStrip),
                new ReelStrip(temporaryStrip),
                new ReelStrip(temporaryStrip)
            };
        }

        private static string FormatResult(SpinResult result)
        {
            var builder = new StringBuilder();

            builder.AppendLine("ARCANARCHY SPIN RESULT");

            for (int rowIndex = 0;
                 rowIndex < result.RowCount;
                 rowIndex++)
            {
                for (int reelIndex = 0;
                     reelIndex < result.ReelCount;
                     reelIndex++)
                {
                    SymbolId symbol =
                        result.GetSymbol(reelIndex, rowIndex);

                    builder.Append($"{symbol,-16}");
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}