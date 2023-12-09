using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public bool dialogueIsPlaying{ get; private set; }
    private bool canContinueToNextLine = false;
    private static DialogueManager instance;
    private Story currentStory;

    private const string SPEAKER_TAG = "speaker";
    private const string LAYOUT_TAG = "layout";
    private const string SCENE_TAG = "scene";
    private Coroutine displayLineCoroutine;
    private void Awake() 
{
    if (instance != null && instance != this)
    {
        Debug.LogWarning("Found more than one Dialogue Manager in the scene. Destroying the new one.");
        Destroy(gameObject);
    }
    else
    {
        instance = this;
    }
}

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start() 
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update() 
    {
        // //Menyembunyikan Cursor
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine
            && InputManager.GetInstance().GetSubmitPressed()
            && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //reset Layout dan Speaker
        displayNameText.text = "???";
        layoutAnimator.Play("left");
        
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        continueIcon.SetActive(false);
        HideChoices();
        canContinueToNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
            if (InputManager.GetInstance().GetSubmitPressed())
            {
                dialogueText.text = line;
                break;
            }
            
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueIcon.SetActive(true);
        DisplayChoices();
        canContinueToNextLine = true;
    }

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parse: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case SCENE_TAG:
                    if (splitTag.Length >= 2)
                    {
                        string sceneValue = splitTag[1].Trim();
                        // SceneManager.LoadSceneAsync(sceneValue);
                    }
                    else
                    {
                        Debug.LogError("Invalid SCENE_TAG format: " + tag);
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                    break;
            }
        }
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.1f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        string sceneToLoad = "";  // Variabel untuk menyimpan nilai scene

        // Tambahkan logika untuk mendapatkan nilai scene dari tag SCENE_TAG yang terakhir
        foreach (string tag in currentStory.currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length >= 2 && splitTag[0].Trim() == SCENE_TAG)
            {
                sceneToLoad = splitTag[1].Trim();
                break;  // Keluar dari loop setelah menemukan tag SCENE_TAG
            }
        }

        // Memuat scene jika nilai sceneToLoad tidak kosong
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No SCENE_TAG found or invalid format. No scene loaded.");
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        //cek apakah UI support dengan jumlah choice yang ada
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Choices yang diberikan melebihi UI. Jumlah choices sebanyak: " + currentChoices.Count);
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        
    }
}
