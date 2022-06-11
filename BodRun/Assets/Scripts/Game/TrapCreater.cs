
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreater : MonoBehaviour
{
    public GameObject prefabTrap;
    GameObject trap;
    public Sprite[] fishSprites;

    public readonly float roMaxT = 5;
    public readonly float roMinT = 3;
    public float startPos;
    private float maxTime;
    private float minTime;
    private float time;

    private float spawnTime;

    void Start()
    {
        PlayerPrefs.SetFloat("SpawnTime", 0);
        startPos = transform.position.y;
        maxTime = roMaxT;
        minTime = roMinT;
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        
        if (time >= spawnTime)
        {
            SpawnObject();
            SetRandomTime();
        }
    }

    void SpawnObject()
    {
        time = 0;
        trap = Instantiate(prefabTrap, transform.position, prefabTrap.transform.rotation);
        trap.transform.GetComponent<SpriteRenderer>().sprite = fishSprites[Random.Range(0, fishSprites.Length)];
        SetTimeInterval();
    }

    void SetRandomTime()
    {
        /*float oldSpawnTime = PlayerPrefs.GetFloat("SpawnTime");
        float distance = 2 / PlayerPrefs.GetFloat("Acceleration");
        do
        {
            spawnTime = Random.Range(minTime, maxTime);
        } while (Mathf.Abs(oldSpawnTime - spawnTime) <= distance);
        PlayerPrefs.SetFloat("SpawnTime", spawnTime);
        */

        if (startPos == 0)
        {
            spawnTime = Random.Range(minTime, maxTime);
        }
        else if (startPos == 1.5)
        {
            spawnTime = Random.Range(minTime + 2, maxTime + 2);
        }
        else if (startPos == 3)
        {
            spawnTime = Random.Range(minTime + 3, maxTime + 3);
        }
    }

    void SetTimeInterval()
    {
        maxTime = roMaxT / trap.GetComponent<Trap>().acceleration;
        minTime = roMinT / trap.GetComponent<Trap>().acceleration;
    }

}
