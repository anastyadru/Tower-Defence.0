// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) 
        {
            PlayerPrefs.SetFloat("volume", 1f);
            slider.value = 1f;
        }
        else 
        {
            slider.value = PlayerPrefs.GetFloat("volume");
        }
    }

    private void Update()
    {
        if (slider.value != PlayerPrefs.GetFloat("volume"))
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
        }
    }
}