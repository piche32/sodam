using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject[] Enemy;      // 프리팹 
    public List<GameObject> EnemyList = new List<GameObject>();    // 객체 저장 리스트

    public int count;   // stopEnemy
    private bool isStop = false;

    void Start()
    {
        EnemyList.Capacity = count;
        FindEnemy(count);
    }

    void Update()
    {
        //MemoryDelete();
        StopEnemy();
    }

    public void FindEnemy(int count)
    {
        for (int i = 0; i < count; i++)      // 해당 적 찾아서 리스트 저장
        {
            Enemy = GameObject.FindGameObjectsWithTag("StopEnemy"); 
            EnemyList.Add(Enemy[i]);
        }
    }

    void StopEnemy()    // 왜 안될까~~~~~~~~
    {
        if(isStop)
        {
            foreach(GameObject enemy in EnemyList)
            {
                enemy.gameObject.GetComponent<MoveEnemy>().EnemySpeed = 0;
            }
        }
        else
        {
            foreach (GameObject enemy in EnemyList)
            {
               enemy.gameObject.GetComponent<MoveEnemy>().EnemySpeed = enemy.gameObject.GetComponent<MoveEnemy>().tmp;
            }
        }
    }

    public void BtDownStop()    
    {
        isStop = true;
    }

    public void BtUpStop()
    {
        isStop = false;
    }

    public void MemoryDelete()  // 메모리 삭제 -> 수정예정
    {
        if (EnemyList == null) return;

        for(int i=0; i<EnemyList.Count; i++)
        {
            if(Enemy[i] == null)
            {
                EnemyList.RemoveAt(i);
            }
        }
    }
}
