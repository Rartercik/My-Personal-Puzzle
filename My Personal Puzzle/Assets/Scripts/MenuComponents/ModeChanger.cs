using UnityEngine;
using TMPro;

namespace MenuComponents
{
    public class ModeChanger : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _modes;
        [SerializeField] private StartButton[] _startButtons;
        [field: SerializeField] public int Mode { get; private set; }

        private void OnValidate()
        {
            if (Mode < 0) Mode = 0;
            if (Mode >= _modes.Length) Mode = _modes.Length - 1;

            for (int i = 0; i < _modes.Length; i++)
            {
                _modes[i].gameObject.SetActive(i == Mode);
                _startButtons[i].SetActive(i == Mode);
            }
        }

        private void Start()
        {
            _modes[Mode].gameObject.SetActive(true);
        }

        public void ChooseNext()
        {
            _modes[Mode].gameObject.SetActive(false);
            _startButtons[Mode].SetActive(false);

            Mode++;
            if (Mode >= _modes.Length)
            {
                Mode = 0;
            }

            _modes[Mode].gameObject.SetActive(true);
            _startButtons[Mode].SetActive(true);
        }

        public void ChoosePrevious()
        {
            _modes[Mode].gameObject.SetActive(false);
            _startButtons[Mode].SetActive(false);

            Mode--;
            if (Mode < 0)
            {
                Mode = _modes.Length - 1;
            }

            _modes[Mode].gameObject.SetActive(true);
            _startButtons[Mode].SetActive(true);
        }

        public string GetModeText()
        {
            return _modes[Mode].text;
        }
    }
}
