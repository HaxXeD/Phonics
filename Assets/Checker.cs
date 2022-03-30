using TMPro;
using UnityEngine;
using System.Collections;
using Chimpvine.WebClient;

[RequireComponent(typeof(LevelController))]
public class Checker : MonoBehaviour
{
    TMP_Text counter;

    timer Timer;

    LevelController levelController;
   [SerializeField] GameObject say;
   [SerializeField] GameObject find;
    GameObject[] letters;
    ListAudio audioList;
    // SettingButtons settingButtons;
    // Settings settings;

    bool isEnabled = false;

    bool IsPressed = false;

    public void SetIsPressed(bool value){
        IsPressed = value;
    }

    public bool ReturnIsPressed(){
        return IsPressed;
    }

    // IEnumerator EnableLevelStart(){
    //     settingButtons.ShowLevelStartUI();
    //     yield return new WaitForSeconds(2f);
    //     settingButtons.HideLevelStartUI();
    // }
    
    private void Start(){
        // settingButtons = FindObjectOfType<SettingButtons>();
        // settings.levelStartUI().transform.GetChild(0).GetComponent<TMP_Text>().text = "Level " + levelController.ReturnCurrentScene().ToString();
        // StartCoroutine(EnableLevelStart());
        counter = GameObject.FindGameObjectWithTag("counter").GetComponent<TMP_Text>();
        audioList = FindObjectOfType<ListAudio>();
        levelController = FindObjectOfType<LevelController>();    
        Timer = FindObjectOfType<timer>();    
    }

    private void Update()
    {
        letters = GameObject.FindGameObjectsWithTag("letters");
        Debug.Log(letters.Length);
        counter.text = letters.Length.ToString();

        if (letters.Length < 1 && !isEnabled)
        {
            find.SetActive(false);
            Timer.PauseTimer(false);
            StartCoroutine(SetFindActive());
            isEnabled = true;
        }
    }

    IEnumerator SetFindActive(){
        say.SetActive(true);
        // audio.PlayOnce();
        yield return new WaitForSeconds(3);
        levelController.NextScene();ChimpvineRestClient.SendGameUpdateRequest(levelController.ReturnNextScene().ToString(), (int)Timer.returnTime());
        if (levelController.ReturnNextScene() > PlayerPrefs.GetInt("levelAt"))
            PlayerPrefs.SetInt("levelAt", levelController.ReturnNextScene());
    }
}
