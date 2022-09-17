using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float shootingRange = 5f;
    Collider2D[] enemies;
    Collider2D closerEnemy = null;


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform top, bulletSpawn;
    [SerializeField] float topRotationSpeed = 0.2f;

    void FixedUpdate()
    {

        if (CurrentInput.currentInputType == InputType.pcKeyboard) HandleRotate();
        else
        {
            GetEnemies();
            AutoRotate();
        }

    }

    void HandleRotate()
    {
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = targetPos - (Vector2)transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        top.rotation =
        Quaternion.Lerp(top.rotation, targetRotation, topRotationSpeed);
    }

    void AutoRotate()
    {
        if (closerEnemy != null)
        {
            Vector3 direction = (closerEnemy.transform.position - transform.position).normalized;
            float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            top.rotation =
            Quaternion.Lerp(top.rotation, targetRotation, topRotationSpeed);
        }
        else
        {
            top.localRotation = Quaternion.Lerp(top.localRotation, Quaternion.identity, 0.3f);
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
                Vector2 dir = (enemies[i].transform.position - transform.position).normalized;
                RaycastHit2D hitInfo =
                Physics2D.Raycast((Vector2)transform.position + dir * 1f, dir, shootingRange);
                Debug.Log(hitInfo);
                if (hitInfo.collider != null && hitInfo.collider.CompareTag("Enemy"))
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
    }
    public void Shoot()
    {
        if (CurrentInput.currentInputType == InputType.androidJoystick)
        {
            if (closerEnemy != null)
            {
                CreateBullet((closerEnemy.transform.position - transform.position).normalized);
            }
            else
            {
                CreateBullet(transform.up);
            }
        }
        else
        {
            CreateBullet(top.transform.up);
        }
    }
    void CreateBullet(Vector2 direction)
    {
        GameObject currentBullet = Instantiate(bulletPrefab, (Vector2)bulletSpawn.position, Quaternion.identity);
        currentBullet.GetComponent<BulletBehavior>().SetDirection(direction, DamageTaker.Type.enemy);
    }
}
