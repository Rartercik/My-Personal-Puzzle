using UnityEngine;

namespace GameComponents
{
    public class Mode : MonoBehaviour
    {
        [SerializeField] private Game _game;
        [SerializeField] private RectTransform _imagesHolder;
        [SerializeField] private GameObject _content;
        [SerializeField] private ImagePart[] _parts;

        private int _matchesCount;

        public void TurnOn(Sprite chosenImage)
        {
            gameObject.SetActive(true);
            _content.SetActive(true);
            foreach (var part in _parts)
            {
                part.Initialize(this, _imagesHolder, chosenImage);
            }
        }

        public void ResetMode()
        {
            gameObject.SetActive(false);
            _content.SetActive(false);
            _matchesCount = 0;
        }

        public void AddMatch()
        {
            _matchesCount++;
            if (_matchesCount > _parts.Length)
            {
                Debug.LogError("Incorrect match addition led to the next matches count: " + _matchesCount);
            }
            if (_matchesCount == _parts.Length)
            {
                _game.HandleVictory();
            }
        }

        public void SubtractMatch()
        {
            _matchesCount--;
            if (_matchesCount < 0)
            {
                Debug.LogError("Incorrect match subtraction led to the next matches count: " + _matchesCount);
            }
        }
    }
}
