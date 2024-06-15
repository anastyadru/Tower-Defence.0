// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("PlayerSide"))
                {
                    PlacePlayer(hit.point);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1)) // Добавлено условие для правой кнопки мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Player")) // Проверяем тег "Player" для удаления игрока
                {
                    RemovePlayer(hit.collider.gameObject); // Вызываем метод для удаления игрока
                }
            }
        }
    }

    public void PlacePlayer(Vector3 position)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && playerBtnPressed != null)
        {
            GameObject newPlayer = Instantiate(playerBtnPressed.PlayerObject);
            newPlayer.transform.position = position;
        }
    }

    public void SelectedPlayer(GameObject playerSelectedObject)
    {
        PlayerBtn playerSelected = playerSelectedObject.GetComponent<PlayerBtn>();
        if (playerSelected != null)
        {
            playerBtnPressed = playerSelected;
            Debug.Log("Pressed" + playerBtnPressed.gameObject);
        }
    }
}