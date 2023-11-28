using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player"))
        {
            SceneController.instance.NextLevel();
        }
    }
}
