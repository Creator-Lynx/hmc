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
    float timer = 0f;
    [SerializeField] float timeToMaxSpeed = 0.1f;
    public void Move(Vector2 direction)
    {
        rb.velocity = Vector3.Slerp(Vector3.zero, direction * speed, timer / timeToMaxSpeed);
        if (direction.magnitude < 0.1f)
        {
            anim.isWalk = false;
            timer = 0f;
            return;
        }
        timer += Time.fixedDeltaTime;
        anim.isWalk = true;
        direction.Normalize();
        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation =
        Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
    }
}
