using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy Prefabs
    public GameObject enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.0f;
    private float countDown = 2.0f;

    public int enemiesInWave; 

    public int posX = 0;
    public int posY = 0;

    private bool canSpawn = false;

    public GameObject gameManager;

    public SurgeController surgeControllerInstance;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        if (countDown <= 0.0f)
        {
            CheckAvailableRoad();

            if (canSpawn)
            {
                SpawnEnemy();
            }
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
    }


    public void SpawnEnemy()
    {
        GameObject temp = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        FindStartingRoad(temp);
    }

    public void SpawnEnemyWave()
    {
        int enemyUnitCost = enemyPrefab.GetComponent<EnemyController>().unitCost;

        int waveunitCost = enemyUnitCost * enemiesInWave;

        if (waveunitCost > surgeControllerInstance.GetAvailableUnits())
        {
            //Spawn enemy
        }

    }

    private void FindStartingRoad(GameObject t)
    {
        if (gameManager.GetComponent<Initialize>().Tiles2D[posX - 1, posY].tag == "Road")
        {
            t.GetComponent<EnemyController>().start = gameManager.GetComponent<Initialize>().Tiles2D[posX - 1, posY];
        }
        else if (gameManager.GetComponent<Initialize>().Tiles2D[posX + 1, posY].tag == "Road")
        {
            t.GetComponent<EnemyController>().start = gameManager.GetComponent<Initialize>().Tiles2D[posX + 1, posY];
        }
        else if (gameManager.GetComponent<Initialize>().Tiles2D[posX, posY - 1].tag == "Road")
        {
            t.GetComponent<EnemyController>().start = gameManager.GetComponent<Initialize>().Tiles2D[posX, posY - 1];
        }
        else if (gameManager.GetComponent<Initialize>().Tiles2D[posX, posY + 1].tag == "Road")
        {
            t.GetComponent<EnemyController>().start = gameManager.GetComponent<Initialize>().Tiles2D[posX, posY + 1];
        }
    }

    private void CheckAvailableRoad()
    {
        if (gameManager.GetComponent<Initialize>().Tiles2D[posX - 1, posY].tag == "Road")
        {
            canSpawn = true;
        }
        else if (gameManager.GetComponent<Initialize>().Tiles2D[posX + 1, posY].tag == "Road")
        {
            canSpawn = true;
        }
        else if (gameManager.GetComponent<Initialize>().Tiles2D[posX, posY - 1].tag == "Road")
        {
            canSpawn = true;
        }
        else if (gameManager.GetComponent<Initialize>().Tiles2D[posX, posY + 1].tag == "Road")
        {
            canSpawn = true;
        }
    }

    public void ActivateSurgeSpawning()
    {

    }

    public void DeactivateSurgeSpawning()
    {

    }

}
