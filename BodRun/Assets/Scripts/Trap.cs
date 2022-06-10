using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.5f;
    [SerializeField]
    public float acceleration = 1;
    [SerializeField]
    public int spawnTime = 2;
    public readonly float[] roads = { 0, 1.5f, 3 };
    Player p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(trapMove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void trapCreater()
    {

    }
    private IEnumerator trapMove()
    {
        while(p.hp)
        {
            Vector2 v=transform.position;
            v += Vector2.left;            
            transform.position = Vector2.Lerp(transform.position, v, 0.2f);
            yield return new WaitForSeconds(1 / speed * acceleration);
        }
        
    }
}
