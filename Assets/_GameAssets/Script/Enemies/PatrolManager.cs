using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolManager : MonoBehaviour
{
    private const string PARAM_WALK = "Walking";
    private const string PARAM_RUN = "Runing";
    private const string PARAM_TURNLEFT = "TurningLeft";
    private const string PARAM_TURNRIGHT = "TurningRight";
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
    public float turnSpeed;
    private bool turning = false;
    public float targetAngle;
    public float angleOffset;
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
        if (turning)
        {
            Rotate();
        }
        else if (nma.remainingDistance <= nma.stoppingDistance + 0.01f)
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
            }
            else
            {
                agentAnimator.SetBool(PARAM_RUN, false);
                agentAnimator.SetBool(PARAM_WALK, true);
                nma.speed = walkSpeed;
            }
        }
    }
    void SetNewDestination(){
        StartCoroutine("NewDestinationCoroutine");
    }

    IEnumerator NewDestinationCoroutine()
    {
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
        while(nma.pathPending){
            Debug.Log("Calculating Path");
            yield return null;
        }
        GetTargetAngle();
        hasDestination = false;
    }

    void GetTargetAngle()
    {
        
        Vector3 movementDirection = new Vector3(nma.steeringTarget.x - transform.position.x,0,nma.steeringTarget.y - transform.position.y);
        targetAngle = Vector3.SignedAngle(movementDirection, transform.forward, Vector3.up);
        if (Mathf.Abs(targetAngle) > angleOffset && !turning)
        {
            turning = true;
            nma.isStopped = true;
            agentAnimator.SetBool(PARAM_WALK, false);
            agentAnimator.SetBool(PARAM_RUN, false);
            if (targetAngle < 0)
            {
                agentAnimator.SetBool(PARAM_TURNRIGHT, true);
                agentAnimator.SetBool(PARAM_WALK, false);
                agentAnimator.SetBool(PARAM_RUN, false);
            }
            else
            {
                agentAnimator.SetBool(PARAM_TURNLEFT, true);
                agentAnimator.SetBool(PARAM_WALK, false);
                agentAnimator.SetBool(PARAM_RUN, false);
            }
        }
        else if (Mathf.Abs(targetAngle) < angleOffset && turning)
        {
            turning = false;
            nma.isStopped = false;
            agentAnimator.SetBool(PARAM_TURNLEFT, false);
            agentAnimator.SetBool(PARAM_TURNRIGHT, false);
        }
    }
    void Rotate()
    {
        if (targetAngle < 0)
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        else if (targetAngle > 0)
        {
            transform.Rotate(0, -1f * turnSpeed * Time.deltaTime, 0);
        }
        GetTargetAngle();
    }
}
