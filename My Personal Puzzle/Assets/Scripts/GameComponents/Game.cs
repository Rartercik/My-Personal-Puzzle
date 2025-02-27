using UnityEngine;
using TMPro;
using MenuComponents;

namespace GameComponents
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Canvas _pause;
        [SerializeField] private Canvas _victory;
        [SerializeField] private TextMeshProUGUI _victoryTime;
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private RecordsHolder _recordsHolder;
        [SerializeField] private TimeCounter _timeCounter;
        [SerializeField] private Mode[] _modes;
        [SerializeField] private VictoryModeShower[] _victoryModeShowers;

        private int _mode;

        public void StartGame(int mode, Sprite chosenImage)
        {
            _mode = mode;
            _modes[_mode].TurnOn(chosenImage);
            _timeCounter.TurnOn();
            _canvas.enabled = true;
        }

        public void Pause()
        {
            _timeCounter.Stop();
            _pause.enabled = true;
        }

        public void Unpause()
        {
            _timeCounter.TurnOn();
            _pause.enabled = false;
        }

        public void HandleVictory()
        {
            _recordsHolder.TryUpdateRecord(_mode, _timeCounter.GetTime());
            _victoryTime.text = _timeCounter.GetText();
            _victoryModeShowers[_mode].Show();
            _victory.enabled = true;
        }

        public void GoHome()
        {
            ResetGame();
            _gameInitializer.CloseGameWindow();
        }

        public void ResetGame()
        {
            _victoryModeShowers[_mode].Hide();
            _modes[_mode].ResetMode();
            _timeCounter.ResetTimer();
            _pause.enabled = false;
            _canvas.enabled = false;
            _victory.enabled = false;
        }
    }
}
