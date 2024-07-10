using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class AIUnit : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float AttackRange = 1.0f; // Define the attack range
    private Transform target;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        AIManager.Instance.Units.Add(this);
        target = AIManager.Instance.Target;
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= AttackRange)
        {
            PerformAttack();
        }
    }

    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
    }

    private void PerformAttack()
    {
        // Implement your attack logic here
        Debug.Log($"{gameObject.name} is attacking the target!");
    }
}
