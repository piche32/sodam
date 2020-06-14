using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionScript : MonoBehaviour
{
    [SerializeField] float valueHP = 20.0f;
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
            dataScript.HP += valueHP;
            if (dataScript.HP > dataScript.HPMax) dataScript.HP = dataScript.HPMax;
            Destroy(this.gameObject);
        }
    }
}
