// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 50;
    
    private ObjectPool _bulletPool;
    private Transform _target;
    
    [Inject]
    public void Construct(ObjectPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void Find(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            float distance = _speed * Time.deltaTime;

            if (direction.magnitude <= distance)
            {
                Enemy enemy = _target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(_damage);
                }
                OnHit();
            }

            transform.Translate(direction.normalized * distance, Space.World);
        }
        else
        {
            OnHit();
        }
    }
    
    public void OnHit()
    {
        OnRelease();
        _bulletPool.ReleaseBullet(this);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}