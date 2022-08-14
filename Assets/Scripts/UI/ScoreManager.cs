using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    private int _bestScore;

    private const string _bestScoreKey = "Best Score";

    public static UnityAction<int> ScoreChanged;
    public static UnityAction<int> BestScoreChanged;

    private void OnEnable()
    {
        Coin.OnCoin += AddScore;
    }

    private void OnDisable()
    {
        Coin.OnCoin -= AddScore;
    }

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(_bestScoreKey, 0);

        Debug.Log(_bestScore);
    }

    private void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);

        if (_score > _bestScore)
        {
            _bestScore = _score;
            BestScoreChanged?.Invoke(_bestScore);
            NewBestScore();
        }
    }

    private void NewBestScore()
    {
        PlayerPrefs.SetInt(_bestScoreKey, _bestScore);
    }
}
