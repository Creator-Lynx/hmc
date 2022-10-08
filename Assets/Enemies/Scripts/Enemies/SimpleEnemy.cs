using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    void Start()
    {
        damagable = new SimpleDamagable(gameObject);
        patrolable = new SimplePatrolBehavior(gameObject);
    }


    void Update()
    {
        patrolable.PatrolMoving();
    }
}
