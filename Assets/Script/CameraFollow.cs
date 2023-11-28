using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek yang akan diikuti oleh kamera
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera

    void LateUpdate()
    {
        if (target != null)
        {
            // Menghitung posisi target dengan sedikit pergeseran pada sumbu Z
            Vector3 desiredPosition = new Vector3(target.position.x, -3, transform.position.z);

            // Menggunakan fungsi Lerp untuk membuat pergerakan kamera yang halus
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Mengatur posisi kamera sesuai dengan posisi yang telah dihitung
            transform.position = smoothedPosition;
        }
    }
}
