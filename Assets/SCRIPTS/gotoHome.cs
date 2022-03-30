using System.Collections;
using UnityEngine;

public class gotoHome : MonoBehaviour
{
    LevelManager level;

    ListAudio list;
    // Start is called before the first frame update

    private void Awake() => list = FindObjectOfType<ListAudio>();
    void Start()
    {
        level = FindObjectOfType<LevelManager>(); 
        list.PlaySound(30);
        StartCoroutine(LoadHomeScene());
    }

    IEnumerator LoadHomeScene()
    {
        yield return new WaitForSeconds(5f);
        level.LoadScene(0);
    }
}
