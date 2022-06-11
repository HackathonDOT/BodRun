using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hp = true;
    public float score;

    public AudioSource completionAudio;
    public AudioSource movedAudio;

    void Start()
    {
        transform.position = new Vector3(0, 0);
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
                movedAudio.Play();
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + 1.5f, 0f, 3f));
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                movedAudio.Play();
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
        acceleration += 0.00005f;
        score += Mathf.Round(1 * acceleration);
        if(score % 1000 == 0)
        {
            completionAudio.Play();
        }
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
