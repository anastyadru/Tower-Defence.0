// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class PlayerBtn : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    public GameObject PlayerObject
    {
        get
        {
            return playerObject;
        }
    }
}