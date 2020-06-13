using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    static EnemyScript instance;
    public static EnemyScript Call() { return instance; }

    GameObject[] _StopEnemy;      // 프리팹 
    public List<GameObject> StopEnemyList = new List<GameObject>();    // 객체 저장 리스트

    GameObject[] _ReverseEnemy;
    public List<GameObject> ReverseEnemyList = new List<GameObject>();

    public int stopCount;   // stopEnemy

    public int reverseCount;    // reverseEnemy

    private void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        MemoryDelete();
        instance = null;
    }

    void Start()
    {
        StopEnemyList.Capacity = stopCount;
        ReverseEnemyList.Capacity = reverseCount;

        FindEnemy(stopCount, reverseCount);
    }

    public void FindEnemy(int s_count, int r_count)
    {
        for (int i = 0; i < s_count; i++)      // 해당 적 찾아서 리스트 저장
        {
            _StopEnemy = GameObject.FindGameObjectsWithTag("StopEnemy");
            StopEnemyList.Add(_StopEnemy[i]);
        }

        for (int i = 0; i < r_count; i++)
        {
            _ReverseEnemy = GameObject.FindGameObjectsWithTag("ReverseEnemy");
            ReverseEnemyList.Add(_ReverseEnemy[i]);
        }
    }

    public void StopBtDown()
    {
        foreach (GameObject enemy in StopEnemyList)
        {
            enemy.gameObject.GetComponent<MoveEnemy>().EnemySpeed = 0;
        }
    }
    public void StopBtUp()
    {
        foreach (GameObject enemy in StopEnemyList)
        {
            enemy.gameObject.GetComponent<MoveEnemy>().EnemySpeed = enemy.gameObject.GetComponent<MoveEnemy>().tmp;
        }
    }

    public void ReverseBtDown()
    {
        foreach (GameObject enemy in ReverseEnemyList)
        {
            enemy.gameObject.GetComponent<ReverseEnemy>().BtDownReverse();
        }
    }
    public void ReveseBtUp()
    {
        foreach (GameObject enemy in ReverseEnemyList)
        {
            enemy.gameObject.GetComponent<ReverseEnemy>().BtUpReverse();
        }
    }

    public void MemoryDelete()  // 메모리 삭제 
    {
        if (StopEnemyList == null) return;

        for (int i = 0; i < stopCount; i++)
        {
            GameObject obj = StopEnemyList[i];
            GameObject.Destroy(obj);
        }
        StopEnemyList = null;

        if (ReverseEnemyList == null) return;

        for (int i = 0; i < reverseCount; i++)
        {
            GameObject obj = ReverseEnemyList[i];
            GameObject.Destroy(obj);
        }
        ReverseEnemyList = null;
    }
}
