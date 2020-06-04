using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ReverseEnemy : MonoBehaviour   // 어딘가 오류나서 정상적으로 작동안함. 수정할거
{
    public bool isTop = true;  // true면 천장, flase면 바닥에 위치

    private float gr = 980.0f;  // 중력값

    public void BtDownReverse()
    {
        if (isTop)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gr);
        }
        if (!isTop)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gr);
        }
    }

    public void BtUpReverse()
    {
        if (isTop)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * gr);
        }
        if (!isTop)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * gr);
        }
    }
}
