using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    static JoystickInput instance;
    [SerializeField] Transform stick;

    /// <summary>
    /// koef; equals real world distance between
    /// centre of joystick and max delta-move of stick
    /// </summary>
    [SerializeField] float radiusK;
    void Start()
    {
        instance = this;
        stickStartPos = stick.position;
    }

    void Update()
    {
        ClampStick();
    }

    Vector2 stickStartPos;
    void ClampStick()
    {
        stick.position = new Vector2(
        Mathf.Clamp(stick.position.x, -radiusK + stickStartPos.x, radiusK + stickStartPos.x),//!!!!!!
        //sin2 + cos2 = 1
        //cos = sqrt(1 - sin2)
        //
        Mathf.Clamp(stick.position.y,
        Mathf.Sqrt(1 - Mathf.Pow((stick.position.x - stickStartPos.x) / radiusK, 2f)),
        -Mathf.Sqrt(1 - Mathf.Pow((stick.position.x - stickStartPos.x) / radiusK, 2f)))
        );

    }

    public static float GetHorizontalAxis()
    {
        return 0;
    }
    public static float GetVerticalAxis()
    {
        return 0;
    }

    public static bool GetFire()
    {
        return false;
    }
}
