using UnityEngine;

public class SimpleEnemy : Enemy
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform[] wayPoints;
    void Start()
    {
        damagable = new SimpleDamagable(gameObject);
        Vector3[] points = new Vector3[wayPoints.Length];
        for (int i = 0; i < wayPoints.Length; i++) { points[i] = wayPoints[i].position; }
        patrolable = new NavMeshPatrolLoopBehavior(gameObject, points);
        lookable = new OldSearch(transform);
        shootable = new OldShoot(transform, bulletPrefab);
    }

    bool patrolIsChanged = false;
    void Update()
    {
        patrolable.PatrolMoving();
        if (!patrolIsChanged && lookable.Search())
        {
            patrolable = new NavMeshPatrolPingPongBehavior(gameObject);
            patrolIsChanged = true;
        }
    }
}
