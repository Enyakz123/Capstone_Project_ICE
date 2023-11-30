using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // public Transform target; // Objek yang akan diikuti oleh kamera
    // public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera

    // void LateUpdate()
    // {
    //     if (target != null)
    //     {
    //         // Menghitung posisi target dengan sedikit pergeseran pada sumbu Z
    //         Vector3 desiredPosition = new Vector3(target.position.x, -3, transform.position.z);

    //         // Menggunakan fungsi Lerp untuk membuat pergerakan kamera yang halus
    //         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

    //         // Mengatur posisi kamera sesuai dengan posisi yang telah dihitung
    //         transform.position = smoothedPosition;
    //     }
    // }

    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0,1)] public float smoothTime;
    public Vector3 positionOffset;

    [Header("Axis Limitation")]
    public Vector2 xLimit;
    public Vector2 yLimit;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() 
    {
        Vector3 targetPosition = target.position + positionOffset;
        targetPosition  = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x,yLimit.y), -10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
