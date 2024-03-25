using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _playerPreview;
    [SerializeField] private GameObject _player;

    private GameObject _crPlayerPreview;
    private bool _build;
    private bool _spawned;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _build = !_build;

            if (_crPlayerPreview != null)
            {
                Destroy(_crPlayerPreview);
            }
        }
    }

    private void OnMouseDown()
    {
        if (_build && !_spawned)
        {
            _spawned = true;
            Instantiate(_player, transform.position, Quaternion.Identity);
            Destroy(_crPlayerPreview);
        }
    }
    
    
}