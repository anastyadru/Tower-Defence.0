// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{
    private bool adInitialized = false;
    
    public void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("5654184", false);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadGame()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
        
        SceneManager.LoadScene("Game");
    }
}