using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseSounds : MonoBehaviour
{
    ListAudio sounds;
    Button button;


    private void Awake()
    {
        sounds = FindObjectOfType<ListAudio>();
        button = GetComponent<Button>();
    }

    public void Hover()
    {
        if (button.interactable)
            sounds.Hover();
    }

    public void Click()
    {
        if (button.interactable)
            sounds.Click();
    }
}
