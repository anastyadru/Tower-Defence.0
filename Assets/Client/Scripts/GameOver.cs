// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float _percentShowAds;
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        StartCoroutine(ShowAdIfReady());
    }

    private IEnumerator ShowAdIfReady()
    {
        while (!Advertisement.isInitialized || !Advertisement.IsReady("Interstitial_Android"))
        {
            yield return new WaitForSeconds(0.3f);
        }

        if (Random.Range(0f, 1f) < _percentShowAds)
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
}