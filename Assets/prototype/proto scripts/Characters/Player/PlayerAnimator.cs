using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    bool prevIsWalk = false;
    public bool isWalk = false;

    bool isHelmet = false;
    bool canChangeHelmet = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isWalk != prevIsWalk)
        {
            prevIsWalk = isWalk;
            animator.SetBool("isWalk", isWalk);
        }

        if (Input.GetKeyDown(KeyCode.G)) animator.SetTrigger("takeGun");

        if (Input.GetKeyDown(KeyCode.H))
        {
            HelmetChange();
        }
    }
    public void HelmetChange()
    {
        if (canChangeHelmet)
        {
            isHelmet = !isHelmet;
            canChangeHelmet = false;
            animator.SetTrigger(isHelmet ? "helmetDown" : "helmetUp");
            StartCoroutine(HelmetDelay());
        }
    }

    IEnumerator HelmetDelay()
    {
        yield return new WaitForSeconds(1f);
        canChangeHelmet = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "HelmetDown")
        {
            animator.SetTrigger("helmetDown");
        }
        if (other.gameObject.name == "GunUp")
        {
            animator.SetTrigger("takeGun");
        }
    }
}
