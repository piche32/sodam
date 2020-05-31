using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text HPText;

    [SerializeField] GameObject option = null;
    [SerializeField] GameObject tutorial = null;
    float score; //다른 곳에서 score를 관리하면 없애주기
    public float Score { get { return score; } set { score = value; } }

    private static bool isPause;
    public static bool IsPause { get { return isPause; } set { isPause = value; } }
    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
        HPText.text = "HP: " + PlayerScript.Hp;

        menuCtrl();

        if(isPause == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }

    void menuCtrl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!option.activeSelf) {
                isPause = true;
                option.SetActive(true);
            }
        }
        return;
    }

    public void menuClose()
    {
        if (option.activeSelf)
        {
            isPause = false;
            option.SetActive(false);
        }
    }

}
