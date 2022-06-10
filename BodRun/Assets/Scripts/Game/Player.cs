using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool hp=true;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (hp)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + 1.5f, 0f, 3f));
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - 1.5f, 0f, 3f));
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

    }
    private void SpeedUp()
    {

    }
}
