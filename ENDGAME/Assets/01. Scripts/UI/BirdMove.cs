using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdMove : MonoBehaviour
{
    public RectTransform min;
    public RectTransform max;

    float timeOfTravel = 5; //time after object reach a target place 
    float currentTime = 0; // actual floting time 
    float normalizedValue;

    private RectTransform rectTrm;

    // import

    // export

    // inner

    private void Awake()
    {
        rectTrm = GetComponent<RectTransform>();
        min.position = new Vector2(-1500, rectTrm.anchoredPosition.y);
        max.position = new Vector2(1500, rectTrm.anchoredPosition.y);
    }

    void Update()
    {
        if(currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            rectTrm.anchoredPosition = Vector3.Lerp(min.position, max.position, normalizedValue);
        }
        else
        {
            currentTime = 0;
        }
    }

    //IEnumerator LerpObject()
    //{
    //    while(currentTime <= timeOfTravel)
    //    {
    //        currentTime += Time.deltaTime;
    //        normalizedValue = currentTime / timeOfTravel;

    //        rectTrm.anchoredPosition = Vector3.Lerp();
    //    }
    //}
}
