using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    DamageTaker.Type _type;
    Vector2 _direction = Vector2.zero;
    void Start()
    {
        Destroy(gameObject, 4f);
    }
    public void SetDirection(Vector2 direction, DamageTaker.Type type)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        _direction = direction;
        _type = type;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DamageTaker taker = other.gameObject.GetComponent<DamageTaker>();
        if (taker != null)
        {
            taker.TakeDamage(1, _type);

        }
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1, _type);

        }
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
    }

}
