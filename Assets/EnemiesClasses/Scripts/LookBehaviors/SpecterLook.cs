using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class SpecterLook : ILookable
{
    Collider2D closerEnemy;
    Transform _transform;
    int _halfAngleOfSpecter;
    float _distance;
    public SpecterLook(Transform transform, int halfAngleOfSpecter = 30, float distance = 10f)
    {
        closerEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        _transform = transform;
        _halfAngleOfSpecter = halfAngleOfSpecter;
        _distance = distance;
    }
    public bool Search()
    {
        if (closerEnemy != null)
        {
            if (Vector2.Angle((closerEnemy.transform.position - _transform.position).normalized, _transform.forward) < _halfAngleOfSpecter)
            {
                RaycastHit2D hitInfo =
                    Physics2D.Raycast(_transform.position +
                        (closerEnemy.transform.position - _transform.position).normalized,
                        (closerEnemy.transform.position - _transform.position).normalized, _distance);
                //Debug.Log(hitInfo.collider.name);
                if (hitInfo.collider != null)
                    if (hitInfo.collider.CompareTag("Player"))
                    {
                        return true;
                    }
            }

        }
        return false;
    }
}
