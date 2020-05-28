using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testReverse : MonoBehaviour
{
    public float speed = 1.0f;
    private bool isMove = false;
    public bool isTop = true;

    void Update()
    {
        if(isTop && isMove)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if(!isTop && isMove)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isTop = false;
        }
        if(other.gameObject.tag == "Ceiling")
        {
            isTop = true;
        }
    }

    public void BtDownReverse()
    {
        isMove = true;
    }

    public void BtUpReverse()
    {
        isMove = false;
    }
}
