using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy Prefabs
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    //Wave Variables
    public int timeBetweenWavesMin = 10;
    public int timeBetweenWavesMax = 60;
    private float timeBetweenWaves;

    private float countDown = 10.0f;
    public int enemiesInWave = 5;
    public int surgeBoost;

    private float surgeCountDown = 1.0f;

    //Surge Variables 
    public int posX = 0;
    public int posY = 0;

    private bool canSpawn = false;

    public GameObject gameManager;
    public SurgeController surgeControllerInstance;

    private bool surgeActive = false;

    //UI Elements 
    public GameObject surgeImage;
    public GameObject spawnImage;

    // Start is called before the first frame update
    void Start()
    {
        surgeControllerInstance = SurgeController.surgeControllerInstance;
        gameManager = GameObject.Find("GameManager");   
    }

    void Update()
    {
        if (surgeActive)
        {
            SpawnSurgeIfAvailable();
        }
        else
        {
            SpawnWaveIfAvailable();
        }
        CheckAvailableRoad();
    }

    public void SpawnEnemy()
    {
        GameObject temp = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
       
        FindStartingRoad(temp);

        switch (Random.Range(0,3))
        {
            case 1:
                gameObject.GetComponent<AudioSource>().Play();
                break;

            default:
                break;
        }
    }

   //Changed from IEnum
    IEnumerator  SpawnEnemyWave()
    {
        spawnImage.SetActive(true);
        int enemyUnitCost = enemyPrefab.GetComponent<EnemyController>().unitCost;
        int waveunitCost = enemyUnitCost * enemiesInWave;

        if (waveunitCost < surgeControllerInstance.GetAvailableUnits())
        {           
            surgeControllerInstance.DecreaseAvailableEnemyUnits(waveunitCost);

            //Spawn enemy
            for (int i = 0; i < enemiesInWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(3.0f);
            }
            spawnImage.SetActive(false);
        }
    }

    IEnumerator SpawnEnemySurgeWave()
    {
        surgeImage.SetActive(true);

        for (int i = 0; i < enemiesInWave + surgeBoost; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2.0f);
        }
        surgeImage.SetActive(false);
    }

    private void SpawnWaveIfAvailable()
    {
        if (countDown <= 0.0f)
        {
            GenerateRandomTimeBetweenWaves();
            CheckAvailableRoad();

            if (canSpawn)
            {
                //SpawnEnemyWave();
                StartCoroutine(SpawnEnemyWave());
            }
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
    }

    private void SpawnSurgeIfAvailable()
    {
        if (surgeCountDown <= 0.0f)
        {
            CheckAvailableRoad();

            if (canSpawn)
            {
                //SpawnEnemyWave();
                StartCoroutine(SpawnEnemySurgeWave());
            }
            surgeCountDown = (timeBetweenWaves / 2);
        }
        surgeCountDown -= Time.deltaTime;
    }

    private void GenerateRandomTimeBetweenWaves()
    {
        timeBetweenWaves = Random.Range(timeBetweenWavesMin, timeBetweenWavesMax);
        countDown = timeBetweenWaves;

        Debug.Log("Time Between Waves: " + timeBetweenWaves);

    }

    private void IncreaseTimeBetweenWaveMinAndMax()
    {
        timeBetweenWavesMin += 5;
        timeBetweenWavesMax += 5;
    }

    private void IncreaseSurgeSpawn()
    {
        surgeBoost += 3;
    }
 
    public void ActivateSurgeSpawning()
    {
        surgeActive = true;
    }

    public void DeactivateSurgeSpawning()
    {
        surgeActive = false;
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

       // Debug.Log("Check Available Roads");

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
