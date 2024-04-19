using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 50;
    
    private Transform _target;
    private int _bulletsRequired; // Количество пуль, необходимых для убийства врага

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

            if(direction.magnitude <= distance)
            {
                _target.GetComponent<Enemy>().TakeDamage(int.MaxValue);
                Destroy(gameObject);
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
}