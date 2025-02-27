using UnityEngine;
using UnityEngine.EventSystems;

namespace GameComponents
{
    public class ImagePartHolder : MonoBehaviour, IDropHandler
    {
        [field: SerializeField] public RectTransform RectTransform {  get; private set; }
        [field: SerializeField] public int MatchIndex { get; private set; }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent<ImagePart>(out var part))
            {
                part.SetHolder(this);
            }
        }
    }
}
