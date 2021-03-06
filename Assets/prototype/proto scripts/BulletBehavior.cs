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
        _direction = direction;
        _type = type;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * bulletSpeed);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        DamageTaker taker = other.GetComponent<DamageTaker>();
        if (taker != null)
        {
            taker.TakeDamage(1, _type);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        DamageTaker taker = other.gameObject.GetComponent<DamageTaker>();
        if (taker != null)
        {
            taker.TakeDamage(1, _type);
        }
    }

}
