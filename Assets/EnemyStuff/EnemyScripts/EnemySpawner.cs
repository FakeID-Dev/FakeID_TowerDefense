using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy Prefabs
    public GameObject enemyPrefab;

    public Transform spawnPoint;

    private float timeBetweenWaves = 5.0f;
    private float countDown = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        
    }


}
