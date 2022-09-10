using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ennemy;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            float angle = Random.Range(0, 201)*Mathf.PI/100;
            const float radius = 10f;
            Vector3 randomSpwn = new Vector3(Mathf.Cos(angle)*radius,1,Mathf.Sin(angle)*radius );
            Instantiate(ennemy, randomSpwn, Quaternion.identity);
        }
        
    }
}
