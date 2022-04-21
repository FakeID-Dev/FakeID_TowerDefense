
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
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

       // enemyController.navMeshAgent.destination = enemyController.waypoints[enemyController.startingPointIndex].position;
       // enemyController.startingPointIndex = (enemyController.startingPointIndex + 1) % enemyController.waypoints.Length;


        if ((enemyController.startingPointIndex + 1) <= enemyController.waypoints.Length)
        {
            enemyController.startingPointIndex = (enemyController.startingPointIndex + 1) % enemyController.waypoints.Length;
        }
        else
        {
            //Debug.Log("ZERO");
            enemyController.startingPointIndex = 0;
        }

        //Debug.Log(enemyController.startingPointIndex);

        enemyController.navMeshAgent.destination = enemyController.waypoints[enemyController.startingPointIndex].position;

    }

}
