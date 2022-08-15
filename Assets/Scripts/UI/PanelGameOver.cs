using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PanelGameOver : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private TMP_Text _collectedСoins;
    [SerializeField] private TMP_Text _bestСollection;

    private void Start()
    {
        _collectedСoins.text = _scoreManager.Score.ToString();
        _bestСollection.text = _scoreManager.BestScore.ToString();
        _soundManager.StopBackroundSound();
        _soundManager.PlayLose();
    }

    public void OnButtonClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void OnButtonClickHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
