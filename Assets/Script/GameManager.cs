using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    [SerializeField] private GameObject [] Stage;
    [SerializeField] private int scene;
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

    public void TogglePauseScreen()
    {
        if (pauseScreen != null)
        {
            bool isPaused = pauseScreen.activeSelf;
            pauseScreen.SetActive(!isPaused);

            // Pause atau unpause permainan
            Time.timeScale = isPaused ? 1f : 0f;
        }
    }
    public void SceneChanges()
    {
        SceneManager.LoadScene(scene);
    }
}

