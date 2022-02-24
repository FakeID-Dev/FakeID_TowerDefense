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
    //public Transform[] waypoints;

    public List<Transform> waypoints;
    public List<GameObject> pathPoints;//Erik Added

    //Game Manager 
    public GameObject gameManager; //Erik Added 
    public GameObject start;//Erik Added 
    public bool onMainRoad = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");//Erik add

        //NavMesh Setup
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;

        //State Machine Setup
        enemyStateMachine = new EnemyStateMachine(this);
        enemyStateMachine.RegisterState(new PathfindState());
        enemyStateMachine.RegisterState(new PatrolState());
        enemyStateMachine.ChangeState(initialState);

        Pathfinding();


        //Setup Patrol Points
        innerRingWaypoints = GameObject.Find("MapRoad"); ;//Erik added MapRoad to test waypoints
        //waypoints = innerRingWaypoints.GetComponentsInChildren<Transform>();

        for(int x = 0; x < pathPoints.Count; x++)
        {
            waypoints.Add(pathPoints[x].transform);
        }
        
        

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



    //Enemy A* Pathfinding Algorithm
    public void Pathfinding()
    {
        GameObject end = gameManager.GetComponent<Initialize>().Tiles2D[15, 11];
        int roadCount = 45;
        int x, y;
        x = start.GetComponent<RoadCord>().PosX;
        y = start.GetComponent<RoadCord>().PosY;
        start.GetComponent<RoadCord>().nodeVisted = true;

        for (int e = 0; e < roadCount; e++)
        {
            if(gameManager.GetComponent<Initialize>().Tiles2D[x, y] != end)
            {
                if (gameManager.GetComponent<Initialize>().Tiles2D[x - 1, y].tag == "Road" && gameManager.GetComponent<Initialize>().Tiles2D[x-1, y].GetComponent<RoadCord>().nodeVisted == false)//North
                {
                    Debug.Log("North");
                    gameManager.GetComponent<Initialize>().Tiles2D[x - 1, y].GetComponent<RoadCord>().nodeVisted = true; 
                    x -= 1;
                }

                else if (gameManager.GetComponent<Initialize>().Tiles2D[x + 1, y].tag == "Road" && gameManager.GetComponent<Initialize>().Tiles2D[x+1, y].GetComponent<RoadCord>().nodeVisted == false)//South
                {
                    Debug.Log("South");
                    gameManager.GetComponent<Initialize>().Tiles2D[x + 1, y].GetComponent<RoadCord>().nodeVisted = true;
                    x += 1;
                }

                if (gameManager.GetComponent<Initialize>().Tiles2D[x, y + 1].tag == "Road" && gameManager.GetComponent<Initialize>().Tiles2D[x, y + 1].GetComponent<RoadCord>().nodeVisted == false)//East
                {
                    Debug.Log("East");
                    gameManager.GetComponent<Initialize>().Tiles2D[x, y + 1].GetComponent<RoadCord>().nodeVisted = true;
                    y += 1;
                }

                else if (gameManager.GetComponent<Initialize>().Tiles2D[x, y - 1].tag == "Road" && gameManager.GetComponent<Initialize>().Tiles2D[x, y - 1].GetComponent<RoadCord>().nodeVisted == false)//West
                {
                    Debug.Log("West");
                    gameManager.GetComponent<Initialize>().Tiles2D[x, y - 1].GetComponent<RoadCord>().nodeVisted = true;
                    y -= 1;
                }

                
            }
            else
            {
                Debug.Log(gameManager.GetComponent<Initialize>().Tiles2D[x, y].GetComponent<RoadCord>().PosX + " : "+ gameManager.GetComponent<Initialize>().Tiles2D[x, y].GetComponent<RoadCord>().PosY);
            }

            pathPoints.Add(gameManager.GetComponent<Initialize>().Tiles2D[x, y]);
        }

        for(int b = 0; b < 24; b++)
        {
            for (int v = 0; v < 24; v++)
            {
                if(gameManager.GetComponent<Initialize>().Tiles2D[b, v].tag == "Road")
                    gameManager.GetComponent<Initialize>().Tiles2D[b, v].GetComponent<RoadCord>().nodeVisted = false;
            }
        }
    }
    
    
    //private void OnTriggerEnter(Collider other)
    //{
        
    //    if (onMainRoad == false)
    //    {
    //        if(other.transform.parent.transform.parent != null)
    //        {
    //            if (other.transform.parent.transform.parent.name == "MapRoad")
    //            {
    //                waypoints.Clear();
                    
    //                int children = innerRingWaypoints.transform.childCount;

    //                for (int i = 0; i < children; ++i)
    //                {
    //                    waypoints.Add(innerRingWaypoints.transform.GetChild(i));
    //                }
    //                onMainRoad = true;
    //            }
    //        }
    //    }     
    //}


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


