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
    public float[,] savedTiles;

    public int gold;
    public int stone;
    public int exp;
    public int surge;
    
    public SaveData(int tiles)
    {
        savedTiles = new float[tiles + 1, 3];
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
        SaveData data = new SaveData(gameManager.GetComponent<Initialize>().tileList.Count);

        data.gold = gameManager.GetComponent<Inventory>().coinInt;
        data.stone = gameManager.GetComponent<Inventory>().stoneInt;
        data.exp = gameManager.GetComponent<Inventory>().expInt;
        data.surge = gameManager.GetComponent<SurgeController>().surgeTimerInt;

        //for (int i = 0; i < gameManager.GetComponent<Initialize>().tileList.Count; i++)
        //{
        //    string tileName = gameManager.GetComponent<Initialize>().tileList[i].name;
        //    if (tileName == "tile_Downstraight(Clone)")
        //    {
        //        data.savedTiles[i, 1] = 1;
        //        data.savedTiles[i, 2] = gameManager.GetComponent<Initialize>().tileList[i].GetComponent<RoadCord>().PosX;
        //        data.savedTiles[i, 3] = gameManager.GetComponent<Initialize>().tileList[i].GetComponent<RoadCord>().PosY;
        //    }
        //    else if (tileName == "tile_straight(Clone)")
        //    {
        //        data.savedTiles[i, 1] = 2;
        //        data.savedTiles[i, 2] = gameManager.GetComponent<Initialize>().tileList[i].GetComponent<RoadCord>().PosX;
        //        data.savedTiles[i, 3] = gameManager.GetComponent<Initialize>().tileList[i].GetComponent<RoadCord>().PosY;
        //    }
        //    else if (tileName == "ZombieSpawner(Clone)")
        //    {
        //        data.savedTiles[i, 1] = 3;
        //        data.savedTiles[i, 2] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.x;
        //        data.savedTiles[i, 3] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.z;
        //    }
        //    else if (tileName == "CyborgSpawner(Clone)")
        //    {
        //        data.savedTiles[i, 1] = 4;
        //        data.savedTiles[i, 2] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.x;
        //        data.savedTiles[i, 3] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.z;
        //    }
        //    else if (tileName == "GhostSpawner(Clone)")
        //    {
        //        data.savedTiles[i, 1] = 5;
        //        data.savedTiles[i, 2] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.x;
        //        data.savedTiles[i, 3] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.z;
        //    }
        //    else if (tileName == "Cystal(Clone)")
        //    {
        //        data.savedTiles[i, 1] = 6;
        //        data.savedTiles[i, 2] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.x;
        //        data.savedTiles[i, 3] = gameManager.GetComponent<Initialize>().tileList[i].transform.position.z;
        //    }
        //    else
        //    {
        //        data.savedTiles[i, 1] = 0;
        //        data.savedTiles[i, 2] = 0;
        //        data.savedTiles[i, 3] = 0;
        //    }

        //}

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
            //var x = data.playerPosition[0];
            //var y = data.playerPosition[1];
            //var z = data.playerPosition[2];

            //var Rotx = data.playerRotation[0];
            //var Roty = data.playerRotation[1];
            //var Rotz = data.playerRotation[2];

            //player.gameObject.GetComponent<CharacterController>().enabled = false;
            //player.position = new Vector3(x, y, z);
            //player.rotation = Quaternion.Euler(Rotx, Roty, Rotz);
            //player.gameObject.GetComponent<CharacterController>().enabled = true;

            //for(int i = 0; i < 5; i++)
            //{

            //}


            gameManager.GetComponent<Inventory>().coinInt = data.gold;
            gameManager.GetComponent<Inventory>().stoneInt = data.stone;
            gameManager.GetComponent<Inventory>().expInt = data.exp;
            gameManager.GetComponent<SurgeController>().surgeTimerInt = data.surge;


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
