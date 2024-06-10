// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMesh _healthText;
    [SerializeField] private int _killReward = 5;

    public NavMeshAgent agent;
    public GameObject EndCube;
    
    private int _shotsNeeded = 1;
    private int _currentWave = 1;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EndCube = GameObject.FindGameObjectWithTag("EndCube");
        
        _healthText.text = _shotsNeeded.ToString();
    }
    
    private void Update()
    {
        agent.SetDestination(EndCube.transform.position);
    }

    public void TakeDamage(int shots)
    {
        _shotsNeeded -= shots;

        if (_shotsNeeded <= 0)
        {
            GameM.instance._gold += _killReward;
            GameM.instance.UpdateGold();
            
            if (gameObject.activeSelf)
            {
                StartCoroutine(DestroyEnemy());
            }
        }

        _healthText.text = _shotsNeeded.ToString();
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
            GameM.instance.TakeDamage(_shotsNeeded);
            Destroy(gameObject);
        }
    }
}