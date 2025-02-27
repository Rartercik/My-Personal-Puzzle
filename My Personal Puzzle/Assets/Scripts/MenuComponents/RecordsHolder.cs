using System;
using UnityEngine;
using TMPro;

namespace MenuComponents
{
    public class RecordsHolder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI[] _recordTexts;

        private int[] _records;

        private void Start ()
        {
            _records = new int[_recordTexts.Length];
            Array.Fill(_records, int.MaxValue);
        }

        public void TryUpdateRecord(int mode, int result)
        {
            if (result < _records[mode])
            {
                _records[mode] = result;
                _recordTexts[mode].text = result.ToString();
            }
        }
    }
}
