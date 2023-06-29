using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "DateSO", menuName = "SO/Date", order = 0)]
    public class DateSO : ScriptableObject
    {
        [SerializeField] private int _howMuchYears;
        [SerializeField] private int _minDay;
        [SerializeField] private int _maxDay;
        [SerializeField] private int _minMonth;
        [SerializeField] private int _maxMonth;
        [SerializeField] private int _minYear;
        [SerializeField] private int _maxYear;

        public DateTime Date { get => new DateTime(Random.Range(_minYear, _maxYear),
            Random.Range(_minMonth, _maxMonth),
            Random.Range(_minDay, _maxDay));
            private set { } }
        public int HowMuchYears { get => _howMuchYears; private set { } }
    }
}