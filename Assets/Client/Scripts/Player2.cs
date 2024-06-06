// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private float _range = 15;
    [SerializeField] private float _rotationSpeed = 3;
    [SerializeField] private float _fireRate = 1;

    private List<Enemy> _targets = new List<Enemy>();
    private Enemy[] _enemies;
    private int _currentTargetIndex = 0;
    private float _countdown;
    
    private void Update()
    {
        _enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;

        foreach (Enemy enemy in _enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
            }
        }

        if (_enemies.Length > 0 && shortestDistance <= _range)
        {
            _targets.Clear();
            foreach (Enemy enemy in _enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance <= _range)
                {
                    _targets.Add(enemy);
                }
            }
        }

        if (_targets.Count > 0)
        {
            Vector3 direction = _targets[_currentTargetIndex].transform.position - _head.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_head.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
            _head.rotation = Quaternion.Euler(0, rotation.y, 0);

            if (_countdown <= 0)
            {
                StartCoroutine(ShootBullets());
                _countdown = 1 / _fireRate;
            }

            _countdown -= Time.deltaTime;
        }
    }

    private IEnumerator ShootBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bullet = Instantiate(_bullet, _firePoints[i % _firePoints.Length].position, _firePoints[i % _firePoints.Length].rotation);
            Bullet bullet1 = bullet.GetComponent<Bullet>();

            if (bullet1 != null && _targets.Count > 0)
            {
                bullet1.Find(_targets[_currentTargetIndex].transform);
                _currentTargetIndex = (_currentTargetIndex + 1) % _targets.Count;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}