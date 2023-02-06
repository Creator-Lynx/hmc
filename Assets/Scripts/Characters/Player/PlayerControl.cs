using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    PlayerMoving _playerMoving;
    Shooting _playerShooting;


    void Start()
    {
        Camera.main.GetComponent<CameraFollow>().folowedObj = gameObject.transform;
        _playerMoving = GetComponent<PlayerMoving>();
        _playerShooting = GetComponent<Shooting>();


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || FireInput.GetFireInput())
        {
            _playerShooting.Shoot();
        }
        if (CurrentInput.currentInputType == InputType.pcKeyboard)
        {
            _playerMoving.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        else
        {
            _playerMoving.Move(new Vector2(JoystickInput.GetHorizontalAxis(), JoystickInput.GetVerticalAxis()));
        }
    }
}

