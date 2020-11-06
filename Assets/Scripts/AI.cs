/*Denis Yurkov*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerSingleton.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

           /* if (distance <= agent.stoppingDistance)
            { 
                // Shot in player

            }*/
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
