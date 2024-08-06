// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadGame()
    {
        if (adInitialized && Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
        
        SceneManager.LoadScene("Game");
    }
}