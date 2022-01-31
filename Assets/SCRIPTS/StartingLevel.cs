using UnityEngine;
using UnityEngine.SceneManagement;
using Chimpvine.WebClient;

public class StartingLevel : MonoBehaviour
{ 
    public void PassingStartingLevel(string _level)
    {
        ChimpvineRestClient.SendGameStartRequest(_level);
    }
    public void PassingUpdateLevel(string _level, int _score)
    {
        ChimpvineRestClient.SendGameUpdateRequest(_level, _score);  
    }
}

