using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour
{
    private MeshRenderer meshRenderer = null;
    private Vector2 offset = Vector2.zero;
    public float speed = 0.05f;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        // meshRenderer.material.color = new Color32(52, 69, 156, 255);
    }

    void Update()
    {
        offset.x += speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
