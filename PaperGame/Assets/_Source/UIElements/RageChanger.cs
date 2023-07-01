using Document;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class RageChanger : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Slider _rageSlider;

    private bool _isRaged;
    private Swiper _swiper;

    public int RageChance = 1;

    [Inject]
    public void Construct(Swiper swiper)
    {
        _swiper = swiper;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_isRaged)
        {
            _rageSlider.value--;
            if(_rageSlider.value == _rageSlider.minValue)
            {
                _isRaged = false;
                _swiper.enabled = true;
            }
        }
    }

    public void AddRage()
    {
        switch (Random.Range(0, RageChance))
        {
            case 0:
                _rageSlider.value++;
                break;
            case 1:
                break;
        }
        if(_rageSlider.value == _rageSlider.maxValue)
        {
            _isRaged = true;
            _swiper.enabled = false;
        }
    }

    public void ResetVariables()
    {
        _isRaged = false;
        _swiper.enabled = true;
        _rageSlider.value = _rageSlider.minValue;
    }
}