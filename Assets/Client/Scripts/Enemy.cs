// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 1000;
    [SerializeField] private TextMesh _healthText;
    [SerializeField] private int _killReward = 5;

    public NavMeshAgent agent;
    public GameObject EndCube;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EndCube = GameObject.FindGameObjectWithTag("EndCube");
        
        _healthText.text = _health.ToString();
    }
    
    private void Update()
    {
        agent.SetDestination(EndCube.transform.position);
    }

    public void TakeDamage(int damage)
    {
        _health = 0;
        GameM.instance._gold += _killReward;
        GameM.instance.UpdateGold();
        
        if (gameObject.activeSelf)
        {
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