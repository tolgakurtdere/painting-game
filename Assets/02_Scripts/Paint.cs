using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PaintingGame
{
    public class Paint : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Color color;

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetComponent<Image>().color = color;
        }
#endif

        public void OnPointerClick(PointerEventData eventData)
        {
            PaintManager.Instance.TryToSelect(this);
        }

        public void Select()
        {
            transform.localScale = Vector3.one * 1.25f;
        }

        public void Deselect()
        {
            transform.localScale = Vector3.one;
        }
    }
}