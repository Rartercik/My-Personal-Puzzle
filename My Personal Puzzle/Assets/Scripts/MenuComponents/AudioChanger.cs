using UnityEngine;

namespace MenuComponents
{
    public class AudioChanger : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private GameObject _activeMusicButton;
        [SerializeField] private GameObject _inactiveMusicButton;
        [SerializeField] private GameObject _activeSoundButton;
        [SerializeField] private GameObject _inactiveSoundButton;

        public void UpdateButtons()
        {
            UpdateMusicButtons();
            UpdateSoundButtons();
        }

        public void SwitchMusicOn()
        {
            _audioManager.SwitchMusicOn();
            UpdateMusicButtons();
        }

        public void SwitchMusicOff()
        {
            _audioManager.SwitchMusicOff();
            UpdateMusicButtons();
        }

        public void SwitchSoundOn()
        {
            _audioManager.SwitchSoundOn();
            UpdateSoundButtons();
        }

        public void SwitchSoundOff()
        {
            _audioManager.SwitchSoundOff();
            UpdateSoundButtons();
        }

        private void UpdateMusicButtons()
        {
            if (_audioManager.IsMusicActive)
            {
                _activeMusicButton.SetActive(true);
                _inactiveMusicButton.SetActive(false);
            }
            else
            {
                _activeMusicButton.SetActive(false);
                _inactiveMusicButton.SetActive(true);
            }
        }

        private void UpdateSoundButtons()
        {
            if (_audioManager.IsSoundActive)
            {
                _activeSoundButton.SetActive(true);
                _inactiveSoundButton.SetActive(false);
            }
            else
            {
                _activeSoundButton.SetActive(false);
                _inactiveSoundButton.SetActive(true);
            }
        }
    }
}