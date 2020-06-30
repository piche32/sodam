using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float jumpPower = 400.0f;

    float timer;
    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        isPlayerAlive();
        isUnbeatable();
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
            collision.collider.isTrigger = true; //"Enemy가 player에 닿으면 trigger로 변경되어 player가 뚫고 지나감
            if (isHit == true) return;
            dataScript.HP -= 10;
            SoundManagerScript.instance.attackedSoundCtrl();
            isHit = true;
        }

        if (collision.gameObject.tag == "StopEnemy")
        {
            collision.collider.isTrigger = true; //"Enemy가 player에 닿으면 trigger로 변경되어 player가 뚫고 지나감
            if (isHit == true) return;
            dataScript.HP -= 15;
            SoundManagerScript.instance.attackedSoundCtrl();
            isHit = true;
        }

        if (collision.gameObject.tag == "ReserveEnemy")
        {
            collision.collider.isTrigger = true; //"Enemy가 player에 닿으면 trigger로 변경되어 player가 뚫고 지나감

            if (isHit == true) return;
            dataScript.HP -= 20;
            SoundManagerScript.instance.attackedSoundCtrl();
            isHit = true;
        }
    }
    
    public void stopBtDown()
    {
        //stop 버튼 눌렀을 때 정지
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    public void stopBtUp()
    {
        //stop 버튼을 떼면 무조건 떨어짐.. 중력만 받아서 그런듯(수정??)
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
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

    void isUnbeatable()
    {
        if (isHit == false) return;
        Debug.Log("unbeatable");
        if (timer <= 0.0f) {
            isHit = false;
            timer = 5.0f;
            gameObject.GetComponent<Animator>().SetBool("isHit", isHit);
        }
        gameObject.GetComponent<Animator>().SetBool("isHit", isHit);
        timer-= Time.deltaTime;
        
    }
}
