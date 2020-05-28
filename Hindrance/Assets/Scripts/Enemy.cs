using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);  // 월드좌표를 스크린 좌표로 변환
        if (view.x <= -10) Destroy(gameObject);     
    }


    //플레이어 스크립트에 작성하는게 나을것 같음! 임시
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerScript.Hp -= 10;
            Debug.Log("Hp: " + PlayerScript.Hp);
        }
    }
}
