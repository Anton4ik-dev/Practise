using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopChanger : MonoBehaviour
{
    [SerializeField] private List<Button> _items;
    [SerializeField] private List<TextMeshProUGUI> _costsText;
    [SerializeField] private List<float> _costs;
    [SerializeField] private List<Sprite> _skins;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Image _planktonImage;

    private ScoreChanger _scoreChanger;
    private RageChanger _rageChanger;

    [Inject]
    public void Construct(ScoreChanger scoreChanger, RageChanger rageChanger)
    {
        _scoreChanger = scoreChanger;
        _rageChanger = rageChanger;
    }

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            int index = i;
            _items[i].onClick.AddListener(() => ChangeScore(index));
            _costsText[i].text = $"{_costs[index]}";
        }
        _backButton.onClick.AddListener(FromShop);
        _shopButton.onClick.AddListener(ToShop);
    }

    public void ChangeScore(int index)
    {
        if(float.Parse(_scoreChanger.Score.text) >= _costs[index])
        {
            _scoreChanger.Score.text = $"{float.Parse(_scoreChanger.Score.text) - _costs[index]}";
            _planktonImage.sprite = _skins[index];
            _items[index].interactable = false;
            _items[index].onClick.RemoveAllListeners();
            if(index == 0)
            {
                _scoreChanger.ScoreBonus = 1;
                _rageChanger.RageChance++;
            }
            else if(index == 1)
            {
                _scoreChanger.ScoreBonus++;
                _rageChanger.RageChance = 1;
            }
        }
    }

    public void ToShop()
    {
        _shopPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void FromShop()
    {
        _shopPanel.SetActive(false);
        Time.timeScale = 1;
    }
}