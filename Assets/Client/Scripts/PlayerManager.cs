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
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mousePoint, Vector3.forward, out hit))
            {
                PlacePlayer(hit);
            }
        }
    }

    public void PlacePlayer(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && playerBtnPressed != null)
        {
            GameObject newPlayer = Instantiate(playerBtnPressed.PlayerObject);
            newPlayer.transform.position = hit.point;
        }
    }

    public void SelectedPlayer(PlayerBtn playerSelected)
    {
        playerBtnPressed = playerSelected;
        Debug.Log("Pressed" + playerBtnPressed.gameObject);
    }
}