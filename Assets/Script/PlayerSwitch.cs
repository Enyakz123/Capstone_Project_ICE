// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerSwitch : MonoBehaviour
// {
//     public Movement playerController;
//     public DroneMovement player2Controller;
//     public bool player1Active = true;

//     // Start is called before the first frame update
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             SwitchPlayer();
//         }
//     }

//     public void SwitchPlayer()
//     {
//         if (player1Active == true)
//         {
//             playerController.enabled = false;
//             player2Controller.enabled = true;
//             player1Active = false;
//         }
//         else
//         {
//             playerController.enabled = true;
//             player2Controller.enabled = false;
//             player1Active = true;
//         }
//     }
// }

//INI YANG DIPAKE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public Movement playerController;
    public DroneMovement player2Controller;
    public bool player1Active = true;
    public FollowPlayer scriptA;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchPlayer();
        }
    }

    public void SwitchPlayer()
    {
        if (player1Active)
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            player1Active = false;
            scriptA.enabled = false;
        }
        else
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player1Active = true;
            scriptA.enabled = true;
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerSwitch : MonoBehaviour
// {
//     public Movement playerController;
//     public DroneMovement player2Controller;
//     public bool player1Active = true;
//     public MonoBehaviour scriptA; // Gantilah MonoBehaviour dengan tipe script 'a' yang sesuai

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             SwitchPlayer();
//         }
//     }

//     public void SwitchPlayer()
//     {
//         if (player1Active)
//         {
//             // Aktifkan playerController dan nonaktifkan player2Controller
//             playerController.enabled = true;
//             player2Controller.enabled = false;

//             // Menghentikan pergerakan pada sumbu X (freeze)
//             playerController.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, playerController.GetComponent<Rigidbody2D>().velocity.y);

//             player1Active = false;
//         }
//         else
//         {
//             // Nonaktifkan playerController dan aktifkan player2Controller
//             playerController.enabled = false;
//             player2Controller.enabled = true;

//             // Menonaktifkan script 'a'
//             scriptA.enabled = false;

//             player1Active = true;
//         }
//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerSwitch : MonoBehaviour
// {
//     public Movement playerController;
//     public DroneMovement player2Controller;
//     public bool player1Active = true;
//     public MonoBehaviour scriptA; // Gantilah MonoBehaviour dengan tipe script 'a' yang sesuai

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             SwitchPlayer();
//         }
//     }

//     public void SwitchPlayer()
//     {
//         if (player1Active)
//         {
//             playerController.enabled = false;
//             player2Controller.enabled = true;
//             player1Active = false;
//         }
//         else
//         {
//             playerController.enabled = true;
//             player2Controller.enabled = false;
//             player1Active = true;

//             // Menonaktifkan script 'a'
//             scriptA.enabled = false;
//         }
//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerSwitch : MonoBehaviour
// {
//     public Movement playerController;
//     public DroneMovement player2Controller;
//     public bool player1Active = true;
//     public FollowPlayer scriptA;

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             SwitchPlayer();
//         }
//     }

//     public void SwitchPlayer()
//     {
//         if (player1Active)
//         {
//             playerController.enabled = false;
//             player2Controller.enabled = true;
//             player1Active = false;
//             scriptA.player = player2Controller.transform; // Mengubah target kamera ke player 2
//         }
//         else
//         {
//             playerController.enabled = true;
//             player2Controller.enabled = false;
//             player1Active = true;
//             scriptA.player = playerController.transform; // Mengubah target kamera ke player 1
//         }
//     }
// }
