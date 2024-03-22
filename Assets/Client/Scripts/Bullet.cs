using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 50;
    private Transform _target;

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

            if(direction.magnitube <= distance)
            {
                _target.GetComponent<Enemy>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}