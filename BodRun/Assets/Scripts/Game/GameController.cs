using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject player;
    public TextMeshProUGUI scoreText;
    public GameObject resumePanel;

    Player p;

    private void Start()
    {
        PlayerPrefs.SetFloat("Acceleration", 1);
    }

    private void Update()
    {
        p = player.GetComponent<Player>();

        scoreText.text = "SCORE: " + p.score.ToString();

        if (!p.hp)
        {
            gameOverPanel.gameObject.SetActive(true);
        }
        if(Time.timeScale == 0 && p.hp)
        {
            resumePanel.gameObject.SetActive(true);
        }
    }

}
