using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    public NavMeshAgent agent;
    public GameObject EndCube;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EndCube = GameObject.FindGameObjectWithTag("EndCube");
    }
    
    private void Update()
    {
        agent.SetDestination(EndCube.transform.position);
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