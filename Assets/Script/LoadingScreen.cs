// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// public class LoadingScreen : MonoBehaviour
// {
//     void Start() 
//     {
//         StartCoroutine(Loading());
//     }
//     public Image loadingFill;
//     IEnumerator Loading()
//     {
//         AsyncOperation loading = SceneManager.LoadSceneAsync(2);
//         while (!loading.isDone)
//         {
//             loadingFill.fillAmount = loading.progress/0.9f;
//             print(loading.progress);
//             yield return null;
//         }
        
//     }
// }
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image loadingFill;
    public float fillSpeed = 0.5f; // Atur kecepatan pengisian di sini
    public float delayTime = 2.0f; // Waktu delay sebelum mulai mengisi

    void Start() 
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(delayTime); // Menambahkan waktu delay sebelum mulai mengisi

        AsyncOperation loading = SceneManager.LoadSceneAsync(2);
        while (!loading.isDone)
        {
            loadingFill.fillAmount += fillSpeed * Time.deltaTime; // Menggunakan Time.deltaTime untuk mengontrol kecepatan
            print(loadingFill.fillAmount);
            yield return null;
        }
    }
}
