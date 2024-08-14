// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource myFX;
    public AudioClip clickFX;

    public void ClickSound()
    {
        myFX.PlayOneShot(clickFX);
    }
}