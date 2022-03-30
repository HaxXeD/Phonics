using UnityEngine;

public class SettingButtons : MonoBehaviour
{    
    Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<Settings>();
    }

    public void ShowUI()
    {
        settings.GetUI().SetActive(true);
    }

    public void HideUI()
    {
        settings.GetUI().GetComponent<SettingTween>().CloseSetting();
    }

    public void ShowPauseUI()
    {
        settings.pauseUI().SetActive(true);
    }

    public void HidePauseUI()
    {
        settings.pauseUI().SetActive(false);
    }

    public void ShowGameOverUI()
    {
        settings.gameoverUI().SetActive(true);
    }

    public void HideGameOverUI()
    {
        settings.gameoverUI().SetActive(false);
    }

    public void ShowLevelEndUI(){
        settings.levelEndUI().SetActive(true);
    }

    public void HideExcellentUI(){
        settings.levelEndUI().SetActive(false);
    }
     public void ShowLevelStartUI(){
        settings.levelStartUI().SetActive(true);
    }

    public void HideLevelStartUI(){
        settings.levelStartUI().SetActive(false);
    }
}
