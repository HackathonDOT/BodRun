
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreater : MonoBehaviour
{
    public GameObject prefabTrap;
    GameObject trap;

    public readonly float roMaxT = 6;
    public readonly float roMinT = 2;
    private float maxTime;
    private float minTime;
    private float time;

    private float spawnTime;

    void Start()
    {
        PlayerPrefs.SetFloat("SpawnTime", 0);
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
        
        SetTimeInterval();
    }

    void SetRandomTime()
    {
        float oldSpawnTime = PlayerPrefs.GetFloat("SpawnTime");
        float distance = 2 / PlayerPrefs.GetFloat("Acceleration");
        do
        {
            Debug.Log("aa");
            
            spawnTime = Random.Range(minTime, maxTime);
            Debug.Log("fff     " + Mathf.Abs(oldSpawnTime - spawnTime));
        } while (Mathf.Abs(oldSpawnTime - spawnTime) <= distance);
        PlayerPrefs.SetFloat("SpawnTime", spawnTime);
        Debug.Log("oldSpawnTime    " + oldSpawnTime);
        Debug.Log("distance   " + distance);
        Debug.Log("spawnTime    " + spawnTime);
        Debug.Log("heasap    " + Mathf.Abs(oldSpawnTime - spawnTime));


    }

    void SetTimeInterval()
    {
        maxTime = roMaxT / trap.GetComponent<Trap>().acceleration;
        minTime = roMinT / trap.GetComponent<Trap>().acceleration;
    }
}
