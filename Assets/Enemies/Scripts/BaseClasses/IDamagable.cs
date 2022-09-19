using UnityEngine;
public interface IDamagable
{
    /// <summary>
    /// return true if that damage kill the enemy
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    bool TakeDamage(int damage);
    int GetHitPoints();
    void Initialize();
}
