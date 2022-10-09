using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    void Start()
    {
        damagable = new SimpleDamagable(gameObject);
        patrolable = new SimplePatrolBehavior(gameObject);
        searchable = new OldSearch(transform);
    }


    void Update()
    {
        patrolable.PatrolMoving();
        if (searchable.Search()) Debug.Log("I SEE YOU");
    }
}
