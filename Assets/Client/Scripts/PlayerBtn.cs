using System.Collections;
using System.Collections.Generic;
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