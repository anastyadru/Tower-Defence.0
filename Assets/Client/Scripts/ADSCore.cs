// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using UnityEngine;
using UnityEngine.Advertisements;

public class ADSCore : MonoBehaviour
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "5671873";
    private string _rewardedVideo = "Rewarded Android";

    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
    }

    public void ShowAdsVideo()
    {
        if (Advertisement.IsReady(_rewardedVideo))
        {
            Advertisement.Show(_rewardedVideo);
        }
        else
        {
            Debug.Log("Advertisement is not ready!");
        }
    }
}