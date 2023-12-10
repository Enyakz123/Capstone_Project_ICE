using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class TimelineDestroyObject : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject panelObject; // Assign your panel object to this field in the Inspector

    private void Start()
    {
        if (playableDirector == null)
        {
            // Jika playableDirector tidak di-set, dapatkan dari objek ini
            playableDirector = GetComponent<PlayableDirector>();
        }

        // Daftarkan metode OnTimelineFinished sebagai delegat ke peristiwa selesai dari timeline
        playableDirector.stopped += OnTimelineFinished;
    }

    private void OnTimelineFinished(PlayableDirector aDirector)
    {
        // Hancurkan komponen panel ketika timeline selesai
        DestroyPanel();
    }

    private void DestroyPanel()
    {
        if (panelObject != null)
        {
            // Destroy the panel component
            Destroy(panelObject.GetComponent<Graphic>());
        }
        else
        {
            Debug.LogWarning("Panel object reference is not set in the inspector.");
        }
    }
}
