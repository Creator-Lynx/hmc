using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentInput : MonoBehaviour
{
    public static InputType currentInputType;
    void Start()
    {
#if UNITY_ANDROID
        currentInputType = InputType.androidJoystick;
#elif UNITY_STANDALONE
        currentInputType = InputType.pcKeyboard;
#else
        currentInputType = InputType.pcKeyboard;
#endif
#if UNITY_EDITOR
        currentInputType = InputType.androidJoystick;
#endif
    }

    public static void SetInputType(InputType type) => currentInputType = type;

}

public enum InputType
{
    androidJoystick,
    pcKeyboard
}

