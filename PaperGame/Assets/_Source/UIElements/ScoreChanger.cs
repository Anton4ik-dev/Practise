using TMPro;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private float _scoreChangeAmount;
    [SerializeField] private float _streakStep;

    private int _streak = 0;
    private float _streakBonus = 1;

    public void ChangeScore(bool isRight)
    {
        if(isRight)
        {
            _score.text = $"{float.Parse(_score.text) + _scoreChangeAmount * _streakBonus}";
            if(_streak < 5)
            {
                _streak++;
                _streakBonus += _streakStep;
            }
            return;
        }
        ResetVariables();
    }

    public void ResetVariables()
    {
        _streak = 0;
        _streakBonus = 1;
    }
}