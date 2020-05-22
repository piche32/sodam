using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] float coinScore = 1.0f;
    GameObject UImanager;
    // Start is called before the first frame update
    void Start()
    {
        UImanager = GameObject.Find("UIManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            UImanager.GetComponent<UIManagerScript>().Score += coinScore;
            Destroy(this.gameObject);
        }
    }
}
