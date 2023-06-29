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
        private TextMeshProUGUI _dateClocks;

        public DateFactory(DateSO dateSO, TextMeshProUGUI dateClocks)
        {
            _dateSO = dateSO;
            _dateClocks = dateClocks;
            _dateRange = _dateSO.HowMuchYears * ONE_YEAR;
            ChangeDate();
        }

        public void CreateDate(TextMeshProUGUI dateText, bool isError = false)
        {
            DateTime newDate = _date;
            if (isError)
            {
                switch (Random.Range(0, 2))
                {
                    case 0:
                        newDate = _date.AddDays(-Random.Range(0, _dateRange));
                        break;
                    case 1:
                        dateText.text = "";
                        return;
                }
            }
            dateText.text = $"{newDate.Day}.{newDate.Month}.{newDate.Year}";
        }

        public void ChangeDate()
        {
            _date = _dateSO.Date;
            _dateClocks.text = $"{_date.Day}.{_date.Month}.{_date.Year}";
        }
    }
}