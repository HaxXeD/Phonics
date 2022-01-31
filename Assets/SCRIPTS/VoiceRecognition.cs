using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;
using Chimpvine.WebClient;

public class VoiceRecognition : MonoBehaviour
{
    LevelManager levelManager;
    int nextSceneIndex;
    int currentScene;
    string currentSceneName;
    ListAudio sounds;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    //GameObject _timer;
    timer _timer;

    //private void Update()
    //{
    //    _timer = GameObject.FindGameObjectWithTag("timer");
    //}

    private void Awake() => sounds = FindObjectOfType<ListAudio>();
    
    
    private void Start()
    {
        _timer = FindObjectOfType<timer>();
        _timer.OnTimerEnd += DisableScript;
        levelManager = FindObjectOfType<LevelManager>(); 
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentScene + 1;
        //actions.Add("forwad",Forward);
        //actions.Add("back", Back);
        //actions.Add("up", Up);
        //actions.Add("down", Down);

        switch (currentScene)
        {
            case 2:
                actions.Add("apple", Apple);
                break;
            case 3:
                actions.Add("water", Water);
                break;
            case 4:
                actions.Add("cloud", Cloud);
                break;
            case 5:
                actions.Add("camel", Camel);                
                break;
            case 6:
                actions.Add("house", House);
                break;
            case 7:
                actions.Add("santa", Santa);                
                break;
            case 8:
                actions.Add("umbrella", Umbrella);                
                break;
            case 9:
                actions.Add("volleyball", Volleyball);
                break;
            case 10:
                actions.Add("computer", Computer);
                break;
        }    

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    private void Computer() => StartCoroutine(DelayAndLoadNextScene());

    private void Santa() => StartCoroutine(DelayAndLoadNextScene());

    private void Volleyball() => StartCoroutine(DelayAndLoadNextScene());

    private void Umbrella() => StartCoroutine(DelayAndLoadNextScene());

    private void Camel() => StartCoroutine(DelayAndLoadNextScene());

    private void House() => StartCoroutine(DelayAndLoadNextScene());

    private void Cloud() => StartCoroutine(DelayAndLoadNextScene());

    private void Water() => StartCoroutine(DelayAndLoadNextScene());

    private void Apple() => StartCoroutine(DelayAndLoadNextScene());

    private void RecognizedSpeech(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        actions[args.text].Invoke();
    }

    IEnumerator DelayAndLoadNextScene()
    {
        _timer.PauseTimer(false);
        int score = _timer.returnTime();
        sounds.PlaySound(26);
        yield return new WaitForSeconds(3);

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            levelManager.LoadScene(11); 
        }
        else
        {            
            ChimpvineRestClient.SendGameUpdateRequest(currentScene.ToString(), score); /*Tecnically next scene,as level one is indexed as 2 */
             levelManager.LoadScene(nextSceneIndex);
            if (nextSceneIndex > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneIndex);
            }
        }
      
    }

    void DisableScript()
    {
        this.enabled = false;
    }



    //private void Down()
    //{
    //    transform.Translate(0, -1,0);
    //}

    //private void Up()
    //{
    //    transform.Translate(0, 1, 0);
    //}

    //private void Back()
    //{
    //    transform.Translate(-1, 0, 0);
    //}

    //private void Forward()
    //{
    //    transform.Translate(1, 0, 0);
    //}


}
