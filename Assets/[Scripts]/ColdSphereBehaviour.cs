using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ColdSphereBehaviour : MonoBehaviour
{
    /*
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
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().SlowEnemySpeed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().RestoreEnemySpeed();
        }
    }


}
