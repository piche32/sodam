using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceneUIScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = dataScript.Score.ToString()+ " " + '$';
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
