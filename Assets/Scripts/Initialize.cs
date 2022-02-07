//############################################################################################################
// Initialize.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{

    public GameObject tile;
    public GameObject roadDown;
    public GameObject roadStr;
    public GameObject roadLeft;
    public GameObject roadRight;
    public GameObject roadDowLeft;
    public GameObject roadDowRight;

    public List<GameObject> tileList;

    public int[,] Map = new int[10, 10]{ // 0 = tile, 1 = down, 2 = left, 3 = right, 4 = str;
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
        {0, 0, 0, 0, 3, 1, 1, 5, 0, 0}, 
        {0, 0, 0, 0, 4 ,0, 0, 2, 1, 1}, 
        {0, 0, 0, 0, 4, 0, 0, 0, 0, 0}, 
        {0, 0, 0, 0, 4, 0, 0, 0, 0, 0},
        {1, 1, 1, 1, 6, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 2, 3, 4, 5, 6, 0, 0, 0, 0}};




    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 10; x++)
        {
            
            for (int y = 0; y < 10; y++)
            {
                if(Map[x,y] == 0)
                {
                    tileList.Add(Instantiate(tile, new Vector3(x, 0, y), tile.transform.rotation));
                }
                else if (Map[x, y] == 1)
                {
                    tileList.Add(Instantiate(roadDown, new Vector3(x, 0, y), roadDown.transform.rotation));
                }
                else if (Map[x, y] == 2)
                {
                    tileList.Add(Instantiate(roadLeft, new Vector3(x, 0, y), roadLeft.transform.rotation));
                }
                else if (Map[x, y] == 3)
                {
                    tileList.Add(Instantiate(roadRight, new Vector3(x, 0, y), roadRight.transform.rotation));
                }
                else if (Map[x, y] == 4)
                {
                    tileList.Add(Instantiate(roadStr, new Vector3(x, 0, y), roadStr.transform.rotation));
                }
                else if (Map[x, y] == 5)
                {
                    tileList.Add(Instantiate(roadDowLeft, new Vector3(x, 0, y), roadDowLeft.transform.rotation));
                }
                else if (Map[x, y] == 6)
                {
                    tileList.Add(Instantiate(roadDowRight, new Vector3(x, 0, y), roadDowRight.transform.rotation));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
