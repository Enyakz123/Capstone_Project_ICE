using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int Scene;
    public void PlayGame()
    {
        SceneManager.LoadScene(Scene);
        AudioManager.Instance.musicSource.Stop();
    }
}
