using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text HPText;

    [SerializeField] GameObject option = null;
    [SerializeField] GameObject setting = null;
    float score; //다른 곳에서 score를 관리하면 없애주기
    public float Score { get { return score; } set { score = value; } }

    private static bool isPause;
    public static bool IsPause { get { return isPause; } set { isPause = value; } }

    [SerializeField] AudioSource bgm = null;
    Toggle bgmToggle;

    [SerializeField] AudioSource effectSound = null;
    Toggle effectSoundToggle = null;

    [SerializeField]AudioClip openSound = null;
    [SerializeField]AudioClip closeSound = null;

    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
        bgmToggle = null;
        effectSoundToggle = null;
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
            if (!option.activeSelf&&!setting.activeSelf) {
                isPause = true;
                option.SetActive(true);
                effectSound.clip = openSound;
                effectSound.Play();
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
            effectSound.clip = closeSound;
            effectSound.Play();
        }
    }


    public void settingOpen()
    {
        option.SetActive(false);
        setting.SetActive(true);
        bgmToggle = GameObject.Find("bgmToggle").GetComponent<Toggle>();
        effectSoundToggle = GameObject.Find("EffectSoundToggle").GetComponent<Toggle>();
        effectSound.clip = openSound;
        effectSound.Play();
        return;
    }

    public void settingClose()
    {
        setting.SetActive(false);
        isPause = false;
        effectSound.clip = closeSound;
        effectSound.Play();
    }

    public void restartBT()
    {
        SceneManager.LoadScene("Start");
    }

    public void quitBT()
    {
        SceneManager.LoadScene("Start"); //나중에 바꿔주기
    }

    public void bgmCtrl()
    {
        if (bgm == null) return;
        if (bgmToggle == null) return;
        if (bgmToggle.isOn) bgm.Play();
        else bgm.Stop();
    }

    public void effectSoundCtrl()
    {
        if (effectSound == null) return;
        if (effectSoundToggle == null) return;
        if (effectSoundToggle.isOn) effectSound.mute = false;
        else effectSound.mute = true;
    }
}
