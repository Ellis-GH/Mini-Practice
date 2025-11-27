using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = FindAnyObjectByType<PlayerMovementScript>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
