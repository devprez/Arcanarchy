using Arcanarchy.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arcanarchy.Presentation
{
    public sealed class SymbolView : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private TMP_Text symbolLabel;

        public void Display(SymbolId symbol)
        {
            symbolLabel.text = FormatLabel(symbol);
            backgroundImage.color = GetSymbolColor(symbol);
        }

        private static string FormatLabel(SymbolId symbol)
        {
            return symbol switch
            {
                SymbolId.HighPriestess => "HIGH\nPRIESTESS",
                _ => symbol.ToString().ToUpperInvariant()
            };
        }

        private static Color GetSymbolColor(SymbolId symbol)
        {
            return symbol switch
            {
                SymbolId.Fool =>
                    new Color(1f, 0f, 0.75f),

                SymbolId.Magician =>
                    new Color(0.55f, 0.1f, 0.8f),

                SymbolId.HighPriestess =>
                    new Color(0.05f, 0.15f, 0.65f),

                SymbolId.Empress =>
                    new Color(0.85f, 0.1f, 0.25f),

                SymbolId.Emperor =>
                    new Color(1f, 0.35f, 0.05f),

                SymbolId.Star =>
                    new Color(0f, 0.8f, 1f),

                SymbolId.Wild =>
                    new Color(1f, 0.85f, 0f),

                _ => Color.gray
            };
        }
    }
}