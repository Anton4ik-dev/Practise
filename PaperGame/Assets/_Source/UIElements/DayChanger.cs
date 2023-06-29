using DataFactories;
using Document;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DayChanger : MonoBehaviour
{
    [SerializeField] private Slider _daySlider;
    [SerializeField] private TextMeshProUGUI _day;

    private Swiper _swiper;
    private ScoreChanger _scoreChanger;
    private RageChanger _rageChanger;
    private DateFactory _dateFactory;

    [Inject]
    public void Construct(Swiper swiper, ScoreChanger scoreChanger, RageChanger rageChanger, DateFactory dateFactory)
    {
        _swiper = swiper;
        _scoreChanger = scoreChanger;
        _rageChanger = rageChanger;
        _dateFactory = dateFactory;
        StartNewDay();
    }

    private void StartNewDay()
    {
        _day.text = $"{int.Parse(_day.text) + 1}";
        _daySlider.value = _daySlider.maxValue;
        _scoreChanger.ResetVariables();
        _rageChanger.ResetVariables();
        _dateFactory.ChangeDate();
        _swiper.SetDocument();
        StartCoroutine(DayTimer());
    }

    private IEnumerator DayTimer()
    {
        while(_daySlider.value != _daySlider.minValue)
        {
            _daySlider.value--;
            yield return new WaitForSeconds(1f);
        }
        StartNewDay();
    }
}