using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _bestScore;

    private void OnEnable()
    {
        ScoreManager.ScoreChanged += UpdateScoreText;
        ScoreManager.BestScoreChanged += UpdateBestScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.ScoreChanged -= UpdateScoreText;
        ScoreManager.BestScoreChanged -= UpdateBestScoreText;


    }

    public void UpdateScoreText(int score)
    {
        _score.text = score.ToString(); 
    }

    public void UpdateBestScoreText(int bestScore)
    {
        _bestScore.text = bestScore.ToString();
    }
}
