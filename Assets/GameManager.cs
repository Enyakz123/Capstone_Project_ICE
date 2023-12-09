using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseScreen();
        }
    }

    void TogglePauseScreen()
    {
        if (pauseScreen != null)
        {
            bool isPaused = pauseScreen.activeSelf;
            pauseScreen.SetActive(!isPaused);

            // Pause atau unpause permainan
            Time.timeScale = isPaused ? 1f : 0f;
        }
    }
}

