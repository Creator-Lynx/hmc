using UnityEngine;

public class OldSearch : ILookable
{
    Collider2D closerEnemy;
    Transform _transform;
    public OldSearch(Transform transform)
    {
        closerEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        _transform = transform;
    }
    public bool Search()
    {
        if (closerEnemy != null)
        {
            RaycastHit2D hitInfo =
            Physics2D.Raycast(_transform.position +
            (closerEnemy.transform.position - _transform.position).normalized,
            (closerEnemy.transform.position - _transform.position).normalized, 10f);
            //Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider != null)
                if (hitInfo.collider.CompareTag("Player"))
                {
                    return true;
                }
        }
        return false;
    }
}
