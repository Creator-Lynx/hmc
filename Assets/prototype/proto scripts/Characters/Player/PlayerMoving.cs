using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    PlayerAnimator anim;
    [SerializeField]
    Transform bottom;
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
    [SerializeField] float botRotateLerpSpeed = 0.6f;
    Vector2 _currentDirection;
    [SerializeField] AnimationCurve startCurve, stopCurve;
    /// <summary>
    /// takes normalized direction and move character on it
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector2 direction)
    {
        //rb.velocity = Vector3.Slerp(Vector3.zero, direction * speed, timer / timeToMaxSpeed);
        //rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);
        _currentDirection = Vector2.Lerp(_currentDirection, direction, botRotateLerpSpeed * Time.deltaTime);
        Vector2 targetMove = _currentDirection * speed * Time.deltaTime;
        rb.MovePosition((Vector2)transform.position + Vector2.Lerp(Vector2.zero, targetMove, startCurve.Evaluate(timer / timeToMaxSpeed)));
        if (direction.magnitude < 0.1f)
        {
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 10 * Time.deltaTime);
            targetMove = _currentDirection * speed * Time.deltaTime;
            rb.MovePosition((Vector2)transform.position + Vector2.Lerp(targetMove, Vector2.zero, stopCurve.Evaluate(backTimer / timeToNullSpeed)));
            anim.isWalk = false;
            timer = 0f;
            backTimer += Time.deltaTime;
            return;
        }
        backTimer = 0f;
        timer += Time.deltaTime;
        anim.isWalk = true;
        float angle = Vector2.SignedAngle(Vector3.up, _currentDirection);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        bottom.rotation =
        Quaternion.Slerp(bottom.rotation, targetRotation, botRotateLerpSpeed * Time.deltaTime);
    }
}
