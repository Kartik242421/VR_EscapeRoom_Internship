using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float UpdateSpeed = 0.1f;
    private NavMeshAgent Agent;

    private void Awake() {
        Agent = GetComponent<NavMeshAgent>();
        
    }
    void Start()
    {
        StartCoroutine(FollowTarget()) ;
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds  Wait= new WaitForSeconds(UpdateSpeed);

        while(enabled)
        {
            Agent.SetDestination(target.transform.position);
            yield return Wait;

        }

    }
}
