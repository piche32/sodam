using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라 움직임 스크립트
//플레이어와 일정거리 이상 멀어지면 쫓는다.

public class CameraMoveScript : MonoBehaviour
{
    Vector3 pos;
    Vector3 playerPos;
    [SerializeField] GameObject player = null;
    [SerializeField] float maxDistance = 10.0f; //플레이어와 카메라의 최대 거리
    [SerializeField] float cameraSpeed = 0.04f; //플레이어의 속도에 변화가 생긴다면 다시 고민하기

    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
        playerPos = player.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;
        playerPos = player.gameObject.transform.position;
        if (pos.x - playerPos.x < maxDistance) //최대 거리 안에서 움직이기 
        {
            pos.x += cameraSpeed;
        }

        this.gameObject.transform.position = pos;
    }
}
