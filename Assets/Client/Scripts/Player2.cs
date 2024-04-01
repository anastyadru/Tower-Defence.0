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
    [SerializeField] private float _fireRate = 0.33333f;

    private Transform _target;
    private Enemy _nearestEnemy;
    private float _countdown;
}