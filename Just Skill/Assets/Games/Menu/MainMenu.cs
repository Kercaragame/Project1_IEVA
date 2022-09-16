using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void playGame(){
        SceneManager.LoadScene("Game1");
    }

    public void quitGame(){
        Application.Quit();
    }

}
