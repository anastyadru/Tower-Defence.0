using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerBtn playerBtnPressed;

    public void SelectedPlayer(PlayerBtn playerSelected)
    {
        playerBtnPressed = playerSelected;
        Debug.Log("Pressed" + playerBtnPressed.gameObject);
    }
}