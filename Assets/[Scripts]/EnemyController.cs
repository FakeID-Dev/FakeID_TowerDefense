using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Variables")]
    public float enemyHealth;
    public float enemySpeed;

    public int coinReward;
    public int expReward;

    public int rewardMultiplier;

    //Enemy Member Variables 
    public EnemyType enemyType;

    //NavMesh Variables 
    public NavMeshAgent navMeshAgent;

    //State Machine Variables 
    public EnemyStateMachine enemyStateMachine;
    public EnemyStateId initialState;

    //Patrol Variables 
    private GameObject innerRingWaypoints;
    public Transform[] waypoints;

    //Game Manager 
    public GameObject gameManger; //Erik Added 

    // Start is called before the first frame update
    void Start()
    {
        //NavMesh Setup
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;

        //State Machine Setup
        enemyStateMachine = new EnemyStateMachine(this);
        enemyStateMachine.RegisterState(new PathfindState());
        enemyStateMachine.RegisterState(new PatrolState());
        enemyStateMachine.ChangeState(initialState);

        //Setup Patrol Points
        innerRingWaypoints = GameObject.Find("MapRoad"); ;//Erik added MapRoad to test waypoints
        waypoints = innerRingWaypoints.GetComponentsInChildren<Transform>();

        gameManger = GameObject.Find("GameManager");//Erik add

    }

    // Update is called once per frame
    void Update()
    {
        //State Machine Update Call
        enemyStateMachine.Update();
    }

    //Enemy Take Damage Function
    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            gameManger.GetComponent<Inventory>().coinInt += coinReward;
            gameManger.GetComponent<Inventory>().expInt += expReward;
            DestroyEnemy();
        }
    }

    //Enemy Die Function 
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void SlowEnemySpeed()
    {
        navMeshAgent.speed = navMeshAgent.speed * 0.2f;
    }

    public void RestoreEnemySpeed()
    {
        navMeshAgent.speed = enemySpeed;
    }

    public void IncreaseCoinReward()
    {
        coinReward = coinReward * rewardMultiplier;
    }

    public void IncreaseExpReward()
    {
        expReward = expReward * rewardMultiplier;
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


