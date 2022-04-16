using UnityEngine;
using TMPro;

public class LevelStateTween : MonoBehaviour
{
    LevelController levelController;
    [SerializeField] GameObject text;
    [SerializeField] CanvasGroup background;

    private void OnEnable(){        
        background.LeanAlpha(1,0.5f);
        text.transform.localPosition = new Vector2(0,-Screen.height);
        text.LeanMoveLocalY(0,0.5f).setEaseOutExpo().delay = 0.1f;

    }

    public void CloseSetting(){
        background.LeanAlpha(0,0.5f);
        text.LeanMoveLocalY(-Screen.height,.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    private void OnComplete(){
        gameObject.SetActive(false);
    }

    private void Update(){        
        levelController = FindObjectOfType<LevelController>();
        levelController.FindSceneIndex();
        text.GetComponent<TMP_Text>().text = "Level " + levelController.ReturnCurrentScene();

        // levelController.OnReload+=UpdateLevel;
    }

    // void UpdateLevel(){
    //     text.GetComponent<TMP_Text>().text = "Level " + levelController.ReturnCurrentScene().ToString();
    // }
}
