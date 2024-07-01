// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject] private NavMeshAgent _agent;
    [Inject] private ObjectPool _bulletPool;
    
    [SerializeField] private TextMesh _healthText;
    
    [SerializeField] private int _killReward = 1;
    
    private int _health;

    public NavMeshAgent agent;
    public GameObject EndCube;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EndCube = GameObject.FindGameObjectWithTag("EndCube");
        
        SetHealthByWave();
        _healthText.text = _health.ToString();
    }
    
    private void SetHealthByWave()
    {
        int currentWave = GameM.instance.GetCurrentWave();
        _health = currentWave;
    }

    private void Update()
    {
        agent.SetDestination(EndCube.transform.position);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GameM.instance._gold += _killReward;
            GameM.instance.UpdateGold();
            StartCoroutine(DestroyEnemy());
        }
        
        _healthText.text = _health.ToString();
    }
    
    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndCube"))
        {
            GameM.instance.TakeDamage(_health);
            Destroy(gameObject);
        }
    }
}