using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolBehavior : IPatrolable
{
    GameObject _object;
    NavMeshAgent agent;
    Transform _transform;
    Vector3[] patrolPoints;
    float segmentMovingTime;
    public NavMeshPatrolBehavior(GameObject gameObject)
    {
        _object = gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
        _transform = gameObject.transform;
        patrolPoints = new Vector3[2]{
            _transform.position + new Vector3(-2, 0, 0),
            _transform.position + new Vector3(2, 0, 0)
        };
        segmentMovingTime = 2f;
    }
    public NavMeshPatrolBehavior(GameObject gameObject, Vector3[] PatrolPoints, float timeToMoveOnOneSegment)
    {
        _object = gameObject;
        _transform = gameObject.transform;
        patrolPoints = PatrolPoints;
        segmentMovingTime = timeToMoveOnOneSegment;
    }
    float timer = 0f;
    int currentSegment = 0, startInd = 0, endInd = 1;
    bool isForwardMoving = true;
    public void PatrolMoving()
    {
        timer += Time.deltaTime;
        float t = timer / segmentMovingTime;
        _transform.position = Vector3.Lerp(patrolPoints[startInd], patrolPoints[endInd], t);
        if (t > 1f)
        {
            currentSegment += isForwardMoving ? 1 : -1;

            if (currentSegment >= patrolPoints.Length - 1)
            {

                currentSegment = patrolPoints.Length - 2;
                isForwardMoving = false;
                timer = 0f;
            }
            if (currentSegment <= -1)
            {
                currentSegment = 0;
                isForwardMoving = true;
                timer = 0f;
            }
            startInd = isForwardMoving ? currentSegment : currentSegment + 1;
            endInd = isForwardMoving ? currentSegment + 1 : currentSegment;
        }

    }


}
