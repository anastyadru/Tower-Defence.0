using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerBtn playerBtnPressed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);
        }
    }

    public void SelectedPlayer(PlayerBtn playerSelected)
    {
        playerBtnPressed = playerSelected;
        Debug.Log("Pressed" + playerBtnPressed.gameObject);
    }
}