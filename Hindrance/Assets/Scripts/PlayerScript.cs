﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 0.03f; //나중에 시간이 오래 지날수록 늘리기
    [SerializeField] float jumpPower = 400.0f;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        move();
        isPlayerAlive();
    }


    private void move() //앞으로 움직이기
    {
        gameObject.transform.Translate(new Vector3(speed, 0.0f, 0.0f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
            SoundManagerScript.instance.playerSoundCtrl();
        }
        if (collision.gameObject.tag == "Ceiling")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * jumpPower);
            SoundManagerScript.instance.playerSoundCtrl();

        }
        if (collision.gameObject.tag == "Enemy")
        {
            dataScript.HP -= 10;
            SoundManagerScript.instance.attackedSoundCtrl();
            //collision.collider.isTrigger = true; //"Enemy가 player에 닿으면 trigger로 변경되어 player가 뚫고 지나감
        }
    }
    
    public void stopBtDown()
    {
        //stop 버튼 눌렀을 때 정지
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void stopBtUp()
    {
        //stop 버튼을 떼면 무조건 떨어짐.. 중력만 받아서 그런듯(수정??)
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void reverseBtDown()
    {
        Physics.gravity = Vector3.up * 9.8f;
    }

    public void reverseBtUp()
    {
        Physics.gravity = Vector3.down * 9.8f;
    }

    void isPlayerAlive() //Player가 카메라 밖으로 나가면 죽음
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        Debug.Log(pos);
        if (pos.x < -0.05f) dataScript.HP = 0;
        if (pos.x > 1.05f) dataScript.HP = 0;
        if (pos.y < -0.05f) dataScript.HP = 0;
        if (pos.y > 1.05f) dataScript.HP = 0;
       }
}
