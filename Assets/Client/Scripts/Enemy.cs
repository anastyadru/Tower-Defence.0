using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health = 10;
    [SerializeField] private TextMesh _healthText;

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
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        _healthText.text = _health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndCube"))
        {
            GameM.instance.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}