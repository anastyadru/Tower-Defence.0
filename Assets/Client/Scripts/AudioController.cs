// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audio_;
    
    private const float defaultVolume = 1f;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            audio_.volume = defaultVolume;
        }
    }

    private void Update()
    {
        float volume = PlayerPrefs.GetFloat("volume");
        if (audio_.volume != volume)
        {
            audio_.volume = volume;
        }
    }
}