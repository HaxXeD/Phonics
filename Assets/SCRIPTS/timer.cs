using System;
using UnityEngine;
using UnityEngine.UI;
using Chimpvine.WebClient;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class timer : MonoBehaviour
{
    public event Action OnTimerEnd;
    [SerializeField] AudioClip _tick;
    SettingButtons setting;
    ListAudio sound;
    Text text;
    AudioSource audioSource;
    float _timeRemaining = 31f;
    bool _timerIsRunning = false;
    int _time;
    int _currentScene;

    public int returnTime()
    {
        return _time;
    }

    public void PauseTimer(bool time)
    {
        _timerIsRunning = time;
    }

    private void Awake()
    {
        sound = FindObjectOfType<ListAudio>();
        audioSource = GetComponent<AudioSource>();
        setting = FindObjectOfType<SettingButtons>();
        _currentScene = SceneManager.GetActiveScene().buildIndex - 1; 
    }
    private void Start()
    {
        
        text = GetComponent<Text>();
        // Starts the timer automatically
        _timerIsRunning = true;
    }

    void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {                
                _time = (int)_timeRemaining;                
                text.text = _time.ToString();
                              
                print(_time);
                _timeRemaining -= Time.deltaTime;
                int oldTime = (int)_timeRemaining;
                if (_time - oldTime == 1)
                {
                    audioSource.PlayOneShot(_tick, 1f);
                }
                if (_timeRemaining < 11 && _timeRemaining > 6)
                    text.color = Color.yellow;
                else if (_timeRemaining < 6)
                    text.color = Color.red;
            }
            else
            {
                OnTimerEnd?.Invoke();
                ChimpvineRestClient.SendGameUpdateRequest(_currentScene.ToString(),_time);
                setting.ShowGameOverUI();
                sound.PlaySound(34);
                _timeRemaining = 0;
               _timerIsRunning = false;
            }
        }
    }
}