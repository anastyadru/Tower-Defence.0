// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float _persentShowAds;
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");

        float tempPersent = Random.Range(0f, 1f);

        if (tempPersent < _persentShowAds)
        {
            
        }
    }
}