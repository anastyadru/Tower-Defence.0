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

            if (bullet1 != null)
            {
                bullet1.Find(_target);
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