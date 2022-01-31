using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    Text count;
    GameObject[] letters;
    int letterLength;

    private void Awake() => count = GetComponent<Text>();
    private void Update()
    {
        letters = GameObject.FindGameObjectsWithTag("box");
        letterLength = letters.Length;
        count.text = letterLength.ToString();
    }

}
