using System;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.SetInt("levelAt", 2);
    }
}
