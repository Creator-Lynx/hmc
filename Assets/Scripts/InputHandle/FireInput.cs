using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireInput : MonoBehaviour, IPointerDownHandler
{
    static FireInput instance;
    bool isFire = false;
    bool isDelayed = false;

    private void Start()
    {
        instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isDelayed)
        {
            isFire = true;
            StartCoroutine(ShootDelay());
        }

    }

    IEnumerator ShootDelay()
    {
        isDelayed = true;
        yield return new WaitForSeconds(0.7f);
        isDelayed = false;

    }

    public static bool GetFireInput()
    {
        if (instance.isFire)
        {
            instance.isFire = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
