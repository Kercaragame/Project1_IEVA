using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int lifePoint;
    public float delayBeforeDead;


    public void takeDommage(int damageTaken)
    {
        lifePoint -= damageTaken;
        if (lifePoint <= 0)
        {
            //DoSomething
            Invoke("isDead", delayBeforeDead);
        }

    }

    public void isDead()
    {
        Destroy(this.gameObject);
    }
}
