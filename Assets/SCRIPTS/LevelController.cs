using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    LevelManager levelManager;

    int _currentSceneIndex, _nextSceneIndex;

    void Start(){
        levelManager = FindObjectOfType<LevelManager>();
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _nextSceneIndex = _currentSceneIndex+1;
    }

    public int ReturnCurrentScene(){
        return _currentSceneIndex;
    }

    public int ReturnNextScene(){
        return _nextSceneIndex;
    }
    public void FindSceneIndex()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        print(_currentSceneIndex);
        _nextSceneIndex = _currentSceneIndex+1;
    }
    public void ChangeScene(int sceneIndex)
    {
        levelManager.LoadScene(sceneIndex);
    }

    public void ReloadScene()
    {
        FindSceneIndex();
        levelManager.LoadScene(_currentSceneIndex);   
    }

    public void NextScene(){
        FindSceneIndex();
        levelManager.LoadScene(_nextSceneIndex);
    }
}
