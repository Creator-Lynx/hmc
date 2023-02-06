using UnityEngine;

public class SimpleDamagable : IDamagable
{
    int HP = 1;
    GameObject _object;
    public SimpleDamagable(GameObject gameObject) => _object = gameObject;
    public bool TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            MonoBehaviour.Destroy(_object);
        }
        return HP <= 0 ? true : false;
    }

    public int GetHitPoints()
    {
        return HP;
    }

}
