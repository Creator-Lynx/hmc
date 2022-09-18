using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    IDamagable damage;
    void Start()
    {
        damage.TakeDamage(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
