using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        // Gerak ke kanan terus-menerus
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah yang bersentuhan adalah pemain
        if (collision.collider.CompareTag("Player"))
        {
            // Restart scene
            RestartScene();
        }
    }

    private void RestartScene()
    {
        // Mendapatkan indeks scene saat ini
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Memuat ulang scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
