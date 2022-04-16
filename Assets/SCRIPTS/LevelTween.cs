using UnityEngine;

public class LevelTween : MonoBehaviour
{
    [SerializeField] CanvasGroup backgroundImage;
    [SerializeField] GameObject LevelSelection;
    [SerializeField] GameObject home;




    public void OnEnable(){
        LevelSelection.transform.localScale = Vector3.zero;  
        gameObject.transform.localPosition = new Vector3(Screen.width+200,0,0); 
        home.transform.localPosition = Vector3.zero; 
        backgroundImage.alpha = 0;
        home.transform.LeanMoveLocalX(-Screen.width-200,0.5f).setEaseInQuad().setOnComplete(ActiveSelectionScreen);
        gameObject.LeanMoveLocalX(0,0.5f).setEaseInQuad();
        LevelSelection.LeanScale(Vector3.one,0.5f).setEaseInQuad();
              
    }
    void ActiveSelectionScreen(){ 
        backgroundImage.LeanAlpha(1,.2f);
        home.SetActive(false);
    }

    void OnSet(){

    }

    public void OnClose(){ 
        home.SetActive(true);       
        LevelSelection.LeanScale(Vector3.zero,0.5f).setOnComplete(OnComplete);    
        backgroundImage.LeanAlpha(0,.5f);   
        home.transform.LeanMoveLocalX(0,0.5f).setEaseInQuad();   
    }

    void OnComplete(){  
        gameObject.LeanMoveLocalX(Screen.width+200,0.5f).setEaseInQuad();        
        gameObject.SetActive(false);
    }
}

