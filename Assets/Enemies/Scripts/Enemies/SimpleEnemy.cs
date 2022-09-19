using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    void Start()
    {
        damagable = new SimpleDamagable(gameObject);
    }


    void Update()
    {

    }
}
