using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    private RectTransform rectTrm;
    private int dir = 1;

    // import

    // export

    // inner

    private void Awake()
    {
        rectTrm = GetComponent<RectTransform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Abs(rectTrm.eulerAngles.z) >= 10f)
        {
            dir *= -1;
        }

        Vector3 rot = rectTrm.eulerAngles;
        rot.z += dir * Time.deltaTime * 6;
        rectTrm.eulerAngles = rot;

        Vector3 pos = rectTrm.anchoredPosition;
        pos.x += dir * Time.deltaTime * 2;
        pos.y += dir * Time.deltaTime * 0.5f;
        rectTrm.anchoredPosition = pos;


    }
}
