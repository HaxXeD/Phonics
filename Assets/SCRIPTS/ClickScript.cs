using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PositionScript))]

public class ClickScript : MonoBehaviour
{
    public event Action OnPositionSet;

    BoxCollider2D boxCollider2D;
    SpriteRenderer sprite;
    GameObject[] boxColliders;
    ListAudio sounds;

    //boolean to start/stop traslation
    public bool isPressed = false;

    Vector3 newPos = Vector3.up * 2;

    [SerializeField] float _speed = 10f;
    [SerializeField] AnimationCurve _curve;

    private void Awake()
    {
        //setting the collider a trigger
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;

        sprite = GetComponent<SpriteRenderer>();
        sounds = FindObjectOfType<ListAudio>();
    }
    private void OnMouseDown()
    {
        StartCoroutine(DisableOtherMouseClick());
    }

    IEnumerator DisableOtherMouseClick()
    {
        sounds.PlaySound(29);
        isPressed = true;
        sprite.sortingOrder = 2;
        for(int i = 0; i < boxColliders.Length; i++)
        {
            boxColliders[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(2.3f);
        for (int i = 0; i < boxColliders.Length; i++)
        {
            boxColliders[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void Update()
    {

        boxColliders = GameObject.FindGameObjectsWithTag("box");
        float _current = Mathf.MoveTowards(0, 1, _speed * Time.deltaTime);

        if (isPressed)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, _curve.Evaluate(_current));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), _curve.Evaluate(_current));
            //transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 3f, _curve.Evaluate(_current));
            if (Vector3.Magnitude(transform.position - newPos)<=.01)
            {               
                //firing SettingPosition event
                OnPositionSet?.Invoke();
                isPressed = false;
            }
        }
    }
}