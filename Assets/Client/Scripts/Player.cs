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

    }
}