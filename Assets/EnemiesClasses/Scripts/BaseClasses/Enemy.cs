using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected IDamagable damagable;
    public IPatrolable patrolable;
    protected ILookable lookable;
    protected IFollowable followable;
    protected IShootable shootable;
    protected IHearable hearable;

    public void TakeDamage(int d, DamageTaker.Type type)
    {
        if (type == DamageTaker.Type.enemy)
            damagable.TakeDamage(d);
    }
}
