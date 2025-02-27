using UnityEngine;
using TMPro;
using GameComponents;

namespace MenuComponents
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Canvas _gameWindow;
        [SerializeField] private Game _game;
        [SerializeField] private ModeChanger _modeChanger;
        [SerializeField] private ImageChooser _imageChooser;

        public void OpenGameWindow()
        {
            _gameWindow.enabled = true;
        }

        public void StartGame()
        {
            _game.StartGame(_modeChanger.Mode, _imageChooser.ChosenImage);
        }

        public void CloseGameWindow()
        {
            _gameWindow.enabled = false;
        }
    }
}
