using ScriptableObjects;
using System;
using TMPro;
using Random = UnityEngine.Random;

namespace DataFactories
{
    public class DateFactory
    {
        private const int ONE_YEAR = 365;
        private int _dateRange;
        private DateTime _date;
        private DateSO _dateSO;
        private bool _canBeWithMistake = false;

        public DateFactory(DateSO dateSO)
        {
            _dateSO = dateSO;
            _dateRange = _dateSO.HowMuchYears * ONE_YEAR;
        }

        public bool CreateDate(TextMeshProUGUI dateText, bool isError = false)
        {
            DateTime newDate = _date;
            if (isError == true && _canBeWithMistake == true)
            {
                newDate = _date.AddDays(Random.Range(0, _dateRange));
                dateText.text = $"{newDate.Day}.{newDate.Month}.{newDate.Year}";
                return false;
            }
            dateText.text = $"{newDate.Day}.{newDate.Month}.{newDate.Year}";
            return true;
        }

        public string WriteMessage()
        {
            _date = _dateSO.Date;
            return $"{_date.Day}.{_date.Month}.{_date.Year}";
        }

        public void SetMistake()
        {
            _canBeWithMistake = true;
        }

        public void ResetMistake()
        {
            _canBeWithMistake = false;
        }
    }
}