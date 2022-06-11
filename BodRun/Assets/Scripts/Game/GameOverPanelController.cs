using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    private void Update()
    {
        float bestScore = PlayerPrefs.GetFloat("BestScore");
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
