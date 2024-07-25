// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IPoolable
{
    private ObjectPool _bulletPool;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 50f;
    
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
        if (_target == null)
        {
            OnHit();
            return;
        }

        Vector3 direction = (_target.position - transform.position).normalized;
        float distance = _speed * Time.deltaTime;

        if ((transform.position - _target.position).magnitude <= distance)
        {
            _target.GetComponent<Enemy>()?.TakeDamage(_damage);
            OnHit();
        }
        else
        {
            transform.Translate(direction * distance, Space.World);
        }
    }

    public void OnHit()
    {
        _bulletPool?.Release(this);
        gameObject.SetActive(false);
    }
}