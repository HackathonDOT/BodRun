using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.5f;
    [SerializeField]
    public float acceleration = 1;
    
    Player p;

    void Start()
    {
        p = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(trapMove());
    }

    private void Update()
    {
        acceleration = PlayerPrefs.GetFloat("Acceleration");
    }

    private IEnumerator trapMove()
    {
        while(p.hp)
        {
            Vector2 v = transform.position;
            v += Vector2.left;
            transform.position = Vector2.Lerp(transform.position, v, 0.2f);
            yield return new WaitForSeconds(1 / (speed * acceleration));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
