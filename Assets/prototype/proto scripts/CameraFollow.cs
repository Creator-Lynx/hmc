using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform folowedObj;
    [SerializeField] float folowingSpeed = 1f;
    void Start()
    {

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
