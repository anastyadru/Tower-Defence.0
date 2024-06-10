// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 50;
    
    private Transform _target;
    private int _currentWave = 1;
    private int _shotsNeeded = 1;

    public void Find(Transform target, int currentWave)
    {
        _target = target;
        _currentWave = currentWave;
        _shotsNeeded = _currentWave;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            float distance = _speed * Time.deltaTime;

            if(direction.magnitude <= distance)
            {
                _shotsNeeded--;
                if (_shotsNeeded <= 0)
                {
                    _target.GetComponent<Enemy>().TakeDamage(1000);
                    Destroy(gameObject);
                }
            }

            transform.Translate(direction.normalized * distance, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}