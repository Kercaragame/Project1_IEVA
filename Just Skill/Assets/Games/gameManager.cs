using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int scoreNumer;
    public Score scoreScript;
    public static  gameManager GMInstance;

    private void Awake()
    {
        if(GMInstance != null && GMInstance != this)
        {
            Destroy(this);
        }
        else
        {
            GMInstance = this;
        }
    }
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void EndGame()
    {
        if (GameObject.Find("ScoreGameObject")) scoreScript = GameObject.Find("ScoreGameObject").GetComponent<Score>();
        scoreNumer = scoreScript.scoreNumber;
        SceneManager.LoadScene("Menu");

    }
}
