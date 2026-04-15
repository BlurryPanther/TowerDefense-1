using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public float Speed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    private void Start()
    {
        agent.speed = Speed;
    }

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
