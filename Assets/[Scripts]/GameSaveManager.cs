using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
class SaveData
{
    public int[,] Map;
    public int gold;
    //public int stone;
    public int exp;
    public int surge;
    public float[,] towerData;
    
    public SaveData()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        Map = new int[50, 50];
        towerData = new float[towers.GetLength(0), 3];

        //Debug.Log("Length : " + towers.GetLength(0));
    }
}

//Serialize the player data
public class GameSaveManager : MonoBehaviour
{
    //public Transform player;

    public GameObject gameManager;
    private void SaveGame()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/TDSaveData.dat");
        SaveData data = new SaveData();

        //Save Game Stats
        data.gold = gameManager.GetComponent<Inventory>().coinInt;
        //data.stone = gameManager.GetComponent<Inventory>().stoneInt;
        data.exp = gameManager.GetComponent<Inventory>().expInt;
        data.surge = gameManager.GetComponent<SurgeController>().surgeTimerInt;

        //Save Map
        data.Map = gameManager.GetComponent<Initialize>().Map;

        //Save Towers
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        int towerCount = towers.Length;

        for (int i = 0; i < towerCount; i++)
        {
            //Debug.Log("Saving Tower Data: X: " + towers[i].transform.position.x + " Z: " + towers[i].transform.position.z);
            data.towerData[i, 0] = towers[i].transform.position.x;
            data.towerData[i, 1] = towers[i].transform.position.z;
            if (towers[i].name == "Tower-Arrow(Clone)")
            {
                data.towerData[i, 2] = 0.0f;
            }
            else if (towers[i].name == "Tower-Ice(Clone)")
            {
                data.towerData[i, 2] = 1.0f;
            }
            else if (towers[i].name == "Tower-Cannon(Clone)")
            {
                data.towerData[i, 2] = 2.0f;
            }
            else if (towers[i].name == "Tower-Drill(Clone)")
            {
                data.towerData[i, 2] = 3.0f;
            }
            else
            {
                data.towerData[i, 2] = 3.0f;
            }
        }

        bf.Serialize(file, data);
        file.Close();
        //Debug.Log("Game data saved! - Binary File");
    }

    //Deserialize the player data
    private void LoadGame()
    {

        if (File.Exists(Application.persistentDataPath + "/TDSaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/TDSaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            
            //Load Game Stats
            gameManager.GetComponent<Inventory>().coinInt = data.gold;
            //gameManager.GetComponent<Inventory>().stoneInt = data.stone;
            gameManager.GetComponent<Inventory>().expInt = data.exp;
            gameManager.GetComponent<SurgeController>().surgeTimerInt = data.surge;

            //Load Map //UNCOMMENT FOR MAP LOAD - Can't test due to road building not working
            gameManager.GetComponent<Initialize>().Map = data.Map;
            gameManager.GetComponent<Initialize>().ReloadMap();

            //Load Towers
            int towerDataSize = data.towerData.GetLength(0);

            gameManager.GetComponent<Inventory>().ClearTowers();

            for (int i = 0; i < towerDataSize; i++)
            {
                //Debug.Log("Placing tower at X: " + data.towerData[i, 0] + ", Z: " + data.towerData[i, 0]);
                gameManager.GetComponent<Inventory>().loadPlaceTower(data.towerData[i, 0], data.towerData[i, 1], (int)data.towerData[i, 2]);
            }

            Debug.Log("Game data loaded! - Binary File");
        }
        else
            Debug.LogError("There is no save data!");
    }

    private void ResetData()
    {

        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath + "/MySaveData.dat");
            Debug.Log("Data reset complete! - Binary File");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    public void OnSaveButtonPress()
    {
        SaveGame();
    }

    public void OnLoadButtonPress()
    {
        LoadGame();
    }

    public void OnResetButtonPress()
    {
        ResetData();
    }
}
