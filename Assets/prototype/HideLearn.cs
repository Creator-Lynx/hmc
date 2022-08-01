using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HideLearn : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerPrefs.SetInt("IsLearned", 1);
        Destroy(gameObject);

    }


    private void Awake()
    {
        if (PlayerPrefs.GetInt("IsLearned", 0) == 1)
        {
            Destroy(gameObject);
        }
    }

}
