using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] float coinScore = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dataScript.Score += coinScore;
            dataScript.HP += 2.0f;
            SoundManagerScript.instance.coinSoundCtrl();
            Destroy(this.gameObject);
        }
    }
}
