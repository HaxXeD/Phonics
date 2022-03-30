using UnityEngine;
using System.Collections;

public class Pronounce : MonoBehaviour
{
    ListAudio _audio;

    void Start(){
        _audio = FindObjectOfType<ListAudio>();
        string Tag;
        Tag = gameObject.tag;
        switch(Tag){
            case "apple":
                StartCoroutine(PlayTagSound(36));
            break;
            case "water":
                StartCoroutine(PlayTagSound(46));
            break;
            case "house":
                StartCoroutine(PlayTagSound(42));
            break;
            case "santa":
                StartCoroutine(PlayTagSound(43));

            break;
            case "cloud":
                StartCoroutine(PlayTagSound(38));

            break;
            case "volleyball":
                StartCoroutine(PlayTagSound(45));

            break;
            case "computer":
                StartCoroutine(PlayTagSound(39));
            break;
            case "camel":
                StartCoroutine(PlayTagSound(37));
            break;
            case "umbrella":
                StartCoroutine(PlayTagSound(44));
            break;
        }            
    }

    IEnumerator PlayTagSound(int _index){
        yield return new WaitForSeconds(1f);
        _audio.PlayOnce(_index);
    }

}
