using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [Space(5)]
    [SerializeField] private float _range = 15;
    [SerializeField] private float _rotationSpeed = 3;

    private Transform _target;
    private Enemy _nearestEnemy;

    private void Update()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                _nearestEnemy = enemy;
            }
        }

        if (_nearestEnemy != null && shortestDistance <= _range)
        {
            _target = _nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }

        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            Quaternion look = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_head.rotation, look, _rotationSpeed * Time.deltaTime).eulerAngles;
            _head.rotation = Quaternion.Euler(0, rotation.y, 0);
        }
    }
    
    
}