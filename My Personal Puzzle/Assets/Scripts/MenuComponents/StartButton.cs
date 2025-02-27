using UnityEngine;
using TMPro;

namespace MenuComponents
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _unavailabilityText;
        [SerializeField] private GameObject _availabilityButton;
        [SerializeField] private GameObject _unavailabilityButton;
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private string _textBeforeCost;
        [SerializeField] private float _cost;

        private bool _isAvailable;

        private void OnValidate()
        {
            if (_cost < 0)
            {
                _cost = 0;
            }

            SetAvailability();
        }

        private void Start()
        {
            SetAvailability();
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void Click()
        {
            if (_isAvailable == false)
            {
                SetAvailable();
            }
            else
            {
                _gameInitializer.OpenGameWindow();
            }
        }

        private void SetAvailability()
        {
            if (_cost == 0)
            {
                SetAvailable();
            }
            else
            {
                SetUnavailable();
            }
        }

        private void SetAvailable()
        {
            _availabilityButton.SetActive(true);
            _unavailabilityButton.SetActive(false);
            _isAvailable = true;
        }

        private void SetUnavailable()
        {
            _unavailabilityText.text = _textBeforeCost + _cost;
            _availabilityButton.SetActive(false);
            _unavailabilityButton.SetActive(true);
            _isAvailable = false;
        }
    }
}
