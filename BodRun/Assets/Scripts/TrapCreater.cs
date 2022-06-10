using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreater : MonoBehaviour
{
    public GameObject trap;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        currentSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
