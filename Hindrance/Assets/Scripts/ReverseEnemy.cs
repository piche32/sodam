using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ReverseEnemy : MonoBehaviour
{
    public bool isTop = true;   //true면 천장, false면 바닥에 위치

    private float gr = 980.0f;  //중력값

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void ReverseBtDown()
    {
        if(isTop)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gr);
        }
        if(!isTop)
        { 
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gr);
        }
    }

    public void ReverseBtUp()
    {
        if(isTop)
        {        
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gr);
        }
        if(!isTop)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gr);
        }
    }
}
