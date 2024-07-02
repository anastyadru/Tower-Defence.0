// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IPoolable
{
    private ObjectPool _bulletPool;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 50;
    
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
        if (_bulletPool != null)
        {
            OnRelease();
            _bulletPool.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}