using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected IDamagable damagable;
    protected IPatrolable patrolable;
    protected ILookable lookable;
    protected IFollowable followable;
    protected IShootable shootable;

    public void TakeDamage(int d, DamageTaker.Type type)
    {
        if (type == DamageTaker.Type.enemy)
            damagable.TakeDamage(d);
    }
}