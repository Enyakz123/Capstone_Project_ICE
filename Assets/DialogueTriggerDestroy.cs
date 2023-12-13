using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueTriggerDestroy : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private PlayableDirector timeline;

    private void Start()
    {
        if (timeline == null)
        {
            // If timeline is not set, get it from this object
            timeline = GetComponent<PlayableDirector>();
        }

        // Register the OnTimelineFinished method as a delegate to the timeline's finished event
        timeline.stopped += OnTimelineFinished;
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            // Play the timeline
            timeline.Play();
            // Enter dialogue mode
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            // Disable the collider so that the trigger doesn't get activated again
            GetComponent<BoxCollider2D>().enabled = false;
        }    
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        // Destroy the object that contains this script when the timeline is finished
        Destroy(gameObject);
    }
}
