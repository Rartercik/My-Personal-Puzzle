using UnityEngine;
using UnityEngine.UI;

namespace MenuComponents
{
    public class VictoryModeShower : MonoBehaviour
    {
        [SerializeField] private ImageChooser _imageChooser;
        [SerializeField] private Image[] _targets;

        public void Show()
        {
            gameObject.SetActive(true);
            foreach (var target in _targets)
            {
                target.sprite = _imageChooser.ChosenImage;
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
