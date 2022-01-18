
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("CameraMove")]
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 ZoomOffset;

    void FixedUpdate()
    {
        //Camera Follow
        Vector3 desiredPosition = target.position + ZoomOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}