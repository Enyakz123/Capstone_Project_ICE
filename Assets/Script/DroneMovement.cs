using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerak drone
    public Vector3 customScale = new Vector3(0.119135827f, 0.114318356f, 1f); // Skala khusus untuk drone

    private Animator anim;

    void Start()
    {
        // Mendapatkan komponen Animator pada drone
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Mendapatkan input dari pemain
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Menghitung pergerakan drone
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Mengubah posisi drone
        transform.Translate(movement);

        // Mengubah arah sprite berdasarkan arah gerakan
        if (horizontalInput > 0)
        {
            // Jika gerakan ke kanan, mengatur skala sprite sesuai dengan arah gerakan
            transform.localScale = new Vector3(customScale.x, customScale.y, customScale.z);
        }
        else if (horizontalInput < 0)
        {
            // Jika gerakan ke kiri, mengatur skala sprite sesuai dengan arah gerakan
            transform.localScale = new Vector3(-customScale.x, customScale.y, customScale.z);
        }

        // Mengatur kecepatan animasi berdasarkan kecepatan pergerakan drone
        float speed = Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput);
        anim.SetFloat("Speed", speed);
    }
}
