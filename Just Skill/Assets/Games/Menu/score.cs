using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{

    public TextMeshProUGUI   scoreGame;
    public TextMeshProUGUI  highscore;
    
    void Start()
    {

        highscore.text = PlayerPrefs.GetInt("highscore",0).ToString();
        if (GameObject.Find("gameManager"))
        {
            int score = GameObject.Find("gameManager").GetComponent<gameManager>().scoreNumer;
            setScore(score);
        }
        
    }


    public void setScore(int score)
    {
        scoreGame.text = score.ToString();
        //from here
        if (score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
            highscore.text = score.ToString();
        }
    }


}
