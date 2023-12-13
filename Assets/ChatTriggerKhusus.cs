using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class ChatTriggerKhusus : MonoBehaviour
{
    [SerializeField]private GameObject notif;
    [SerializeField]private TextAsset inkJSON;
    [SerializeField]private PlayableDirector Timeline;

    private bool PlayerInRange;
    private void Awake() {
        notif.SetActive(false);
        PlayerInRange = false;
    }

    private void Update() {
        if (PlayerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            notif.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                Timeline.Play();
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            notif.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == ("Player"))
        {
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == ("Player"))
        {
            PlayerInRange = false;
        }
    }
}
