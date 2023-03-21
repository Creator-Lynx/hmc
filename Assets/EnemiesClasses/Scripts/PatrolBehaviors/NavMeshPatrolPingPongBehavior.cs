using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolPingPongBehavior : IPatrolable
{
    GameObject _object;
    NavMeshAgent agent;
    Transform _transform;
    Vector3[] patrolPoints;
    bool isForwardMoving = true;
    bool correctInitialize = true;
    public NavMeshPatrolPingPongBehavior(GameObject gameObject)
    {
        _object = gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 3.5f;
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
        try
        {
            _object = gameObject;
            _transform = gameObject.transform;
            patrolPoints = PatrolPoints;
            agent = gameObject.GetComponent<NavMeshAgent>();
            agent.updateRotation = true;
            agent.updateUpAxis = false;

            isForwardMoving = true;
            agent.SetDestination(patrolPoints[0]);
        }
        catch (IndexOutOfRangeException)
        {
            correctInitialize = false;
            UnityEngine.Debug.LogError("The array of enemy(" + gameObject.name + ") patrol positions cannot be empty");
        }
    }

    int currentSegment = 0, endInd = 1;

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
            if (correctInitialize)
                agent.SetDestination(patrolPoints[currentSegment]);
        }

    }


}
