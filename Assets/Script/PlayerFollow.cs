using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Pemain yang akan diikuti oleh objek
    private Vector3 offset; // Perbedaan posisi antara objek dan pemain

    public Vector3 customScale = new Vector3(0.119135827f, 0.114318356f, 1f); // Skala khusus untuk objek

    void Start()
    {
        // Menghitung perbedaan posisi pada awal permainan
        if (player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Menghitung posisi target objek mengikuti pemain dengan offset
            Vector3 desiredPosition = player.position + offset;

            // Mengatur posisi objek sesuai dengan posisi yang telah dihitung
            transform.position = desiredPosition;

            // Menentukan arah gerakan pemain
            float playerDirection = player.localScale.x;

            // Mengatur arah objek berdasarkan arah gerakan pemain
            transform.localScale = new Vector3(playerDirection * customScale.x, customScale.y, customScale.z);
        }
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FollowPlayer : MonoBehaviour
// {
//     public Transform player; // Pemain yang akan diikuti oleh objek
//     private Vector3 offset; // Perbedaan posisi antara objek dan pemain
//     private bool shouldFollow = true; // Menentukan apakah objek harus mengikuti pemain atau tidak
//     private float waitDistance = 2f; // Jarak yang harus dijaga antara objek dan pemain
//     public Vector3 customScale = new Vector3(0.119135827f, 0.114318356f, 1f); // Skala khusus untuk objek

//     void Start()
//     {
//         if (player != null)
//         {
//             // Menghitung perbedaan posisi pada awal permainan
//             offset = transform.position - player.position;
//         }
//     }

//     void LateUpdate()
//     {
//         if (player != null)
//         {
//             // Menentukan arah gerakan pemain
//             float playerDirection = Mathf.Sign(player.localScale.x);

//             // Jika objek harus mengikuti pemain
//             if (shouldFollow)
//             {
//                 // Cek apakah pemain ke kanan dan posisi x player kurang dari posisi x objek
//                 if (playerDirection > 0 && player.position.x < transform.position.x)
//                 {
//                     shouldFollow = false; // Objek berhenti mengikuti
//                 }

//                 // Cek apakah pemain ke kiri dan posisi x player lebih dari posisi x objek
//                 else if (playerDirection < 0 && player.position.x > transform.position.x)
//                 {
//                     shouldFollow = false; // Objek berhenti mengikuti
//                 }

//                 // Jika pemain sudah cukup jauh, objek mulai mengikuti kembali
//                 else if (Mathf.Abs(player.position.x - transform.position.x) > waitDistance)
//                 {
//                     shouldFollow = true;
//                 }

//                 // Menghitung posisi objek mengikuti pemain dengan offset
//                 Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);

//                 // Mengatur posisi objek sesuai dengan posisi yang telah dihitung
//                 transform.position = targetPosition;

//                 // Mengatur skala objek berdasarkan arah gerakan pemain
//                 transform.localScale = new Vector3(playerDirection * customScale.x, customScale.y, customScale.z);
//             }
//         }
//     }
// }

