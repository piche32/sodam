using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    bool magnetOn;
    float timer;
    [SerializeField] float maxTime = 10.0f; //자석 아이템 지속 시간
    [SerializeField] float speed = 0.5f; //끌려오는 속도
    [SerializeField] float dist = 10.0f; //플레이어와 코인 사이 최대 거리
    // Start is called before the first frame update
    GameObject player;

    void Start()
    {
        magnetOn = false;
        timer = maxTime;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetOn == true) magnetFunction();
    }

    void magnetFunction()
    {
        timer -= Time.deltaTime;
        if (timer >= 0.0f)
        {
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            foreach(GameObject coin in coins) {
                if(Vector3.Distance(player.gameObject.transform.position,
                    coin.gameObject.transform.position)<= dist)
                {
                    coin.transform.position = Vector3.Lerp(coin.transform.position,
                        player.transform.position, Time.deltaTime * speed);
                }
            }
        }
        else
        {
            timer = maxTime;
            magnetOn = false;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            magnetOn = true;
        }
    }
}
