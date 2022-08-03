using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float shootingRange = 5f;
    Collider2D[] enemies;
    Collider2D closerEnemy = null;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform top;

    void Update()
    {
        GetEnemies();
        Rotate();
    }

    void Rotate()
    {
        if (closerEnemy != null)
        {
            Vector3 direction = (closerEnemy.transform.position - transform.position).normalized;
            float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
            Debug.Log(angle);
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            top.localRotation =
            Quaternion.Slerp(transform.localRotation, targetRotation, 0.3f);
        }
        else
        {
            top.localRotation = Quaternion.identity;
        }
    }

    void GetEnemies()
    {
        closerEnemy = null;
        float minDistance = float.MaxValue;
        enemies = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
        shootingRange);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].CompareTag("Enemy"))
            {
                float dist = Vector2.Distance((Vector2)enemies[i].transform.position, (Vector2)transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closerEnemy = enemies[i];
                }
            }

        }
    }

    public void Shoot()
    {
        if (closerEnemy != null)
        {
            // RaycastHit2D hitInfo =
            //Physics2D.Raycast(transform.position,
            //(closerEnemy.transform.position - transform.position).normalized, 10f);
            //if (hitInfo.collider.CompareTag("Enemy"))
            {
                CreateBullet((closerEnemy.transform.position - transform.position).normalized);
            }
        }
        else
        {
            CreateBullet(transform.up);
        }
    }
    void CreateBullet(Vector2 direction)
    {
        GameObject currentBullet = Instantiate(bulletPrefab, transform.position + (Vector3)direction, Quaternion.identity);
        currentBullet.GetComponent<BulletBehavior>().SetDirection(direction, DamageTaker.Type.enemy);
    }
}
