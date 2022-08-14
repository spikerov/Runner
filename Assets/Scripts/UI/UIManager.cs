using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected TMP_Text _score;
    [SerializeField] protected TMP_Text _bestScore;
    [SerializeField] protected PanelGameOver _panelGameOver;

    private void OnEnable()
    {
        ScoreManager.ScoreChanged += UpdateScoreText;
        ScoreManager.BestScoreChanged += UpdateBestScoreText;
        Rock.OnRock += OnGameOver;
    }

    private void OnDisable()
    {
        ScoreManager.ScoreChanged -= UpdateScoreText;
        ScoreManager.BestScoreChanged -= UpdateBestScoreText;
        Rock.OnRock -= OnGameOver;
    }

    public void UpdateScoreText(int score)
    {
        _score.text = score.ToString(); 
    }

    public void UpdateBestScoreText(int bestScore)
    {
        _bestScore.text = bestScore.ToString();
    }

    private void OnGameOver()
    {
        _panelGameOver.gameObject.SetActive(true);
    }
}
