// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class AudioToggler : MonoBehaviour
{
    private const float soundOnVolume = 1f;
    private const float soundOffVolume = 0f;

    private void Start()
    {
        SetAudioVolume(PlayerPrefs.GetInt("SoundOn", 1) == 1);
    }

    public void OnOffSounds()
    {
        bool isOn = AudioListener.volume == soundOffVolume;
        SetAudioVolume(isOn);
        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void SetAudioVolume(bool isOn)
    {
        AudioListener.volume = isOn ? soundOnVolume : soundOffVolume;
    }
}