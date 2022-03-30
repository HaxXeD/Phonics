using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // [SerializeField] GameObject _loaderCanvas;
    // [SerializeField] Image _progressBar;

    public void LoadScene(int sceneIndex)
    {
        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        // scene.allowSceneActivation = false;

    //     _loaderCanvas.SetActive(true);

    //     do
    //     {
    //         await Task.Delay(100);
    //         _progressBar.fillAmount = scene.progress;
    //     }
    //     while (scene.progress < 0.9f);

    //     scene.allowSceneActivation = true;
    //     _loaderCanvas.SetActive(false);
    }
}

