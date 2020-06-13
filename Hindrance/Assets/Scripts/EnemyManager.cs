using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemy;

    public void DownStopButton()
    {
        if (EnemyScript.Call().StopEnemyList == null) return; 
      
        EnemyScript.Call().StopBtDown();

    }
    public void UpStopButton()
    {
        if (EnemyScript.Call().StopEnemyList == null) return;

        EnemyScript.Call().StopBtUp();

    }

    public void DownReverseButton()
    {
        if (EnemyScript.Call().ReverseEnemyList == null) return;

        EnemyScript.Call().ReverseBtDown();
    }
    public void UpReveseButton()
    {
        if (EnemyScript.Call().ReverseEnemyList == null) return;

        EnemyScript.Call().ReveseBtUp();
    }
}
