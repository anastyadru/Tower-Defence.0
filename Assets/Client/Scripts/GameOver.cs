// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private void Start()
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
        SceneManager.LoadScene("Game");
    }
}