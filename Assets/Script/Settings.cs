using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject SettingUI;
    [SerializeField] GameObject PauseUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject LevelEndUI;
    [SerializeField] GameObject LevelStartUI;

    [SerializeField] Slider brightnessSlider;
    [SerializeField] Slider contrastSlider;
    [SerializeField] Slider saturationSlider;

    Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        GetCamera();
    }


    private void Update()
    {
        if (canvas.worldCamera == null)
        {
            GetCamera();
        }
    }
    public void GetCamera()
    {
        canvas.worldCamera = Camera.main;
    }

    public GameObject GetUI()
    {
        return SettingUI;
    }

    public GameObject pauseUI()
    {
        return PauseUI;
    }

    public GameObject gameoverUI()
    {
        return GameOverUI;
    }

    public GameObject levelEndUI(){
        return LevelEndUI;
    }

    public GameObject levelStartUI(){
        return LevelStartUI;
    }

    public Slider GetBrightness()
    {
        
        return brightnessSlider;
    }

    public Slider GetContrast()
    {
        return contrastSlider;
    }

    public Slider GetSaturation()
    {
        return saturationSlider;
    }
}
