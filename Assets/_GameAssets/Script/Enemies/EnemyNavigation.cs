using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] float wanderingDistanceX, wanderingDistanceZ, distanceOffset, chaseSpeed;
    Vector3 startPoint;
    NavMeshAgent agent;
    bool chasing;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPoint = transform.position;
        SetWanderingDestination();
    }
    void Update()
    {
        if (!chasing && agent.remainingDistance <= agent.stoppingDistance + distanceOffset)
        {
            SetWanderingDestination();
        }
        else if (chasing)
        {
            ChaseTarget();
        }
    }
    void SetWanderingDestination()
    {
        Vector3 destinationPoint = new Vector3(startPoint.x + Random.Range(-wanderingDistanceX, wanderingDistanceX), startPoint.y, startPoint.z + Random.Range(-wanderingDistanceZ, wanderingDistanceZ));
        agent.SetDestination(destinationPoint);
    }
    public void SetChaseTarget(GameObject chaseTarget)
    {
        if (!chasing)
        {
            chasing = true;
            target = chaseTarget.transform;
            agent.speed = chaseSpeed;
        }
        ChaseTarget();
    }
    void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }
}
