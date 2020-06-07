using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.1f;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newOffset = material.mainTextureOffset;

        newOffset.Set(newOffset.x + (scrollSpeed * Time.deltaTime), 0);
        material.mainTextureOffset = newOffset;
    }
}
