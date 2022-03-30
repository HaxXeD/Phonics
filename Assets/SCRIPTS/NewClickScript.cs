using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class NewClickScript : MonoBehaviour,IPointerDownHandler
{
    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;
    ListAudio sounds;
    Checker pressed;
    [SerializeField] int audioIndex;

     
    Vector2 slotPosition;
    Vector2 finalRotation;

    private void Start(){
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        sounds = FindObjectOfType<ListAudio>();
        slotPosition = Vector2.up*2;
        finalRotation = Vector3.zero;
        pressed = FindObjectOfType<Checker>();
    }

    public void OnPointerDown(PointerEventData eventData){
        if(!pressed.ReturnIsPressed()){
            pressed.SetIsPressed(true);
            gameObject.transform.SetSiblingIndex(1000);
            gameObject.LeanMove(slotPosition,0.5f).setEaseInOutCirc().setOnComplete(MakeBig);
            gameObject.LeanRotate(finalRotation, 0.5f).setEaseInOutCirc();
            sounds.PlayOnce(audioIndex);
            StartCoroutine(DestroyGameObject());
        }
    }

    IEnumerator DestroyGameObject(){
        yield return new WaitForSeconds(3f);
        pressed.SetIsPressed(false);
        Destroy(gameObject); 
    }

    private void MakeBig(){
        gameObject.LeanScale(Vector2.one*2f,0.5f);
    }
}
