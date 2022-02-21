using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    //Enemy Member Variables 
    public EnemyType enemyType;
    public float health;

    //NavMesh Variables 
    public NavMeshAgent navMeshAgent;

    //State Machine Variables 
    public EnemyStateMachine enemyStateMachine;
    public EnemyStateId initialState;

    //Patrol Variables 
    private GameObject innerRingWaypoints;
    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        //NavMesh Setup
        navMeshAgent = GetComponent<NavMeshAgent>();

       


        //State Machine Setup
        enemyStateMachine = new EnemyStateMachine(this);
        enemyStateMachine.RegisterState(new PathfindState());
        enemyStateMachine.RegisterState(new PatrolState());
        enemyStateMachine.ChangeState(initialState);

        //Setup Patrol Points
        innerRingWaypoints = GameObject.FindGameObjectWithTag("WayPoints");
        waypoints = innerRingWaypoints.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //State Machine Update Call
        enemyStateMachine.Update();


    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}




//
// Enemy Type Enum Class Def
//


public enum EnemyType
{
    NONE,
    GOBLIN,
    GHOUL,
    GOLEM,
    GHOST
}


