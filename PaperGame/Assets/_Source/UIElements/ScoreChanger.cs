using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreChanger : MonoBehaviour
{
    public TextMeshProUGUI Score;
    [SerializeField] private List<GameObject> _hearts;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private Button _restartButton;
    [SerializeField] private float _scoreChangeAmount;
    [SerializeField] private float _streakStep;

    private int _streak = 0;
    private float _streakBonus = 1;
    private int _mistakes = 0;

    public int ScoreBonus = 1;

    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    public void ChangeScore(bool isRight)
    {
        if(isRight)
        {
            Score.text = $"{float.Parse(Score.text) + _scoreChangeAmount * _streakBonus * ScoreBonus}";
            if(_streak < 5)
            {
                _streak++;
                _streakBonus += _streakStep;
            }
            return;
        }
        RemoveHealth();
        ResetVariables();
    }

    public void ResetVariables()
    {
        _streak = 0;
        _streakBonus = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        _restartButton.onClick.RemoveAllListeners();
    }

    private void RemoveHealth()
    {
        _hearts[_mistakes].SetActive(false);
        _mistakes++;
        if (_mistakes == _hearts.Count)
            _loseScreen.SetActive(true);
    }
}