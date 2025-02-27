using UnityEngine;

namespace MenuComponents
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _mainMusic;

        public bool IsMusicActive { get; private set; } = true;
        public bool IsSoundActive { get; private set; } = true;

        public void SwitchMusicOn()
        {
            _mainMusic.UnPause();
            IsMusicActive = true;
        }

        public void SwitchMusicOff()
        {
            _mainMusic.Pause();
            IsMusicActive = false;
        }

        public void SwitchSoundOn()
        {
            IsSoundActive = true;
        }

        public void SwitchSoundOff()
        {
            IsSoundActive = false;
        }
    }
}