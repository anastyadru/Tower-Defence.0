using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject EndCube;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EndCube = GameObject.FindGameObjectWithTag("EndCube");
    }
    
    void Update()
    {
        agent.SetDestination(EndCube.transform.position);
    }
}