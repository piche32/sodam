using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    //[SerializeField] Text scoreText= null;
    [SerializeField] Text HPText = null;

    [SerializeField] GameObject option = null;
    [SerializeField] GameObject setting = null;
    [SerializeField] GameObject result = null;

    [SerializeField] TextMeshProUGUI resultText = null;
    [SerializeField] TextMeshProUGUI scoreText = null;

    private static bool isPause;
    public static bool IsPause { get { return isPause; } set { isPause = value; } }
    

    // Start is called before the first frame update
    void Start()
    {
       dataScript.Score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = dataScript.Score.ToString();
        HPText.text = "HP: " + dataScript.HP;

        menuCtrl();

        if(isPause == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        resultCtrl();

    }

    void menuCtrl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!option.activeSelf&&!setting.activeSelf) {
                isPause = true;
                option.SetActive(true);
                SoundManagerScript.instance.UISound(true);

            }
        }
        return;
    }

    public void resultCtrl()
    {
        if (dataScript.HP > 0) return;
        if (!option.activeSelf && !setting.activeSelf && !result.activeSelf)
        {
            isPause = true;
            result.SetActive(true);
            resultText.text = dataScript.Score.ToString();
        }
        return;
    }

    public void menuClose()
    {
        if (option.activeSelf)
        {
            isPause = false;
            option.SetActive(false);
            SoundManagerScript.instance.UISound(false);

        }
    }


    public void settingOpen()
    {
        option.SetActive(false);
        setting.SetActive(true);
      SoundManagerScript.instance.UISound(true);
        return;
    }

    public void settingClose()
    {
        setting.SetActive(false);
        isPause = false;
        SoundManagerScript.instance.UISound(false);

    }

    public void restartBT()
    {
        SceneManager.LoadScene("Start");
    }

    public void quitBT()
    {
        SceneManager.LoadScene("Start"); //나중에 바꿔주기
    }

  

   
}
