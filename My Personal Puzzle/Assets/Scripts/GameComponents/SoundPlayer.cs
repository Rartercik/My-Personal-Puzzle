using UnityEngine;
using MenuComponents;

namespace GameComponents
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioSource _sound;

        public void TryPlay()
        {
            if (_audioManager.IsSoundActive)
            {
                _sound.Play();
            }
        }
    }
}
