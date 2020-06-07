using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
       private bool isEffectSoundOn;
      public bool IsEffectSoundOn { get { return isEffectSoundOn; } set { isEffectSoundOn = value; } }

    private bool isBGMOn;
    public bool IsBGMOn { get { return isBGMOn; } set { isBGMOn = value; } }


    [SerializeField] AudioSource bgm = null;
    [SerializeField] AudioSource effectSound = null;
    [SerializeField] AudioSource playerSound = null;

    [SerializeField] AudioClip openSound = null;
    [SerializeField] AudioClip closeSound = null;

   // [SerializeField] AudioClip jumpSound = null;
    [SerializeField] AudioClip coinSound = null;
    [SerializeField] AudioClip attackedSound = null;
    [SerializeField] AudioClip clickSound = null;

    public static SoundManagerScript instance;
    private void Awake()
    {
        instance = this;
    }
    private SoundManagerScript() { }

    public static SoundManagerScript Instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new SoundManagerScript();
            }
            return Instance;
        }

        private set
        {
            Instance = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isEffectSoundOn = true;
        isBGMOn = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playerSoundCtrl()
    {
        if (isEffectSoundOn == false) return;
        playerSound.Play();
    }

    public void UISound(bool isOpen)
    {
        if (isEffectSoundOn == false) return;
        if (isOpen == true)
            effectSound.clip = openSound;
        else
            effectSound.clip = closeSound;

        effectSound.volume = 1.0f;
        effectSound.Play();

        return;
    }

    public void effectCtrl()
    {
        isEffectSoundOn = !isEffectSoundOn;
        if (isEffectSoundOn == true)
        {
            effectSound.mute = false;
            playerSound.mute = false;
        }
        else
        {
            effectSound.mute = true;
            playerSound.mute = true;
        }
    }

    public void BGMCtrl()
    {
        clickSoundCtrl();
        isBGMOn = !isBGMOn;
        if (isBGMOn == false)
        {
          //  bgm.mute = true;
            bgm.Stop();
        }
        else
        {
           // bgm.mute = false;
            bgm.Play();
        }
    }

    public void coinSoundCtrl()
    {
        if (isEffectSoundOn == false) return;
        effectSound.clip = coinSound;
        effectSound.volume = 1.0f;
        effectSound.Play();
    }

    public void attackedSoundCtrl()
    {
        if (isEffectSoundOn == false) return;
        effectSound.clip = attackedSound;
        effectSound.volume = 0.3f;
        effectSound.Play();
    }

    public void clickSoundCtrl()
    {
        if (isEffectSoundOn == false) return;
        effectSound.clip = clickSound;
        effectSound.volume = 1.0f;
        effectSound.Play();
    }
}

