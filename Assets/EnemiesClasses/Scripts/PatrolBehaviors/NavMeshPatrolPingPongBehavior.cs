using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolPingPongBehavior : IPatrolable
{
    GameObject _object;
    NavMeshAgent agent;
    Transform _transform;
    Vector3[] patrolPoints;
    public NavMeshPatrolPingPongBehavior(GameObject gameObject)
    {
        _object = gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        _transform = gameObject.transform;
        patrolPoints = new Vector3[2]{
            _transform.position + new Vector3(-2, 0, 0),
            _transform.position + new Vector3(2, 0, 0)
        };
        agent.SetDestination(patrolPoints[0]);
        isForwardMoving = true;
    }
    public NavMeshPatrolPingPongBehavior(GameObject gameObject, Vector3[] PatrolPoints)
    {
        _object = gameObject;
        _transform = gameObject.transform;
        patrolPoints = PatrolPoints;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(patrolPoints[0]);
        isForwardMoving = true;
    }

    int currentSegment = 0, endInd = 1;
    bool isForwardMoving = true;
    public void PatrolMoving()
    {
        if (agent.remainingDistance < 0.05f)
        {
            currentSegment += isForwardMoving ? 1 : -1;

            if (isForwardMoving && currentSegment >= patrolPoints.Length)
            {

                currentSegment = patrolPoints.Length - 2;
                isForwardMoving = false;
            }
            if (!isForwardMoving && currentSegment <= -1)
            {
                currentSegment = 0;
                isForwardMoving = true;
            }
            //startInd = isForwardMoving ? currentSegment : currentSegment + 1;
            endInd = isForwardMoving ? currentSegment + 1 : currentSegment;
            agent.SetDestination(patrolPoints[currentSegment]);
        }

    }


}
