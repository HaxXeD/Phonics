using UnityEngine;

public class TutorialPopUps : MonoBehaviour
{
    ListAudio _audio;
    [SerializeField] GameObject[] popUps;
    [SerializeField] GameObject[] letters;
    
    // [SerializeField] GameObject pointer;
    [SerializeField] GameObject dialogue;
    private int _popUpIndex;

    float waitTime = 1f;
    bool[] isActive = new bool[2];

    bool pop;

    void Start(){
        _audio = FindObjectOfType<ListAudio>();
    }
    void Update(){
        for(int i = 0;i<popUps.Length;i++){
            if(i==_popUpIndex){
                popUps[_popUpIndex].SetActive(true);
            }else{
                popUps[_popUpIndex].SetActive(false);
            }
        }
        if(_popUpIndex == 0){            
            popUps[0].SetActive(true);
    
            if(!letters[0].activeInHierarchy/*GetComponent<TutorialClickScript>().isSet*/){
                if (waitTime <= 0){
                    _popUpIndex++;
                    popUps[0].SetActive(false);
                    dialogue.GetComponent<Dialogue>().activateDialogueState = false;
                    if(!isActive[1]){
                        dialogue.GetComponent<Dialogue>().Continue();
                        isActive[1] = true;
                    }     
                    waitTime = 1f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                         
            }            
        }
        if(_popUpIndex == 1){
             popUps[1].SetActive(true);
            if(!letters[1].activeInHierarchy&&!letters[2].activeInHierarchy){
                if (waitTime <= 0){
                    popUps[1].SetActive(false);
                    _popUpIndex++;
                    dialogue.GetComponent<Dialogue>().activateDialogueState = false;
                    if(!isActive[0]){
                        dialogue.GetComponent<Dialogue>().Continue();
                        isActive[0] = true;
                    }     
                    waitTime = 1f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                         
            }  
        }

        if(_popUpIndex == 2){
            
        }

        // print(popUps[_popUpIndex]);
        // print(popUps[_popUpIndex].active);
    }
}
