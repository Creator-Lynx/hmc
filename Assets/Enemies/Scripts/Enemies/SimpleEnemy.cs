using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    [SerializeField]
    GameObject bulletPrefab;
    void Start()
    {
        damagable = new SimpleDamagable(gameObject);
        patrolable = new NavMeshPatrolBehavior(gameObject);
        searchable = new OldSearch(transform);
        shootable = new OldShoot(transform, bulletPrefab);
    }


    void Update()
    {
        patrolable.PatrolMoving();
        if (searchable.Search()) shootable.Shoot();
    }
}
