using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public bool isRotate = false;
    public float upSpeed = 3f;

    void Start()
    {
        StartCoroutine(Disable());
    }

    void Update()
    {
        if(isRotate)
        {
            transform.rotation = Quaternion.Euler(new Vector3
                (0, 0,
                    transform.rotation.eulerAngles.z + 3f));
            transform.position = new Vector2(0, transform.position.y + upSpeed * Time.deltaTime);
        }
    }

    public void Rotate()
    {
        isRotate = true;
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
