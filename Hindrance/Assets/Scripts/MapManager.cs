using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameObject[] Stage;  

    public void NextStage()
    {
        dataScript.stage += 1;

        if(dataScript.stage > Stage.Length)
        {
            dataScript.stage = dataScript.stage % Stage.Length;
            if(dataScript.stage == 0)
            {
                dataScript.stage = Stage.Length;
            }
        }

        StartStage();
    }

    void StartStage()
    {

        if (dataScript.stage == 1)
        {
            SceneManager.LoadScene("Ending");
        }
            for (int i = 1; i < Stage.Length; i++)
        {
            if (i == dataScript.stage)
            {
                Stage[i].SetActive(true);
                Stage[i - 1].SetActive(false);
            }
        }
    }
}
