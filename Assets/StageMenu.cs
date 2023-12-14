using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    [SerializeField] private Button [] stageIndex;
    
    private void Awake() {
        int UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < stageIndex.Length; i++)
        {
            stageIndex[i].interactable = false;
        }
        for (int i = 0; i < UnlockedLevel; i++)
        {
            stageIndex[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
