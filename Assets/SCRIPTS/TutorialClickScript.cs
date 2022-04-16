using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TutorialClickScript : MonoBehaviour,IPointerDownHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;
    ListAudio sounds;
    [SerializeField] int audioIndex;
    Vector2 slotPosition;
    Vector2 finalRotation;


    bool isPressed = false;

    public bool isSet = false;

    private void Start(){
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        sounds = FindObjectOfType<ListAudio>();
        slotPosition = Vector2.up*2;
        finalRotation = Vector3.zero;
        try{
            Invoke("SetPointerActive",5f);
        }
        catch{

        }
    }

    public void OnPointerDown(PointerEventData eventData){
        if(!isPressed){
            isPressed = true;
            gameObject.transform.SetSiblingIndex(1000);
            gameObject.LeanMove(slotPosition,0.5f).setEaseInOutCirc().setOnComplete(MakeBig);
            gameObject.LeanRotate(finalRotation, 0.5f).setEaseInOutCirc();
            sounds.PlayOnce(audioIndex);
            Invoke("DestroyGameObject",3f);
            try{
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            catch{

            }
        }
    }

    void DestroyGameObject(){        
        print("working");
        isPressed = false;
        isSet = true;
        print(isSet);
        gameObject.SetActive(false);
    }

    private void MakeBig(){
        gameObject.LeanScale(Vector2.one*2f,0.5f);
    }    

    private void SetPointerActive(){
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
