﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataScript : MonoBehaviour
{
    private static float hp;
    public static float HP {  get { return hp; }  set { hp = value; } }
    [SerializeField] float MaxHP = 100.0f;
    static float hpMax;
    public static float HPMax { get { return hpMax; } set { hpMax = value; } }

    private static float score;
    public static float Score { get { return score; } set { score = value; } }

    private static float bestScore = 0;
    public static float BestScore { get { return bestScore; } set { bestScore = value; } }

    public static int stage = 0;

    float timer;
    void Start()
    {
        hpMax = MaxHP;
        hp = hpMax;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f) {
            timer = 0.0f;
            hp--;
        }
    }
}
