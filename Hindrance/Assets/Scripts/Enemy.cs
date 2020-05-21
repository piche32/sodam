using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;  // 테스트용 방해물

    public int speed = 1;  // 움직이는 방해물 속도
    private int tmpSpeed;  // 속도 저장 변수

    public float rightMax = 2.0f;   // 좌우 이동 최대값
    public float leftMax = -2.0f;    
    public float topMax = 0.0f;     // 상하 이동 최대값
    public float bottomMax = -4.0f;    

    public bool isDirection = true;  // 이동 방향 결정 true: 상하 flase: 좌우
    public int dir = 1;  // 방향 바꾸기  1이면 아래, 왼쪽으로 -1이면 위, 오른쪽으로

    public bool isMoving = false;      // 움직이는지
    public bool isStop = false;        // 스탑키에 영향을 받는지  

    void Start()
    {
        tmpSpeed = speed;
    }

    void Update()
    {
        if(isMoving == true) Moving();
    }

    void Moving()  // 이동 함수
    {
        if (isDirection == true)
        {
            if (enemy.transform.position.y >= topMax)
            {
                dir = 1;
            }
            else if (enemy.transform.position.y <= bottomMax)
            {
                dir = -1;
            }

            enemy.transform.Translate(Vector3.down * Time.deltaTime * speed * dir);
        }
        else
        {
            if(enemy.transform.position.x >= rightMax)
            {
                dir = 1;
            }
            else if(enemy.transform.position.x <= leftMax)
            {
                dir = -1;
            }

            enemy.transform.Translate(Vector3.left * Time.deltaTime * speed * dir);
        }
    }

    public void BtDownStopKey()     // 스탑키 눌렸을때
    {
        if(isStop == true)
        {
            speed = 0;      
        }
    }

    public void BtUpStopKey()
    {
        speed = tmpSpeed;   // 속도 원상 복귀시키기
    }
}
