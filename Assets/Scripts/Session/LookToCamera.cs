using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private Camera myCamera;
    void Awake()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(myCamera.transform.position);
        transform.Rotate(Vector3.up * 180);
    }
}
