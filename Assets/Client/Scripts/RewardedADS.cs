// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardedAds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;
    [SerializeField] private Button _adsButton;
    
    private string _gameId = "5671873";
    
    private string _rewardedVideo = "Rewarded_Android";

    void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        if (_adsButton)
        {
            _adsButton.onClick.AddListener(ShowRewardedVideo);
        }

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, true);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo);
    }
    
    
}