using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogue : MonoBehaviour
{
    ListAudio list;
    LevelManager manager;
    [SerializeField] TMP_Text textDisplay;
    [SerializeField] string[] dialogues;
    [SerializeField] float typingSpeed = 0.02f;

    [SerializeField] GameObject image;
    private int _index;

    [SerializeField] GameObject popUP;

    public bool activateDialogueState = true;



    [SerializeField] GameObject continueButton;


    void Start(){
        StartCoroutine(Typing());
        list = FindObjectOfType<ListAudio>();
        manager = FindObjectOfType<LevelManager>();
    }

    void Update(){
        if(textDisplay.text == dialogues[_index]){
            continueButton.SetActive(true);
        }
    }

    IEnumerator Typing(){
        yield return new WaitForSeconds(1f);
        list.PlayOnce(52+_index);

        foreach(char letter in dialogues[_index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Continue(){

        continueButton.SetActive(false);
        if(_index<dialogues.Length-1){
            if(!activateDialogueState){
                image.SetActive(true);
                _index++;
                textDisplay.text = "";
                StartCoroutine(Typing());
                activateDialogueState = true;
            }
            else if(activateDialogueState){
                textDisplay.text = "";
                popUP.SetActive(true);
                image.SetActive(false);
            }  
        }
        else{
            manager.LoadScene(0);
        }
    }
}

