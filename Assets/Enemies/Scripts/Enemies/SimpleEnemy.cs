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
        patrolable = new NavMeshPatrolBehavior(gameObject, points, 2f);
        searchable = new OldSearch(transform);
        shootable = new OldShoot(transform, bulletPrefab);
    }


    void Update()
    {
        patrolable.PatrolMoving();
        if (searchable.Search()) shootable.Shoot();
    }
}
