using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataScript : MonoBehaviour
{
    [SerializeField] float maxHp = 100.0f;
    private static float hp;
    public static float HP {  get { return hp; }  set { hp = value; } }

    private static float score;
    public static float Score { get { return score; } set { score = value; } }

    public static int stage = 0;

    void Start()
    {
        hp = maxHp;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
