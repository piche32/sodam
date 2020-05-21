using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] Text scoreText;
    float score; //다른 곳에서 score를 관리하면 없애주기
    public float Score { get { return score; } set { score = value; } }
    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
   
}
