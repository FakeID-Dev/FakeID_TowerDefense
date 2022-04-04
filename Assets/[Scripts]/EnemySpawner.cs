using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy Prefabs
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    //Wave Variables
    public float timeBetweenWavesMin = 10.0f;
    public float timeBetweenWavesMax = 60.0f;
    private float timeBetweenWaves;

    private float countDown;
    public int enemiesInWave = 1;
    public int surgeBoost;

    //Surge Variables 

    public int posX = 0;
    public int posY = 0;

    private bool canSpawn = false;

    public GameObject gameManager;
    public SurgeController surgeControllerInstance;


    // Start is called before the first frame update
    void Start()
    {

        surgeControllerInstance = SurgeController.surgeControllerInstance;

        gameManager = GameObject.Find("GameManager");

        GenerateRandomTimeBetweenWaves();
    }

    void Update()
    {
        SpawnWaveIfAvailable();
    }


    public void SpawnEnemy()
    {
        GameObject temp = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        FindStartingRoad(temp);
    }

    IEnumerator SpawnEnemyWave()
    {
        int enemyUnitCost = enemyPrefab.GetComponent<EnemyController>().unitCost;

        int waveunitCost = enemyUnitCost * enemiesInWave;

        if (waveunitCost > surgeControllerInstance.GetAvailableUnits())
        {
            surgeControllerInstance.DecreaseAvailableEnemyUnits(waveunitCost);

            //Spawn enemy
            for (int i = 0; i < enemiesInWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(2.0f);
            }
        }
    }

    IEnumerator SpawnEnemySurgeWave()
    {
        for (int i = 0; i < enemiesInWave + surgeBoost; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2.0f);
        }
    }

    private void SpawnWaveIfAvailable()
    {
        if (countDown <= 0.0f)
        {
            CheckAvailableRoad();

            if (canSpawn)
            {
                StartCoroutine(SpawnEnemyWave());
            }
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
    }

    private void SpawnSurgeIfAvailable()
    {
        CheckAvailableRoad();
        
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemySurgeWave());
        }
    }

    private void GenerateRandomTimeBetweenWaves()
    {
        timeBetweenWaves = Random.Range(timeBetweenWavesMin, timeBetweenWavesMax);
        countDown = timeBetweenWaves;
    }

    private void IncreaseTimeBetweenWaveMinAndMax()
    {
        timeBetweenWavesMin += 5.0f;
        timeBetweenWavesMax += 5.0f;
    }
 
    public void ActivateSurgeSpawning()
    {
        SpawnSurgeIfAvailable();
    }

    public void DeactivateSurgeSpawning()
    {

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

}
