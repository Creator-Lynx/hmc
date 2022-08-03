using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    PlayerAnimator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed * Time.deltaTime;
        if (direction.magnitude < 0.1f)
        {
            anim.isWalk = false;
            return;
        }
        anim.isWalk = true;
        direction.Normalize();
        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation =
        Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
    }
}
