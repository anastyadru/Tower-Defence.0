using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerBtn playerBtnPressed;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

            PlacePlayer(hit);
        }
    }

    public void PlacePlayer(RaycastHit2D hit)
    {
        GameObject newPlayer = Instantiate(playerBtnPressed.PlayerObject);
        newPlayer.transform.position = hit.transform.position;
    }

    public void SelectedPlayer(PlayerBtn playerSelected)
    {
        playerBtnPressed = playerSelected;
        Debug.Log("Pressed" + playerBtnPressed.gameObject);
    }
}