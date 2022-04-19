//############################################################################################################
// Initialize.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Initialize : MonoBehaviour
{
    //NavMesh
    public NavMeshSurface navMeshSurface;

    public int count;
    public GameObject map;
    public GameObject mapRoad;
    public GameObject tile;
    public GameObject roadDown;
    public GameObject roadStr;
    public GameObject roadLeft;
    public GameObject roadRight;
    public GameObject roadDowLeft;
    public GameObject roadDowRight;
    public GameObject monsterSpawner;
    public GameObject crystalSpawner;
    public GameObject otherSpawner;

    public List<GameObject> tileList;
    public GameObject[,] Tiles2D = new GameObject[50, 50];
    public List<GameObject> roadList;
    public List<GameObject> NewRoadsList;

    private int mapSize = 50;

    public int[,] Map = new int[50, 50]{ // 0 = tile, 1 = down, 2 = left, 3 = right, 4 = str;
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3, 4, 4, 4, 4, 4, 4, 4, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 4, 4, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 4, 4, 4, 4, 4, 4, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};

    void Start()
    {
        map = GameObject.Find("Map");
        mapRoad = GameObject.Find("MapRoad");

        BuildMap();
    }

    public void ReloadMap()
    {
        ClearMap();
        BuildMap();
    }

    private void BuildMap()
    {
        for (int x = 0; x < mapSize; x++)
        {

            for (int y = 0; y < mapSize; y++)
            {

                if (Map[x, y] == 0)
                {
                    GameObject temp = Instantiate(tile, new Vector3(x, 0, y), tile.transform.rotation);
                    temp.GetComponentInChildren<TileOptions>().posX = x;
                    temp.GetComponentInChildren<TileOptions>().posY = y;
                    Tiles2D[x, y] = temp;
                    tileList.Add(temp);

                }
                else if (Map[x, y] == 4)
                {
                    GameObject temp = Instantiate(roadDown, new Vector3(x, 0, y), roadDown.transform.rotation);
                    temp.GetComponentInChildren<RoadCord>().PosX = x;
                    temp.GetComponentInChildren<RoadCord>().PosY = y;
                    temp.GetComponent<TileOptions>().posX = x;
                    temp.GetComponent<TileOptions>().posY = y;
                    Tiles2D[x, y] = temp;
                    tileList.Add(temp);
                    count++;
                }
                else if (Map[x, y] == 2)
                {
                    GameObject temp = Instantiate(roadLeft, new Vector3(x, 0, y), roadLeft.transform.rotation);
                    temp.GetComponentInChildren<RoadCord>().PosX = x;
                    temp.GetComponentInChildren<RoadCord>().PosY = y;
                    temp.GetComponent<TileOptions>().posX = x;
                    temp.GetComponent<TileOptions>().posY = y;
                    tileList.Add(temp);
                    count++;
                }
                else if (Map[x, y] == 3)
                {
                    GameObject temp = Instantiate(roadRight, new Vector3(x, 0, y), roadRight.transform.rotation);
                    temp.GetComponentInChildren<RoadCord>().PosX = x;
                    temp.GetComponentInChildren<RoadCord>().PosY = y;
                    temp.GetComponent<TileOptions>().posX = x;
                    temp.GetComponent<TileOptions>().posY = y;
                    tileList.Add(temp);
                    count++;

                }
                else if (Map[x, y] == 1)
                {
                    GameObject temp = Instantiate(roadStr, new Vector3(x, 0, y), roadStr.transform.rotation);
                    temp.GetComponentInChildren<RoadCord>().PosX = x;
                    temp.GetComponentInChildren<RoadCord>().PosY = y;
                    temp.GetComponent<TileOptions>().posX = x;
                    temp.GetComponent<TileOptions>().posY = y;
                    Tiles2D[x, y] = temp;
                    tileList.Add(temp);
                    count++;

                }
                else if (Map[x, y] == 5)
                {
                    GameObject temp = Instantiate(roadDowLeft, new Vector3(x, 0, y), roadDowLeft.transform.rotation);
                    temp.GetComponentInChildren<RoadCord>().PosX = x;
                    temp.GetComponentInChildren<RoadCord>().PosY = y;
                    temp.GetComponent<TileOptions>().posX = x;
                    temp.GetComponent<TileOptions>().posY = y;
                    tileList.Add(temp);
                    count++;

                }
                else if (Map[x, y] == 6)
                {
                    GameObject temp = Instantiate(roadDowRight, new Vector3(x, 0, y), roadDowRight.transform.rotation);
                    temp.GetComponentInChildren<RoadCord>().PosX = x;
                    temp.GetComponentInChildren<RoadCord>().PosY = y;
                    temp.GetComponent<TileOptions>().posX = x;
                    temp.GetComponent<TileOptions>().posY = y;
                    tileList.Add(temp);
                    count++;
                }
                else if (Map[x, y] == 7)
                {
                    GameObject temp = Instantiate(monsterSpawner, new Vector3(x, 0, y), monsterSpawner.transform.rotation);
                    temp.GetComponentInChildren<EnemySpawner>().posX = x;
                    temp.GetComponentInChildren<EnemySpawner>().posY = y;
                    tileList.Add(temp);
                    count++;
                    Tiles2D[x, y] = temp;
                }
                else if (Map[x, y] == 8)
                {
                    GameObject temp = Instantiate(crystalSpawner, new Vector3(x, 0, y), crystalSpawner.transform.rotation);
                    tileList.Add(temp);
                    count++;
                    Tiles2D[x, y] = temp;
                }
                else if (Map[x, y] == 9)
                {
                    GameObject temp = Instantiate(otherSpawner, new Vector3(x, 0, y), crystalSpawner.transform.rotation);
                    temp.GetComponentInChildren<EnemySpawner>().posX = x;
                    temp.GetComponentInChildren<EnemySpawner>().posY = y;
                    tileList.Add(temp);
                    count++;
                    Tiles2D[x, y] = temp;
                }
            }
        }
        CheckRoad();
    }

    private void ClearMap()
    {
        foreach (var tile in tileList)
        {
            Destroy(tile);
        }
        tileList.Clear();
    }


    public void CheckRoad()
    {
        //Debug.Log("Check Road");
        int count = 0;
        for (int x = 0; x < tileList.Count; x++)
        {
            count++;

            if (tileList[x].gameObject.tag == "tile")
            {
                tileList[x].transform.parent = map.gameObject.transform;
            }
            if (tileList[x].gameObject.tag == "Road")
            {
                roadList.Add(tileList[x]);
            }

        }

        navMeshSurface.BuildNavMesh();
    }

    public void UpdateRoad(int PosX, int PosY)
    {
        roadList[roadList.Count - 1].gameObject.GetComponentInChildren<RoadCord>().PosX = PosX;
        roadList[roadList.Count - 1].gameObject.GetComponentInChildren<RoadCord>().PosY = PosY;
        Tiles2D[PosX, PosY] = roadList[roadList.Count - 1];
        bool nextTo = false;

        if (Map[PosX, PosY - 1] == 1)
        {
            AddToNewRoad(PosX, PosY - 1);
            nextTo = true;
        }

        else if (Map[PosX + 1, PosY] == 1)
        {
            AddToNewRoad(PosX + 1, PosY);
            nextTo = true;
        }

        else if (Map[PosX, PosY + 1] == 1)
        {
            AddToNewRoad(PosX, PosY + 1);
            nextTo = true;
        }

        else if (Map[PosX - 1, PosY] == 1)
        {
            AddToNewRoad(PosX - 1, PosY);
            nextTo = true;
        }

        else if (Map[PosX, PosY - 1] == 4)
        {
            AddToNewRoad(PosX, PosY - 1);
            nextTo = true;
        }

        else if (Map[PosX + 1, PosY] == 4)
        {
            AddToNewRoad(PosX + 1, PosY);
            nextTo = true;
        }

        else if (Map[PosX, PosY + 1] == 4)
        {
            AddToNewRoad(PosX, PosY + 1);
            nextTo = true;
        }

        else if (Map[PosX - 1, PosY] == 4)
        {
            AddToNewRoad(PosX - 1, PosY);
            nextTo = true;
        }

        //else if (nextTo == false)
        //{
        //    Debug.Log("New Road");
        //    GameObject go = new GameObject("Road");
        //    go.transform.position = new Vector3(roadList[roadList.Count - 1].gameObject.transform.position.x, roadList[roadList.Count - 1].gameObject.transform.position.y, roadList[roadList.Count - 1].gameObject.transform.position.z);
        //    roadList[roadList.Count - 1].gameObject.transform.parent = go.gameObject.transform;
        //    NewRoadsList.Add(go);
        //}

        //roadList[roadList.Count - 1].gameObject.transform.parent = mapRoad.gameObject.transform;

        //Rebuild NavMesh
    }

    public void AddToNewRoad(int psX, int psY)
    {
        //for (int x = 0; x < NewRoadsList.Count; x++)
        //{
        //    foreach (Transform g in NewRoadsList[x].GetComponentsInChildren<Transform>())
        //    {
        //        Debug.Log(g.name);

        //        if (g.gameObject.GetComponentInChildren<RoadCord>().PosX == psX && g.gameObject.GetComponentInChildren<RoadCord>().PosY == psY)
        //        {
        //            Debug.Log("MATCH");

        //            roadList[roadList.Count - 1].gameObject.transform.parent = NewRoadsList[x].gameObject.transform;
        //        }
        //    }
        //}
    }

    public void HardCodeMainRoad()
    {
        roadList[0].transform.parent = mapRoad.gameObject.transform;
        roadList[1].transform.parent = mapRoad.gameObject.transform;
        roadList[2].transform.parent = mapRoad.gameObject.transform;
        roadList[3].transform.parent = mapRoad.gameObject.transform;
        roadList[4].transform.parent = mapRoad.gameObject.transform;
        roadList[5].transform.parent = mapRoad.gameObject.transform;
        roadList[6].transform.parent = mapRoad.gameObject.transform;
        roadList[7].transform.parent = mapRoad.gameObject.transform;
        roadList[8].transform.parent = mapRoad.gameObject.transform;
        roadList[9].transform.parent = mapRoad.gameObject.transform;
        roadList[11].transform.parent = mapRoad.gameObject.transform;
        roadList[13].transform.parent = mapRoad.gameObject.transform;
        roadList[15].transform.parent = mapRoad.gameObject.transform;
        roadList[17].transform.parent = mapRoad.gameObject.transform;
        roadList[19].transform.parent = mapRoad.gameObject.transform;
        roadList[21].transform.parent = mapRoad.gameObject.transform;
        roadList[23].transform.parent = mapRoad.gameObject.transform;
        roadList[33].transform.parent = mapRoad.gameObject.transform;
        roadList[32].transform.parent = mapRoad.gameObject.transform;
        roadList[31].transform.parent = mapRoad.gameObject.transform;
        roadList[30].transform.parent = mapRoad.gameObject.transform;
        roadList[29].transform.parent = mapRoad.gameObject.transform;
        roadList[28].transform.parent = mapRoad.gameObject.transform;
        roadList[28].transform.parent = mapRoad.gameObject.transform;
        roadList[27].transform.parent = mapRoad.gameObject.transform;
        roadList[26].transform.parent = mapRoad.gameObject.transform;
        roadList[25].transform.parent = mapRoad.gameObject.transform;
        roadList[24].transform.parent = mapRoad.gameObject.transform;
        roadList[23].transform.parent = mapRoad.gameObject.transform;
        roadList[22].transform.parent = mapRoad.gameObject.transform;
        roadList[20].transform.parent = mapRoad.gameObject.transform;
        roadList[18].transform.parent = mapRoad.gameObject.transform;
        roadList[16].transform.parent = mapRoad.gameObject.transform;
        roadList[14].transform.parent = mapRoad.gameObject.transform;
        roadList[12].transform.parent = mapRoad.gameObject.transform;
        roadList[10].transform.parent = mapRoad.gameObject.transform;


       
      
    }


    public void AddResourceNode()
    {
        int x, y;

        x = Random.Range(0, mapSize);
        y = Random.Range(0, mapSize);

        while (Map[x, y] != 0)
        {
            x = Random.Range(0, mapSize);
            y = Random.Range(0, mapSize);
        }

        Map[x, y] = 8;

        GameObject temp = Instantiate(crystalSpawner, new Vector3(x, 0, y), crystalSpawner.transform.rotation);
        tileList.Add(temp);

    }

    public void AddResourceNode(int x, int y) //Override for saving/loading
    {

        Map[x, y] = 8;

        GameObject temp = Instantiate(crystalSpawner, new Vector3(x, 0, y), crystalSpawner.transform.rotation);
        tileList.Add(temp);

    }


    public void AddMonsterNode()
    {
        int x, y;

        x = Random.Range(0, mapSize);
        y = Random.Range(0, mapSize);

        while (Map[x, y] != 0)
        {
            x = Random.Range(0, mapSize);
            y = Random.Range(0, mapSize);
        }

        Map[x, y] = 7;

        GameObject temp = Instantiate(monsterSpawner, new Vector3(x, 0, y), monsterSpawner.transform.rotation);
        temp.GetComponentInChildren<EnemySpawner>().posX = x;
        temp.GetComponentInChildren<EnemySpawner>().posY = y;
        Tiles2D[x, y] = temp;

        tileList.Add(temp);
    }

    public void AddMonsterNode(int x, int y) //Override for saving/loading
    {

        Map[x, y] = 7;

        GameObject temp = Instantiate(monsterSpawner, new Vector3(x, 0, y), monsterSpawner.transform.rotation);
        temp.GetComponentInChildren<EnemySpawner>().posX = x;
        temp.GetComponentInChildren<EnemySpawner>().posY = y;
        Tiles2D[x, y] = temp;

        tileList.Add(temp);
    }



    public void toggleTiles()
    {
        //for (int x = 0; x < tileList.Count; x++)
        //{
        //    if (tileList[x].tag == "tile")
        //    {
        //        bool temp = tileList[x].GetComponentInChildren<TileOptions>().canBuild;
        //        tileList[x].GetComponentInChildren<TileOptions>().canBuild = !temp;
        //    }
        //}
    }


    public void RemoveTile(GameObject compare)
    {
        for (int x = 0; x < tileList.Count; x++)
        {
            if (tileList[x].gameObject == compare)
            {
                tileList.RemoveAt(x);
            }

        }
    }

}