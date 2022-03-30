using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAudio : MonoBehaviour
{
    [SerializeField] List<AudioClip> gameSounds = new List<AudioClip>();
    //[SerializeField] AudioSource carSound;
    AudioSource audioSource;
    AudioClip _clip;
    // [SerializeField] int orderList = 1;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int i)
    {
        audioSource.clip = gameSounds[i];
        audioSource.Play();
    }

    public void Hover()
    {
        audioSource.clip = gameSounds[28];
        audioSource.Play();
    }

    public void Click()
    {
        audioSource.clip = gameSounds[27];
        audioSource.Play();
    }

    public void PlayOnce(int i){
        _clip = gameSounds[i];
        audioSource.clip = _clip;
        audioSource.PlayOneShot(audioSource.clip);
    }
}
