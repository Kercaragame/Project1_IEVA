using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyFollow : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {

        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 goal = target.transform.position;
        agent.SetDestination(goal);

        
    }
}
