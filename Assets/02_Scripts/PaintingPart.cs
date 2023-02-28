using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PaintingGame
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PaintingPart : MonoBehaviour, IPaintable, IPointerClickHandler
    {
        private enum PaintableState
        {
            Default,
            Marked,
            Painted
        }

        [SerializeField] private Color color;
        private SpriteRenderer _spriteRenderer;
        private PaintableState _state = PaintableState.Default;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            PaintManager.OnPaintSelected += OnPaintSelected;
        }

        private void OnDisable()
        {
            PaintManager.OnPaintSelected -= OnPaintSelected;
        }

        private void OnPaintSelected(Paint paint)
        {
            if (_state == PaintableState.Painted) //already painted
            {
                return;
            }

            if (((Color32)color).Equals((Color32)paint.Color))
            {
                Mark();
            }
            else
            {
                Delete();
            }
        }

        public void Mark()
        {
            if (_state != PaintableState.Default) return;

            _spriteRenderer.color = new Color(1, 1, 1, 175f / 255);
            _state = PaintableState.Marked;

            Debug.Log("Mark: " + name);
        }

        public void Paint()
        {
            if (_state != PaintableState.Marked) return;

            // _spriteRenderer.color = color;
            _spriteRenderer.DOColor(color, 0.5f);
            _state = PaintableState.Painted;


            Debug.Log("Paint: " + name);
        }

        public void Delete()
        {
            if (_state != PaintableState.Marked) return;

            _spriteRenderer.color = Color.white;
            _state = PaintableState.Default;

            Debug.Log("Delete: " + name);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Paint();
        }
    }
}