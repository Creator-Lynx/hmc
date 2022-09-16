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
    float timer = 0f, backTimer = 0f;
    [SerializeField] float timeToMaxSpeed = 0.1f, timeToNullSpeed = 0.1f;
    public void Move(Vector2 direction)
    {
        //rb.velocity = Vector3.Slerp(Vector3.zero, direction * speed, timer / timeToMaxSpeed);
        //rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
        Vector2 targetMove = direction * speed * Time.deltaTime;
        rb.MovePosition((Vector2)transform.position + Vector2.Lerp(Vector2.zero, targetMove, timer / timeToMaxSpeed));
        if (direction.magnitude < 0.1f)
        {
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 10 * Time.deltaTime);
            targetMove = direction * speed * Time.deltaTime;
            rb.MovePosition((Vector2)transform.position + Vector2.Lerp(targetMove, Vector2.zero, backTimer / timeToNullSpeed));
            anim.isWalk = false;
            timer = 0f;
            backTimer += Time.deltaTime;
            return;
        }
        backTimer = 0f;
        timer += Time.deltaTime;
        anim.isWalk = true;
        direction.Normalize();
        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation =
        Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
    }
}
