using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScore;

    private const string _bestScoreKey = "Best Score";

    private void Start()
    {
        _bestScore.text = PlayerPrefs.GetInt(_bestScoreKey).ToString();
    }

    public void OnClickButtonStart()
    {
        SceneManager.LoadScene(2);
    }
}
