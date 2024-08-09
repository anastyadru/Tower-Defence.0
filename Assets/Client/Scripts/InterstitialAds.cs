// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InterstitialAds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;
    [SerializeField] private Button _adsButton;
    
    private string _gameId = "5671873";
    private string _interstitialAd = "Interstitial_Android";

    void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_interstitialAd);

        if (_adsButton)
        {
            _adsButton.onClick.AddListener(ShowInterstitialAd);
        }

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);
    }

    public void ShowInterstitialAd()
    {
        Advertisement.Show(_interstitialAd);
    }
    
    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _interstitialAd)
        {
            _adsButton.interactable = true;
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
            // если пользователь посмотрел рекламу до конца
        }
        else if (showResult == ShowResult.Skipped)
        {
            // если пользователь пропустил рекламу
        }
        else if (showResult == ShowResult.Failed)
        {
            // действия при ошибке
        }
    }
}