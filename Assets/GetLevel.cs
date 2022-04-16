using UnityEngine;
using TMPro;

public class GetLevel : MonoBehaviour
{
    LevelController levelController;
    TMP_Text tMP_Text;
    // Start is called before the first frame update
    void Start()
    {
        levelController  = FindObjectOfType<LevelController>();
        tMP_Text  = GetComponent<TMP_Text>();
        levelController.FindSceneIndex();
        tMP_Text.text = "Level " + levelController.ReturnCurrentScene(); 
    }


}
