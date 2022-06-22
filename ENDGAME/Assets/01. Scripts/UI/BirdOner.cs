using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOner : MonoBehaviour
{
    public GameObject bird2;
    public GameObject bird3;

    public bool bird2On;
    public bool bird3On;

    // import

    // export

     // inner

    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time >= 0.2f && !bird2On)
        {
            bird2.SetActive(true);
            bird2On = true;
        }

        if (Time.time >= 0.8f && !bird3On)
        {
            bird3.SetActive(true);
            bird3On = true;
        }

    }
}
