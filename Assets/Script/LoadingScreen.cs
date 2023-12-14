using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private int scene;

    private void Start() {
        timeline.stopped += OnTimelineStopped;
        timeline.Play();
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        if (timeline == director)
        {
            timeline.stopped -= OnTimelineStopped;
            SceneManager.LoadSceneAsync(scene);
        }
    }
}
