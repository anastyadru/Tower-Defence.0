// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _playerPreview;
    [SerializeField] private GameObject _playerPreviewRed;
    [SerializeField] private GameObject _player;

    private GameObject _currentPlayerPreview;
    private bool _isBuilding;
    private bool _isSpawned;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleBuildMode();
        }
    }
    
    private void ToggleBuildMode()
    {
        _isBuilding = !_isBuilding;

        if (_currentPlayerPreview != null)
        {
            Destroy(_currentPlayerPreview);
        }
    }
    
    private void OnMouseDown()
    {
        if (_isBuilding && !_isSpawned && GameM.instance._gold >= GameM.instance._playerCost)
        {
            SpawnPlayer();
        }
    }
    
    private void OnMouseExit()
    {
        ClearPlayerPreview();
    }

    private void OnMouseOver()
    {
        UpdatePlayerPreview();
    }

    private void SpawnPlayer()
    {
        _isSpawned = true;
        GameM.instance._gold -= GameM.instance._playerCost;
        GameM.instance.UpdateGold();
        Instantiate(_player, transform.position, Quaternion.identity);
        ClearPlayerPreview();
    }

    private void OnMouseExit()
    {
        if(_crPlayerPreview != null)
        {
            Destroy(_crPlayerPreview);
        }
        
        _used = false;
    }

    private void OnMouseOver()
    {
        if (_crPlayerPreview == null && _build && !_spawned)
        {
            if (GameM.instance._gold >= GameM.instance._playerCost)
            {
                _crPlayerPreview = Instantiate(_playerPreview, transform.position, Quaternion.identity);
            }
            else
            {
                _crPlayerPreview = Instantiate(_playerPreviewRed, transform.position, Quaternion.identity);
            }
        }

        if (_crPlayerPreview != null && _build && !_spawned && !_used && GameM.instance._gold >= GameM.instance._playerCost)
        {
            _used = true;
            Destroy(_crPlayerPreview);
            _crPlayerPreview = Instantiate(_playerPreview, transform.position, Quaternion.identity);
        }
    }
}