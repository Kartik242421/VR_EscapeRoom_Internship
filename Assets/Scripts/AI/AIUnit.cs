using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class AIUnit : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float AttackRange = 1.0f; // Define the attack range
    private Transform target;
    private Animator animator; // Reference to the Animator component
    private bool isShooting = false; // Flag to control shooting state

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Get the Animator component
        AIManager.Instance.Units.Add(this); // Register this unit with the AIManager
        target = AIManager.Instance.Target; // Get the target from AIManager
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        
        // Check if within attack range
        if (distanceToTarget <= AttackRange)
        {
            isShooting = true;
            animator.SetBool("Punch", true); // Set 'shooting' parameter to true in Animator
            StopMovement(); // Stop movement
            PerformAttack(); // Call attack logic
        }
        else
        {
            isShooting = false;
            animator.SetBool("Punch", false); // Set 'shooting' parameter to false in Animator
            MoveToTarget(); // Move towards the target
        }
    }

    private void MoveToTarget()
    {
        if (!isShooting)
        {
            Agent.SetDestination(target.position); // Move towards the target
        }
        else
        {
            Agent.ResetPath(); // Stop moving towards the target if shooting
        }
    }

    public void MoveTo(Vector3 position)
    {
        Agent.SetDestination(position); // Move to a specific position
    }

    private void StopMovement()
    {
        Agent.ResetPath(); // Stop the NavMeshAgent from moving
    }

    private void PerformAttack()
    {
        // Implement your attack logic here
        Debug.Log($"{gameObject.name} is attacking the target!");
        // Add your attack logic here
    }
}
