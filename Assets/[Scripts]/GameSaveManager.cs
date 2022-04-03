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

    public int numTiles;
    public int[,] Map;

    public int gold;
    public int stone;
    public int exp;
    public int surge;

    public float[,] towerData;
    
    public SaveData()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        Map = new int[50, 50];
        towerData = new float[towers.Length, 3];
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
        data.stone = gameManager.GetComponent<Inventory>().stoneInt;
        data.exp = gameManager.GetComponent<Inventory>().expInt;
        data.surge = gameManager.GetComponent<SurgeController>().surgeTimerInt;

        //Save Map
        data.Map = gameManager.GetComponent<Initialize>().Map;

        //Save Towers
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");

        foreach (var tower in towers)
        {
            if (tower.name == "Tower-Arrow(Clone)")
            {

            }
            else if (tower.name == "Tower-Ice(Clone)")
            {

            }
            else if (tower.name == "Tower-Cannon(Clone)")
            {

            }
            else
            {
                
            }
        }

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved! - Binary File");
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
            gameManager.GetComponent<Inventory>().stoneInt = data.stone;
            gameManager.GetComponent<Inventory>().expInt = data.exp;
            gameManager.GetComponent<SurgeController>().surgeTimerInt = data.surge;

            //Load Map
            gameManager.GetComponent<Initialize>().Map = data.Map;
            gameManager.GetComponent<Initialize>().ReloadMap();
            //Load Towers

            Debug.Log("Game data loaded! - Binary File");
        }
        else
            Debug.LogError("There is no save data!");
    }

    private void ResetData()
    {
        //PlayerPrefs.DeleteAll();
        //Debug.Log("Data reset complete - PlayerPrefs");

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
