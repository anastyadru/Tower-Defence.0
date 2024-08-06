// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.using System;

using UnityEngine;

public class ADSCore : MonoBehaviour
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "5671873";

    private string _rewardedVideo = "Rewarded Android";

    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
    }

    public static void ShowAdsVideo(string placementId)
    {
        
    }
}