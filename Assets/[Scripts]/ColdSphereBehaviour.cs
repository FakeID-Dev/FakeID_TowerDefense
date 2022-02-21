using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ColdSphereBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        NavMeshAgent slowedEnemyAgent = other.GetComponent<NavMeshAgent>();
        if (slowedEnemyAgent != null)
        {
            slowedEnemyAgent.speed = slowedEnemyAgent.speed * 0.2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NavMeshAgent slowedEnemyAgent = other.GetComponent<NavMeshAgent>();
        if (slowedEnemyAgent != null)
        {
            slowedEnemyAgent.speed = slowedEnemyAgent.speed * 5f;
        }
    }
}
