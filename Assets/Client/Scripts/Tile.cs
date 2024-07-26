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
        if (Input.GetMouseButtonDown(0))
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

    private void UpdatePlayerPreview()
    {
        if (_isBuilding && !_isSpawned)
        {
            if (_currentPlayerPreview != null)
            {
                Destroy(_currentPlayerPreview);
            }

            GameObject previewPrefab = GameM.instance._gold >= GameM.instance._playerCost ? _playerPreview : _playerPreviewRed;
            _currentPlayerPreview = Instantiate(previewPrefab, transform.position, Quaternion.identity);
        }
    }

    private void ClearPlayerPreview()
    {
        if (_currentPlayerPreview != null)
        {
            Destroy(_currentPlayerPreview);
            _currentPlayerPreview = null;
        }
    }
}