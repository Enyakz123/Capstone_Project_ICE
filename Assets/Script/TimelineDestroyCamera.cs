using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using Cinemachine;

public class TimelineDestroyCamera : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public CinemachineBrain cinemachineBrain; // Assign your CinemachineBrain object to this field in the Inspector

    private void Start()
    {
        if (playableDirector == null)
        {
            // If playableDirector is not set, get it from this object
            playableDirector = GetComponent<PlayableDirector>();
        }

        // Register the OnTimelineFinished method as a delegate to the timeline's finished event
        playableDirector.stopped += OnTimelineFinished;
    }

    private void OnTimelineFinished(PlayableDirector aDirector)
    {
        // Destroy CinemachineBrain component when the timeline is finished
        DestroyCinemachineBrain();
    }

    private void DestroyCinemachineBrain()
    {
        if (cinemachineBrain != null)
        {
            // Destroy the CinemachineBrain component
            Destroy(cinemachineBrain);
        }
        else
        {
            Debug.LogWarning("CinemachineBrain object reference is not set in the inspector.");
        }
    }
}
