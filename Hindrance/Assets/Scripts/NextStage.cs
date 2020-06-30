using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public GameObject _mapManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (dataScript.stage == 5)
            {
                SceneManager.LoadScene("Ending");
            }
            else
            {
                _mapManager.GetComponent<MapManager>().NextStage();
            }
        }
    }
}
