// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMesh _healthText;
    [SerializeField] private int _killReward = 1;
    
    private int _health;

    private NavMeshAgent _agent;
    private Transform _endCube;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _endCube = GameObject.FindGameObjectWithTag("EndCube").transform;
        
        SetHealthByWave();
        UpdateHealthText();
    }
    
    private void SetHealthByWave()
    {
        _health = GameM.instance.GetCurrentWave();
    }

    private void Update()
    {
        _agent.SetDestination(_endCube.position);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        UpdateHealthText();
        
        if (_health <= 0)
        {
            GameM.instance._gold += _killReward;
            GameM.instance.UpdateGold();
            StartCoroutine(DestroyEnemy());
        }
    }
    
    private void UpdateHealthText()
    {
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