using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class AIUnit : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float AttackRange = 1.0f;
    public float DetectionRange = 10.0f; // Detection range for the player
    private Transform target;
    private Animator animator;
    private bool isShooting = false;
    private bool isMoving = false; // Track if the AI is moving

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

        if (distanceToTarget <= AttackRange)
        {
            isShooting = true;
            SetAnimationStates("Punch");
            StopMovement();
            PerformAttack();
        }
        else if (distanceToTarget <= DetectionRange)
        {
            isShooting = false;
            SetAnimationStates("Walk");
            MoveToTarget();
        }
        else
        {
            isShooting = false;
            SetAnimationStates("Idle");
            StopMovement(); // Stop the enemy if the player is out of detection range
        }
    }

    private void MoveToTarget()
    {
        if (!isShooting)
        {
            Agent.SetDestination(target.position);
            isMoving = true;
        }
        else
        {
            Agent.ResetPath();
            isMoving = false;
        }
    }

    public void MoveTo(Vector3 position)
    {
        Agent.SetDestination(position);
        isMoving = true;
    }

    private void StopMovement()
    {
        Agent.ResetPath();
        isMoving = false;
    }

    private void PerformAttack()
    {
        // Implement your attack logic here
        Debug.Log($"{gameObject.name} is attacking the target!");
    }

    private void SetAnimationStates(string state)
    {
        switch (state)
        {
            case "Idle":
                animator.SetBool("Idle", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Punch", false);
                break;
            case "Walk":
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", true);
                animator.SetBool("Punch", false);
                break;
            case "Punch":
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", false);
                animator.SetBool("Punch", true);
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
    }
}
