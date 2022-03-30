using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    LevelManager levelManager;

    int _currentSceneIndex, _nextSceneIndex;

    public int ReturnCurrentScene(){
        return _currentSceneIndex;
    }

    public int ReturnNextScene(){
        return _nextSceneIndex;
    }
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _nextSceneIndex = _currentSceneIndex+1;
        
    }
    public void ChangeScene(int sceneIndex)
    {
        levelManager.LoadScene(sceneIndex);
    }

    public void ReloadScene()
    {
        levelManager.LoadScene(_currentSceneIndex);
    }

    public void NextScene(){
        levelManager.LoadScene(_nextSceneIndex);
    }
}
