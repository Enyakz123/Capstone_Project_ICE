using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScreen2 : MonoBehaviour
{
    private void Loading()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
