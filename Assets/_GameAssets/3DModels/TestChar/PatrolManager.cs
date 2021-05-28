using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolManager : MonoBehaviour
{
    private const string PARAM_WALK = "Walking";
    private const string PARAM_RUN = "Runing";
    public bool isPlayerDetected = false;
    private Animator agentAnimator;
    public Transform[] patrolPoints;
    private NavMeshAgent nma;
    public int currentPoint = 0;
    private bool hasDestination = false;
    public float waitTime = 3;
    public bool randomRoute;
    public float walkSpeed;//Velocidad de andar
    public float runSpeed;//Velocidad de correr
    public float runDistance;
    private void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
        agentAnimator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        nma.SetDestination(patrolPoints[currentPoint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (nma.remainingDistance <= nma.stoppingDistance)
        {
            if (!hasDestination)
            {
                agentAnimator.SetBool(PARAM_WALK, false);
                Invoke("SetNewDestination", waitTime);
                hasDestination = true;
            }
        }
        else
        {
            if (nma.remainingDistance > runDistance)
            {
                agentAnimator.SetBool(PARAM_RUN, true);
                nma.speed = runSpeed;
            } else
            {
                agentAnimator.SetBool(PARAM_RUN, false);
                agentAnimator.SetBool(PARAM_WALK, true);
                nma.speed = walkSpeed;
            }
        }
    }
    void SetNewDestination()
    {
        hasDestination = false;
        currentPoint++;
        if (currentPoint == patrolPoints.Length) currentPoint = 0;
        if (randomRoute)
        {
            nma.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].transform.position);
        }
        else
        {
            nma.SetDestination(patrolPoints[currentPoint].transform.position);
        }
    }
}
