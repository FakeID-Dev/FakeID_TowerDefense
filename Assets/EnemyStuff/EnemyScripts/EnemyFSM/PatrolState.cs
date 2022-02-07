using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{

    //Patrol State Variables 
    public int pointIndex = 0;


    public EnemyStateId GetId()
    {  
        return EnemyStateId.PatrolPath;
    }

    public void Enter(EnemyController enemyController)
    {

        enemyController.navMeshAgent.autoBraking = false;

        //Animations 

        MoveToNextPoint(enemyController);
    }

    public void Update(EnemyController enemyController)
    {
        if (!enemyController.navMeshAgent.pathPending && enemyController.navMeshAgent.remainingDistance < 0.5f)
        {
            MoveToNextPoint(enemyController);
        }
    }

    public void Exit(EnemyController enemyController)
    {

    }

    public void MoveToNextPoint(EnemyController enemyController)
    {
        if (enemyController.waypoints.Length == 0)
        {
            return;
        }

        enemyController.navMeshAgent.destination = enemyController.waypoints[pointIndex].position;
        pointIndex = (pointIndex + 1) % enemyController.waypoints.Length;
    }

}
