using System;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolLoopBehavior : IPatrolable
{
    GameObject _object;
    NavMeshAgent agent;
    Transform _transform;
    Vector3[] patrolPoints;
    bool correctInitialize = true;
    public NavMeshPatrolLoopBehavior(GameObject gameObject)
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
    }
    public NavMeshPatrolLoopBehavior(GameObject gameObject, Vector3[] PatrolPoints)
    {
        try
        {
            _object = gameObject;
            _transform = gameObject.transform;
            patrolPoints = PatrolPoints;
            agent = gameObject.GetComponent<NavMeshAgent>();
            //agent.updateRotation = false;
            //agent.updateUpAxis = false;
            agent.SetDestination(patrolPoints[0]);
        }
        catch (IndexOutOfRangeException)
        {
            correctInitialize = false;
            UnityEngine.Debug.LogError("The array of enemy(" + gameObject.name + ") patrol positions cannot be empty");
        }

    }

    int currentSegment = 0;
    public void PatrolMoving()
    {
        if (agent.remainingDistance < 0.05f)
        {
            currentSegment += 1;

            if (currentSegment >= patrolPoints.Length)
            {
                currentSegment = 0;
            }
            if (correctInitialize)
                agent.SetDestination(patrolPoints[currentSegment]);
        }

    }


}
