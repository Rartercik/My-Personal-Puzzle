using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace GameComponents
{
    public class ImagePart : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _transform;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _contentBar;
        [SerializeField] private Image _targetImage;

        [field: SerializeField] public int MatchIndex { get; private set; }

        private Mode _mode;
        private RectTransform _modeHolder;
        private ImagePartHolder _holder;
        private State _state = State.InBar;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            _state = State.None;
            TrySubtractMatch();

            var previousPosition = _transform.position;
            _transform.SetParent(_modeHolder);
            _transform.SetAsLastSibling();

            _transform.anchorMin = new Vector2(0.5f, 0.5f);
            _transform.anchorMax = new Vector2(0.5f, 0.5f);
            _transform.position = previousPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _transform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent<ImagePart>(out var other) == false) return;

            if (_state == State.InBar)
            {
                other.SetIntoBar();
            }
            else if (_holder != null && other._holder != null)
            {
                var holder = _holder;
                TrySubtractMatch();
                SetHolder(other._holder);
                other.SetHolder(holder);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            if (_state != State.Holded)
            {
                _holder = null;
            }
        }

        public void Initialize(Mode mode, RectTransform modeHolder, Sprite sprite)
        {
            _mode = mode;
            _modeHolder = modeHolder;
            _targetImage.sprite = sprite;
            _holder = null;
            _canvasGroup.blocksRaycasts = true;
            SetIntoBar();
        }

        public void SetHolder(ImagePartHolder holder)
        {
            _transform.anchoredPosition = holder.RectTransform.anchoredPosition;
            _holder = holder;
            _state = State.Holded;

            TryAddMatch();
        }

        public void SetIntoBar()
        {
            _state = State.InBar;

            Vector2 localPoint;
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(null, _transform.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_contentBar, screenPoint, null, out localPoint);
            var childIndex = Mathf.RoundToInt((localPoint.x + _contentBar.rect.width / 2f) / _transform.rect.width);

            _transform.SetParent(_contentBar);
            _transform.SetSiblingIndex(childIndex);
        }

        private void TryAddMatch()
        {
            if (_holder != null && MatchIndex == _holder.MatchIndex)
            {
                _mode.AddMatch();
            }
        }

        private void TrySubtractMatch()
        {
            if (_holder != null && MatchIndex == _holder.MatchIndex)
            {
                _mode.SubtractMatch();
            }
        }

        private enum State
        {
            None,
            Holded,
            InBar
        }    
    }
}
