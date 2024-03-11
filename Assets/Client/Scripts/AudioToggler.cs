using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggler : MonoBehaviour
{
    public bool isOn;
    
    private void Start()
    {
        isOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        if (isOn)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
    }
}