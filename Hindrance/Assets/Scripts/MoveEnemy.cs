using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public int EnemySpeed = 1;  // 움직이는 방해물 속도
    public int tmp;

    public float rightMax = 0f;   // 좌우 이동 최대값
    public float leftMax = 0f;
    public float topMax = 0f;     // 상하 이동 최대값
    public float bottomMax = 0f;

    public bool isTopBottom = true;    // 이동 방향 결정 true: 상하 flase: 좌우
    public int dir = 1;                // 방향 바꾸기  1이면 아래, 왼쪽으로 -1이면 위, 오른쪽으로

    void Start()
    {
        tmp = EnemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()  // 이동 함수
    {
        if (isTopBottom == true)
        {
            if (gameObject.transform.position.y >= topMax)
            {
                dir = 1;
            }
            else if (gameObject.transform.position.y <= bottomMax)
            {
                dir = -1;
            }

            gameObject.transform.Translate(Vector3.down * Time.deltaTime * EnemySpeed * dir);
        }
        else
        {
            if (gameObject.transform.position.x >= rightMax)
            {
                dir = 1;
            }
            else if (gameObject.transform.position.x <= leftMax)
            {
                dir = -1;
            }

            gameObject.transform.Translate(Vector3.left * Time.deltaTime * EnemySpeed * dir);
        }
    }
}
