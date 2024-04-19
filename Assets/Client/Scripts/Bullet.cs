using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 50;
    
    private Transform _target;
    private int _bulletsRequired; // Количество пуль, необходимых для убийства врага
    
    private int _currentWave = 1; // Текущая волна

    public void Find(Transform target, int bulletsRequired)
    {
        _target = target;
        _bulletsRequired = bulletsRequired + _currentWave - 1; // Устанавливаем количество пуль, учитывая текущую волну
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            float distance = _speed * Time.deltaTime;

            if(direction.magnitude <= distance)
            {
                _bulletsRequired--; // Уменьшаем количество пуль, использованных для убийства врага
                if (_bulletsRequired <= 0)
                {
                    _target.GetComponent<Enemy>().TakeDamage(int.MaxValue);
                    Destroy(gameObject);
                }
            }
            else
            {
                transform.Translate(direction.normalized * distance, Space.World);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetWave(int wave)
    {
        _currentWave = wave;
        _bulletsRequired = wave; // Устанавливаем количество пуль, учитывая текущую волну
    }
}