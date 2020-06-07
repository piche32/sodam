using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGround : MonoBehaviour
{
    public float scrollSpeed = 0.2f;

    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 newOffset = material.mainTextureOffset;

        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        material.mainTextureOffset = newOffset;
    }
}
