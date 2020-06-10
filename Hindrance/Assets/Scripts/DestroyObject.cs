﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour      // 수정 예정
{
    void Update()
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);  // 월드좌표를 스크린 좌표로 변환
        if (view.x <= -10)
        {
            Destroy(gameObject);
        }
    }
}
