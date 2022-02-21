using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy Prefabs
    public GameObject enemyPrefab;

    public Transform spawnPoint;

    private float timeBetweenWaves = 10.0f;
    private float countDown = 2.0f;

    private GameObject gameManager;// erik added 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager"); // erik added 
    }

    void Update()
    {
        if (countDown <= 0.0f)
        {
            SpawnEnemy();
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
    }


    public void  SpawnEnemy()
    {
        GameObject temp = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        gameManager.GetComponent<MonsterList>().monsterList.Add(temp);// Erik Added the list 
        
    }
}


