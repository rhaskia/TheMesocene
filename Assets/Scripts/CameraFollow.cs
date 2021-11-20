
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("CameraMove")]
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 ZoomOffset;


    void Start()
    {
        Camera cam = Camera.main;
    }

    void FixedUpdate()
    {


        Vector3 desiredPosition = target.position + ZoomOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);//smooth, like butter
        transform.position = smoothedPosition;
    }
}