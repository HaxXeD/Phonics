using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    ListAudio sounds;
    [SerializeField] int audioIndex;

    private void Awake() => sounds = FindObjectOfType<ListAudio>(); 
    // Start is called before the first frame update
    void Start()
    {
        ClickScript click = GetComponent<ClickScript>();

        //subscribing to SettingPosition event
        click.OnPositionSet += Onset;
    }

    void Onset()
    {
        sounds.PlaySound(audioIndex);
        Destroy(gameObject, 2);
    }
}
