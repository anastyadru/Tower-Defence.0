// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _playerPreview;
    [SerializeField] private GameObject _playerPreviewRed;
    [SerializeField] private GameObject _player;

    private GameObject _crPlayerPreview;
    private bool _build;
    private bool _spawned;
    private bool _used;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _build = !_build;

            if (_crPlayerPreview != null)
            {
                Destroy(_crPlayerPreview);
            }

            _used = false;
        }
    }

    private void OnMouseDown()
    {
        if(_build && !_spawned && GameM.instance._gold >= GameM.instance._playerCost)
        {
            _spawned = true;
            _used = false;
            GameM.instance._gold -= GameM.instance._playerCost;
            GameM.instance.UpdateGold();
            Instantiate(_player, transform.position, Quaternion.identity);
            Destroy(_crPlayerPreview);
        }
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