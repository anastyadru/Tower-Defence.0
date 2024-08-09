// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "5671873";
    
    private string _video = "Interstitial_Android";
    private string _rewardedVideo = "Rewarded_Android";
    
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
        if (placementId == _rewardedVideo)
        {
            // действия, если реклама доступна
        }
    }
    
    public void OnUnityAdsDidError(string message)
    {
        // ошибка рекламы
    }
    
    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
    }
    
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("+1");
            // если пользователь посмотрел рекламу
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Ошибка!");
            // если пользователь пропустил рекламу
        }
        else if (showResult == ShowResult.Failed)
        {
            // действия при ошибке
        }
    }
}