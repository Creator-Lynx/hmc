using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    PlayerMoving _playerMoving;
    Shooting _playerShooting;
    void Start()
    {
        _playerMoving = GetComponent<PlayerMoving>();
        _playerShooting = GetComponent<Shooting>();
    }

    void FixedUpdate()
    {
        _playerMoving.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || JoystickInput.GetFire())
        {
            _playerShooting.Shoot();
        }
    }
}
