using Arcanarchy.Core;
using UnityEngine;

namespace Arcanarchy.Presentation
{
    public sealed class ReelGridView : MonoBehaviour
    {
        [SerializeField] private SymbolView symbolPrefab;

        [Header("Layout")]
        [SerializeField] private float symbolWidth = 210f;
        [SerializeField] private float symbolHeight = 180f;
        [SerializeField] private float horizontalGap = 20f;
        [SerializeField] private float verticalGap = 20f;

        private SymbolView[,] symbolViews;

        public void Display(SpinResult result)
        {
            EnsureGridExists(result.ReelCount, result.RowCount);

            for (int reelIndex = 0;
                 reelIndex < result.ReelCount;
                 reelIndex++)
            {
                for (int rowIndex = 0;
                     rowIndex < result.RowCount;
                     rowIndex++)
                {
                    SymbolId symbol =
                        result.GetSymbol(reelIndex, rowIndex);

                    symbolViews[reelIndex, rowIndex].Display(symbol);
                }
            }
        }

        private void EnsureGridExists(int reelCount, int rowCount)
        {
            if (symbolViews != null)
            {
                return;
            }

            symbolViews = new SymbolView[reelCount, rowCount];

            float gridWidth =
                (reelCount * symbolWidth) +
                ((reelCount - 1) * horizontalGap);

            float gridHeight =
                (rowCount * symbolHeight) +
                ((rowCount - 1) * verticalGap);

            float leftEdge =
                -(gridWidth * 0.5f) + (symbolWidth * 0.5f);

            float topEdge =
                (gridHeight * 0.5f) - (symbolHeight * 0.5f);

            for (int reelIndex = 0;
                 reelIndex < reelCount;
                 reelIndex++)
            {
                for (int rowIndex = 0;
                     rowIndex < rowCount;
                     rowIndex++)
                {
                    SymbolView view = Instantiate(
                        symbolPrefab,
                        transform
                    );

                    RectTransform rectTransform =
                        view.GetComponent<RectTransform>();

                    rectTransform.anchoredPosition = new Vector2(
                        leftEdge +
                            reelIndex *
                            (symbolWidth + horizontalGap),

                        topEdge -
                            rowIndex *
                            (symbolHeight + verticalGap)
                    );

                    rectTransform.sizeDelta =
                        new Vector2(symbolWidth, symbolHeight);

                    symbolViews[reelIndex, rowIndex] = view;
                }
            }
        }
    }
}