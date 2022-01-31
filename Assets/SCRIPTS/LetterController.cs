using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    VoiceRecognition _voice;
    bool isEnabled;

    private void Awake()
    {
        _voice = GetComponent<VoiceRecognition>();
        _voice.enabled = false;
    }

    GameObject[] letters;
    private void Update()
    {
        letters = GameObject.FindGameObjectsWithTag("box");
        Debug.Log(letters.Length);

        if (letters.Length < 1 && !isEnabled)
        {
            _canvas.SetActive(true);
            _voice.enabled = true;
            isEnabled = true;
        }
    }
}
