using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class AIUnit : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float AttackRange = 1.0f; 
    private Transform target;
    private Animator animator;
    private bool isShooting = false; 

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
        AIManager.Instance.Units.Add(this); 
        target = AIManager.Instance.Target; 
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        
        // Check if within attack range
        if (distanceToTarget <= AttackRange)
        {
            isShooting = true;
            animator.SetBool("Punch", true); 
            StopMovement(); 
            PerformAttack(); 
        }
        else
        {
            isShooting = false;
            animator.SetBool("Punch", false); 
            MoveToTarget(); 
        }
    }

    private void MoveToTarget()
    {
        if (!isShooting)
        {
            Agent.SetDestination(target.position); 
        }
        else
        {
            Agent.ResetPath(); 
        }
    }

    public void MoveTo(Vector3 position)
    {
        Agent.SetDestination(position); 
    }

    private void StopMovement()
    {
        Agent.ResetPath(); 
    }

    private void PerformAttack()
    {
        // Implement your attack logic here
        Debug.Log($"{gameObject.name} is attacking the target!");
        // Add your attack logic here
    }
}
