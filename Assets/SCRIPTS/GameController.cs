using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    public void ChangeScene(int sceneIndex)
    {
        levelManager.LoadScene(sceneIndex);
    }

    public void ReloadScene()
    {
        levelManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
