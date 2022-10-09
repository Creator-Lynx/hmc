using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] int hitPoints = 1;
    [SerializeField] Type takerType;
    public void TakeDamage(int damage, Type type)
    {
        if (takerType == type)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                if (gameObject.CompareTag("Player")) LevelController.instance.Lose();
                if (gameObject.CompareTag("Enemy")) LevelController.instance.DecreasScore();
                Destroy(gameObject);
            }
        }

    }
    public Type GetTakerType()
    {
        return takerType;
    }

    public enum Type
    {
        player,
        enemy
    }
}
