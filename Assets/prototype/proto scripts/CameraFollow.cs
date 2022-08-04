using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    static bool isFirst = true;
    [SerializeField] Transform folowedObj;
    [SerializeField] float folowingSpeed = 1f;
    void Start()
    {
        if (isFirst)
        {
            DontDestroyOnLoad(gameObject);
            isFirst = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3
        (transform.position.x,
        folowedObj.position.y + folowingSpeed,
        transform.position.z);
    }
}
