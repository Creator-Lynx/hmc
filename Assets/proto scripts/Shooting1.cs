using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting1 : MonoBehaviour
{
    [SerializeField] float shootingRange = 6f;
    Collider2D[] enemies;
    [SerializeField] Collider2D closerEnemy;

    [SerializeField] GameObject bulletPrefab;
    bool readyToShoot = true;
    void Start()
    {
        closerEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }
    void Update()
    {
        if (readyToShoot)
        {
            Shoot();
        }
        //GetEnemies();
        Rotate();
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.7f);
        readyToShoot = true;
    }

    void Rotate()
    {

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
            RaycastHit2D hitInfo =
            Physics2D.Raycast(transform.position +
            (closerEnemy.transform.position - transform.position).normalized,
            (closerEnemy.transform.position - transform.position).normalized, 10f);
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.CompareTag("Player"))
            {
                readyToShoot = false;
                StartCoroutine(ShootDelay());
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
        currentBullet.GetComponent<BulletBehavior>().SetDirection(direction, DamageTaker.Type.player);
    }
}
