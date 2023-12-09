using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    public void OnVideoFinished(VideoPlayer source)
    {
        SceneManager.LoadSceneAsync(3);
    }
}
