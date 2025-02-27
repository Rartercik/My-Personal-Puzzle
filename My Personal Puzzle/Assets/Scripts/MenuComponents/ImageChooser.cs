using UnityEngine;
using UnityEngine.UI;

namespace MenuComponents
{
    public class ImageChooser : MonoBehaviour
    {
        [SerializeField] private Image _imageShower;
        [SerializeField] private Sprite[] _availableImages;
        [SerializeField] private int _selectedIndex;

        public Sprite ChosenImage { get; private set; }

        private void OnValidate()
        {
            if (_availableImages == null || _availableImages.Length == 0) return;

            ChooseSprite(ref _selectedIndex, false);
        }

        public void ChoosePrevious()
        {
            _selectedIndex--;
            ChooseSprite(ref _selectedIndex);
        }

        public void ChooseNext()
        {
            _selectedIndex++;
            ChooseSprite(ref _selectedIndex);
        }

        private void ChooseSprite(ref int sourceIndex, bool cycling = true)
        {
            sourceIndex = GetValidIndex(sourceIndex, _availableImages.Length, cycling);
            ChosenImage = _availableImages[sourceIndex];
            _imageShower.sprite = ChosenImage;
        }

        private int GetValidIndex(int sourceIndex, int sourceLength, bool cycling = true)
        {
            if (sourceIndex < 0) sourceIndex = cycling ? sourceLength - 1 : 0;
            if (sourceIndex >= sourceLength) sourceIndex = cycling ? 0 : sourceLength - 1;

            return sourceIndex;
        }
    }
}
