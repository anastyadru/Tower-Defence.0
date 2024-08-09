// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "5671873";
    
    private string _interstitialAd = "Interstitial_Android";
    
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement is not ready!");
        }
    }
    
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _interstitialAd)
        {
            // действия, если реклама доступна
        }
    }
    
    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Advertisement Error: {message}");
    }
    
    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
    }
    
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _interstitialAd) // Проверка для межстраничной рекламы
        {
            if (showResult == ShowResult.Finished)
            {
                Debug.Log("Межстраничная реклама была показана полностью!");
            }
            else if (showResult == ShowResult.Skipped)
            {
                Debug.Log("Межстраничная реклама была пропущена!");
            }
            else if (showResult == ShowResult.Failed)
            {
                Debug.LogError("Межстраничная реклама не была показана");
            }
        }
    }
}