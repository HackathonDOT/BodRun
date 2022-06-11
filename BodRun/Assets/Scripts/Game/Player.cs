using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hp = true;
    public float score;

    void Start()
    {
        transform.position = new Vector3(0, 0);

        //PlayerPrefs.SetFloat("BestScore", 0);
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (hp && Time.timeScale == 1)
        {
            ScoreCounter();
            BestScoreCalculater();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + 1.5f, 0f, 3f));
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - 1.5f, 0f, 3f));
            }
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trap"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        hp = false;
        Time.timeScale = 0;
    }

    private void ScoreCounter()
    {
        float acceleration = PlayerPrefs.GetFloat("Acceleration");
        score += 1;
        acceleration += 0.00005f;
        PlayerPrefs.SetFloat("Acceleration", acceleration);

    }
    private void BestScoreCalculater()
    {
        float oldScore = PlayerPrefs.GetFloat("BestScore");
        if (oldScore < score)
        {
            PlayerPrefs.SetFloat("BestScore", score);
        }
    }
}
