using UnityEngine;
using TMPro;

namespace GameComponents
{
    public class TimeCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _firstLine;
        [SerializeField] private string _textAfterTime;

        private float _time;
        private int _previousTime;
        private bool _isStopped = true;

        private void Update()
        {
            if (_isStopped) return;

            _time += Time.deltaTime;
            var time = (int)_time;
            if (time <= _previousTime) return;

            UpdateText(time);
            _previousTime = time;
        }

        public void TurnOn()
        {
            _isStopped = false;
        }

        public void Stop()
        {
            _isStopped = true;
        }

        public string GetText()
        {
            return _text.text;
        }

        public int GetTime()
        {
            return (int)_time;
        }

        public void ResetTimer()
        {
            _time = 0f;
            _previousTime = 0;
            UpdateText(0);
            Stop();
        }

        private void UpdateText(int time)
        {
            _text.text = _firstLine + '\n' + time + _textAfterTime;
        }
    }
}
