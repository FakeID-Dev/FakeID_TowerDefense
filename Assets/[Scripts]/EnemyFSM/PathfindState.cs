using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindState : EnemyState
{
   


    public EnemyStateId GetId()
    {
        return EnemyStateId.Pathfind;
    }

    public void Enter(EnemyController enemyController)
    {
        enemyController.navMeshAgent.autoBraking = false;

        FindClosestPoint(enemyController);
    }

    public void Update(EnemyController enemyController)
    {
        if (!enemyController.navMeshAgent.pathPending && enemyController.navMeshAgent.remainingDistance < 0.75f)
        {
            enemyController.enemyStateMachine.ChangeState(EnemyStateId.PatrolPath);
        }
    }

    public void Exit(EnemyController enemyController)
    {

    }

    private void FindClosestPoint(EnemyController enemyController)
    {
        float shortestDistance = Mathf.Infinity;

        for (int i = 0; i < enemyController.waypoints.Length; i++)
        {
            float distanceBetween = Vector3.Distance(enemyController.transform.position, enemyController.waypoints[i].position);

            if (distanceBetween < shortestDistance)
            {
                //Shortest Path Found
                shortestDistance = distanceBetween;

                if (i < enemyController.waypoints.Length - 1)
                {
                    enemyController.initialPathFindPoint = enemyController.waypoints[i + 1];
                    enemyController.startingPointIndex = i + 2;
                }
                else
                {
                    enemyController.initialPathFindPoint = enemyController.waypoints[0];
                    enemyController.startingPointIndex = 0;
                }
            }
        }
        MoveToInitialPoint(enemyController);
    }

    private void MoveToInitialPoint(EnemyController enemyController)
    {
        enemyController.navMeshAgent.destination = enemyController.initialPathFindPoint.position;
    }
  
}
