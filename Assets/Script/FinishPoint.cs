using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            timeline.stopped += OnTimelineStopped; // Menambahkan event handler
            timeline.Play();
            // GetComponent<BoxCollider2D>().enabled = false;
        }    
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        if (director == timeline)
        {
            // Hapus event handler agar tidak memicu lagi
            timeline.stopped -= OnTimelineStopped;

            // Pindah ke adegan berikutnya setelah timeline selesai
            SceneManager.LoadSceneAsync(7);
        }
    }
}
