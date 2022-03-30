using UnityEngine;
using Chimpvine.WebClient;


public class StartingLevel : MonoBehaviour
{
    LevelController levelController;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    public void PassingStartingLevel(string _level)
    {
        ChimpvineRestClient.SendGameStartRequest(_level);
    }
    public void PassingUpdateLevel(string _level, int _score)
    {
        ChimpvineRestClient.SendGameUpdateRequest(_level, _score);
    }

    public void PassCurrentLevel(){
        ChimpvineRestClient.SendGameUpdateRequest(levelController.ReturnCurrentScene().ToString(),0);
    }

}

