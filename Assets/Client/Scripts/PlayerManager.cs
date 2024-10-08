// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PlayerManager : MonoBehaviour
{
    private Player _player;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }
    
    private PlayerBtn playerBtnPressed;
    public int _gold = 100;

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
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    RemovePlayer(hit.collider.gameObject);
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
    
    public void RemovePlayer(GameObject playerToRemove)
    {
        Destroy(playerToRemove);
    }
    
    // public void BuyPlayer()
    // {
        // if (_gold >= _playerCost)
        // {
            // _gold -= _playerCost;
            // UpdateGold();
        // }
    // }
  
    // public void SellPlayer(int sellValue)
    // {
        // int returnAmount = (int)(_playerCost * 0.75f);
        // _gold += returnAmount;
        // UpdateGold();
    // }
}