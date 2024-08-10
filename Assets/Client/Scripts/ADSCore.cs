// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "5671873";
    private string _interstitialAd = "Interstitial_Android";
    
    public void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady(_interstitialAd))
        {
            Advertisement.Show(_interstitialAd);
        }
        else
        {
            Debug.Log("Advertisement is not ready!");
        }
    }
    
    public void OnUnityAdsReady(string placementId)
    {
        
    }
    
    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Advertisement Error: {message}");
    }
    
    public void OnUnityAdsDidStart(string placementId)
    {
        
    }
    
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == _interstitialAd && showResult == ShowResult.Finished)
        {
            Debug.Log("Межстраничная реклама была показана полностью!");
        }
    }
}