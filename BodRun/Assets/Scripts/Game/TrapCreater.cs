
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreater : MonoBehaviour
{

    public GameObject prefabTrap;
    public GameObject trap;
    // Start is called before the first frame update

    public readonly float roMaxT=5;
    public readonly float roMinT = 2;
    public float maxTime;
    public float minTime;
    private float oldAcc;
    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start()
    {
        maxTime = roMaxT;
        minTime = roMinT;
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {

        //Counts up
        time += Time.deltaTime;
        
        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnObject();
            oldAcc = trap.GetComponent<Trap>().acceleration;
            SetRandomTime();
        }
        

    }

    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0;
        trap= Instantiate(prefabTrap, transform.position, prefabTrap.transform.rotation);
        SetTime();
            

    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {

        spawnTime = Random.Range(minTime, maxTime);
    }
    void SetTime()
    {
        if(oldAcc == trap.GetComponent<Trap>().acceleration)
        {
            maxTime =roMaxT / trap.GetComponent<Trap>().acceleration;
            minTime =roMinT / trap.GetComponent<Trap>().acceleration;
        }
        
    }
}
