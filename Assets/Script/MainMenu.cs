using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject [] Stage;
    private int activeStageIndex;

    public void PlayGame()
    {
        activeStageIndex = GetActiveStageIndex();
        SceneManager.LoadScene(activeStageIndex);
        AudioManager.Instance.musicSource.Stop();
    }

    private int GetActiveStageIndex()
    {
        for (int i = 0; i < Stage.Length; i++)
        {
            if (Stage[i].activeSelf)
            {
                return i + 1;
            }
        }
        return 1;
    }
}
