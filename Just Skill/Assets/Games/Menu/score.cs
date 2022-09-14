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
        
    }

    public void gameEnd(){

        int newScore = 1;

        scoreGame.text = newScore.ToString();

        if(newScore> PlayerPrefs.GetInt("highscore",0)){
            PlayerPrefs.SetInt("highscore",newScore);
            highscore.text = newScore.ToString();
        }
        
    }


}
