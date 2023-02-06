using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    static bool isFirst = true;
    public Transform folowedObj;
    [SerializeField] float folowingSpeed = 1f;
    void Awake()
    {
        folowedObj = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (folowedObj != null)
        {
            transform.position = new Vector3
            (transform.position.x,
            folowedObj.position.y + folowingSpeed,
            transform.position.z);
        }


    }
}
