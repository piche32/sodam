using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    //[SerializeField] Text scoreText= null;
    [SerializeField] Slider HPSlider = null;

    [SerializeField] GameObject option = null;
    [SerializeField] GameObject setting = null;
    [SerializeField] GameObject result = null;

    [SerializeField] TextMeshProUGUI resultText = null;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI BestScoreText = null;

    private static bool isPause;
    public static bool IsPause { get { return isPause; } set { isPause = value; } }
    

    // Start is called before the first frame update
    void Start()
    {
       dataScript.Score = 0.0f;
        HPSlider.maxValue = dataScript.HPMax;
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = dataScript.Score.ToString();
        HPSlider.value = dataScript.HP;
       // HPText.text = "HP: " + dataScript.HP;

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
            if(dataScript.BestScore < dataScript.Score)
            {
                dataScript.BestScore = dataScript.Score;
                Debug.Log(dataScript.BestScore);
            }
            BestScoreText.text = dataScript.BestScore.ToString();
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
        SceneManager.LoadScene("MainGame");

        isPause = false;
    }

    public void quitBT()
    {
        isPause = false;
        SceneManager.LoadScene("Start");
    }

  

   
}
