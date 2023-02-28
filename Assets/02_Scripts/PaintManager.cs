using System;
using TK;
using UnityEngine;

namespace PaintingGame
{
    public class PaintManager : MonoSingleton<PaintManager>
    {
        public static event Action<Paint> OnPaintSelected;
        private Paint _currentPaint = null;

        public void TryToSelect(Paint paint)
        {
            if (_currentPaint == paint)
            {
                Debug.Log("Already selected! : " + paint.name);
                return;
            }

            _currentPaint?.Deselect();
            paint.Select();
            _currentPaint = paint;

            OnPaintSelected?.Invoke(paint);
        }
    }
}