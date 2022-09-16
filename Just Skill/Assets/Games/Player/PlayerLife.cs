using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{

    public string enemyTag;
    public string deadGroundTag;
    public int playerLife;
    public int damageTaken;
    private bool playerDead = false;
    public gameManager GM;

    private void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (playerDead) return;
        if(collision.gameObject.tag == enemyTag)
        {
            playerLife -= damageTaken;
            if (playerLife <= 0) killPlayer();

        }
        if(collision.gameObject.tag == deadGroundTag)
        {
            killPlayer();
        }
    }

    public void killPlayer()
    {
        playerDead = true;
        //notifyGameManager
        GM.EndGame();
    }
}
