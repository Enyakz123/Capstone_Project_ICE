using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private PlayableDirector Timeline;

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            Timeline.Play();
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            GetComponent<BoxCollider2D>().enabled = false;
        }    
    }
}
