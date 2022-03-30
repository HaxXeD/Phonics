using System;
using UnityEngine;
using UnityEngine.UI;
using Chimpvine.WebClient;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    [SerializeField]Image Timer;
    public event Action OnTimerEnd;

    LevelController levelController;
    SettingButtons setting;
    ListAudio sound;
    Text text;
    float _timeRemaining = 61f;
    float _timerFullTime;
    bool _timerIsRunning = false;
    int _time;

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
        setting = FindObjectOfType<SettingButtons>();
        levelController = FindObjectOfType<LevelController>();
    }
    private void Start()
    {
        _timerFullTime = _timeRemaining;
        Timer.fillAmount = 1;   
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
                Timer.fillAmount = (_timeRemaining/_timerFullTime);
                print(Timer.fillAmount);
                _time = (int)_timeRemaining;                
                text.text = _time.ToString();
                              
                print(_time);
                _timeRemaining -= Time.deltaTime;
                int oldTime = (int)_timeRemaining;
                if (_time - oldTime == 1)
                {
                    // audioSource.PlayOneShot(_tick, 1f);
                    sound.PlayOnce(35);
                }
            }
            else
            {
                OnTimerEnd?.Invoke();
                ChimpvineRestClient.SendGameUpdateRequest(levelController.ReturnCurrentScene().ToString(),0);
                setting.ShowGameOverUI();
                sound.PlaySound(34);
                _timeRemaining = 0;
               _timerIsRunning = false;
            }
        }
    }
}