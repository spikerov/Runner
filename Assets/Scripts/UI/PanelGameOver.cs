using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PanelGameOver : UIManager
{
    private TMP_Text _collectedСoins;
    private TMP_Text _bestСollection;

    private void Start()
    {
 //       _collectedСoins = _score;
//        _bestСollection = _bestScore;
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
