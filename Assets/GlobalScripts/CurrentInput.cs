using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentInput : MonoBehaviour
{
    public static InputType currentInputType;
    [SerializeField]
    InputType typeForEditor;
    void Start()
    {
#if UNITY_ANDROID
        currentInputType = InputType.androidJoystick;
        Application.targetFrameRate = 30;
#elif UNITY_STANDALONE
        currentInputType = InputType.pcKeyboard;
        Application.targetFrameRate = 60;
#else
        currentInputType = InputType.pcKeyboard;
#endif
#if UNITY_EDITOR
        Application.targetFrameRate = -1;
        currentInputType = typeForEditor;
#endif
    }

    public static void SetInputType(InputType type) => currentInputType = type;

}

public enum InputType
{
    androidJoystick,
    pcKeyboard
}

