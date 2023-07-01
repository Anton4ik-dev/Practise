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
    [SerializeField] private TextMeshProUGUI _options;

    private Swiper _swiper;
    private ScoreChanger _scoreChanger;
    private RageChanger _rageChanger;
    private DateFactory _dateFactory;
    private QualityFactory _qualityFactory;
    private MarkFactory _markFactory;
    private HeaderFactory _headerFactory;
    private int _dayNum = 1;

    [Inject]
    public void Construct(Swiper swiper, ScoreChanger scoreChanger, RageChanger rageChanger,
        DateFactory dateFactory, QualityFactory qualityFactory,
        MarkFactory markFactory, HeaderFactory headerFactory)
    {
        _swiper = swiper;
        _scoreChanger = scoreChanger;
        _rageChanger = rageChanger;
        _dateFactory = dateFactory;
        _qualityFactory = qualityFactory;
        _markFactory = markFactory;
        _headerFactory = headerFactory;
        StartNewDay();
    }

    private void StartNewDay()
    {
        ResetVariables();
        WriteCategories();
        _swiper.SetDocument();
        StartCoroutine(DayTimer());
    }

    private void ResetVariables()
    {
        _options.text = "";
        _day.text = $"{int.Parse(_day.text) + 1}";
        _daySlider.value = _daySlider.maxValue;
        _scoreChanger.ResetVariables();
        _rageChanger.ResetVariables();
        _dateFactory.ResetMistake();
        _qualityFactory.ResetMistake();
        _markFactory.ResetMistake();
        _headerFactory.ResetMistake();
        _dateFactory.WriteMessage();
    }

    private void WriteCategories()
    {
        if (_dayNum == 1)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    break;
                case 1:
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    break;
                case 2:
                    _options.text += _markFactory.WriteMessage() + "\n";
                    break;
                case 3:
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    break;
            }
        }
        else if (_dayNum == 2)
        {
            switch (Random.Range(0, 6))
            {
                case 0:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    break;
                case 1:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    break;
                case 2:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    _options.text += _markFactory.WriteMessage() + "\n";
                    break;
                case 3:
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    break;
                case 4:
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    _options.text += _markFactory.WriteMessage() + "\n";
                    break;
                case 5:
                    _options.text += _markFactory.WriteMessage() + "\n";
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    break;
            }
        }
        else if (_dayNum == 3)
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    _options.text += _markFactory.WriteMessage() + "\n";
                    break;
                case 1:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    break;
                case 2:
                    _options.text += _dateFactory.WriteMessage() + "\n";
                    _dateFactory.SetMistake();
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    _options.text += _markFactory.WriteMessage() + "\n";
                    break;
                case 3:
                    _options.text += _qualityFactory.WriteMessage() + "\n";
                    _options.text += _headerFactory.WriteMessage() + "\n";
                    _options.text += _markFactory.WriteMessage() + "\n";
                    break;
            }
        }
        else if (_dayNum == 4)
        {
            _options.text += _dateFactory.WriteMessage() + "\n";
            _dateFactory.SetMistake();
            _options.text += _qualityFactory.WriteMessage() + "\n";
            _options.text += _markFactory.WriteMessage() + "\n";
            _options.text += _headerFactory.WriteMessage() + "\n";
            _dayNum = 0;
        }
        _dayNum++;
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