using UnityEngine;
using UnityEngine.EventSystems;

namespace GameComponents
{
    public class ImagePartsBar : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent<ImagePart>(out var part))
            {
                part.SetIntoBar();
            }
        }
    }
}
