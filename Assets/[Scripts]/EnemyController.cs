using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int health = 3; //Erik Added 
    public GameObject gameManger; //Erik Added 

    //Enemy Member Variables 
    public EnemyType enemyType;

    //NavMesh Variables 
    public NavMeshAgent navMeshAgent;

    //State Machine Variables 
    //public EnemyStateMachine enemyStateMachine;
    //public EnemyStateId initialState;

    //Patrol Variables 
    public GameObject innerRingWaypoints;
    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.Find("GameManager");

        //NavMesh Setup
        navMeshAgent = GetComponent<NavMeshAgent>();


        //State Machine Setup
       // enemyStateMachine = new EnemyStateMachine(this);
        //enemyStateMachine.RegisterState(new PathfindState());
       // enemyStateMachine.RegisterState(new PatrolState());
       // enemyStateMachine.ChangeState(initialState);

        //Setup Patrol Points
        //innerRingWaypoints = GameObject.FindGameObjectWithTag("Map"); //Erik changed "Waypoints to "Map"
        // waypoints = innerRingWaypoints.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //State Machine Update Call
      //  enemyStateMachine.Update();


        if (health <= 0)
        {
            gameManger.GetComponent<Inventory>().coinInt++;
            gameManger.GetComponent<Inventory>().expInt++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            innerRingWaypoints = other.transform.parent.gameObject;   
            innerRingWaypoints = innerRingWaypoints.transform.parent.gameObject;
            waypoints = innerRingWaypoints.GetComponentsInChildren<Transform>();
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





