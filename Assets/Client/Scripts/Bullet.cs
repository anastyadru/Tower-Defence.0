using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 50;
    
    private Transform _target;
    private int _damage = 100;
    private int _currentWaveDamageMultiplier = 1;

    public void Find(Transform target, int waveIndex)
    {
        _target = target;
        _currentWaveDamageMultiplier = waveIndex + 1; // Устанавливаем уровень урона для текущей волны
        _damage = 100 * _currentWaveDamageMultiplier; // Увеличиваем урон в зависимости от текущей волны
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            float distance = _speed * Time.deltaTime;

            if(direction.magnitude <= distance)
            {
                _target.GetComponent<Enemy>().TakeDamage(_damage);
                Destroy(gameObject);
            }

            transform.Translate(direction.normalized * distance, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}