using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class Logo : MonoBehaviour
{
    private VideoPlayer video;
    private void Start()
    {
        video = gameObject.GetComponent<VideoPlayer>();
    }
    void Update()
    {
        if (video.isPaused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
