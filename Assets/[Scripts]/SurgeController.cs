using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurgeController : MonoBehaviour
{
    public Slider surgeSlider;

    public int surgeTimerInt;

    public float surgeDuration;
    private float tempDuration;

    public float surgeWait;
    private float tempWait;

    private int surgeNum;

    private bool surgeActive;

    public EnemySpawner[] enemySpawners;

    public int availableUnits; //Temp
    public int availableUnitIncrementAmount;

    //Should make surgeController a singleton
    public static SurgeController surgeControllerInstance;

    //Singleton Setup
    private void Awake()
    {
        if (surgeControllerInstance != null)
        {
            return;
        }
        surgeControllerInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        surgeActive = false;

        tempWait = 0;
        tempDuration = surgeDuration;

        enemySpawners = FindObjectsOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (surgeActive)
        {
            CountDownSurge();
        }
        else
        {
            CountUpToSurge();
        }
    }

    private void CountUpToSurge()
    {
        surgeSlider.maxValue = surgeWait;

        if (tempWait < surgeWait)
        {
            tempWait += Time.deltaTime;

            surgeSlider.value = tempWait;
        }
        else
        {
            SurgeStarted();
            surgeActive = true;
            tempWait = 0;
        }
    }

    private void CountDownSurge()
    {
        surgeSlider.maxValue = surgeDuration;


        if (tempDuration > 0)
        {
            tempDuration -= Time.deltaTime;

            surgeSlider.value = tempDuration;
        }
        else
        {
            SurgeComplete();
            surgeActive = false;
            tempDuration = surgeDuration;
        }
    }


    private void SurgeStarted()
    {
        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.ActivateSurgeSpawning();
        }
    }


    private void SurgeComplete()
    {
        surgeNum += 1;

        //Increase Surge Wait
        //Increase Surge Duration 
        //Increase Available Units
        IncreaseAvailableEnemyUnits(availableUnitIncrementAmount);

        enemySpawners = FindObjectsOfType<EnemySpawner>();

        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.DeactivateSurgeSpawning();
        }
    }

    public int GetSurgeLevel()
    {
        return surgeNum; 
    }

    public void SetSurgeLevel(int level)
    {
        surgeNum = level;
    }

    public int GetAvailableUnits()
    {
        return availableUnits;
    }

    public void IncreaseAvailableEnemyUnits(int incrementAmount)
    {
        availableUnits += incrementAmount;
    }

    public void DecreaseAvailableEnemyUnits(int decrementAmount)
    {
        availableUnits -= decrementAmount;
    }
}
