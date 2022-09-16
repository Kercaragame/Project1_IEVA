using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ennemy;

    const float radius = 10f;

    [Header("Probability")]
    //probability ne ennemy spawn
    public float increaseProbability = 0.01f;
    public float probability = 0.5f;



    void Update()
    {
        float dt = Time.deltaTime;
        probability += increaseProbability*dt;


        if(Random.Range(0, (int)(1/(probability*dt))+1)==0){
            float angle = Random.Range(0, 201)*Mathf.PI/100;
            Vector3 randomSpwn = new Vector3(Mathf.Cos(angle)*radius,1,Mathf.Sin(angle)*radius );
            Instantiate(ennemy, randomSpwn, Quaternion.identity);

        }

        
        
    }
}
