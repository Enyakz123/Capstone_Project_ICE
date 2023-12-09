using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChatTrigger : MonoBehaviour
{
    [SerializeField]private GameObject notif;
    [SerializeField]private TextAsset inkJSON;
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
