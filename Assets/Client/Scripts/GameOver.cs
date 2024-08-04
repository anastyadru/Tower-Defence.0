// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{
    private bool adInitialized;
    
    public void Start()
    {
        Advertisement.Initialize("5654184", false);
        StartCoroutine(CheckAdInitialized());
    }
    
    IEnumerator CheckAdInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return null;
        }
        adInitialized = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadGame()
    {
        if (adInitialized && Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
        
        SceneManager.LoadScene("Game");
    }
}