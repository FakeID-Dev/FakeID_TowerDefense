using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileOptions : MonoBehaviour
{
    public int posX;
    public int posY;
    public bool up = false, down = false, left = false, right = false;

    public bool canBuild = false;
    public bool isSelected = false;
    public bool UIcover = false;

    public GameObject gameManager;

    public GameObject roadDown;
    public GameObject roadStr;
    public GameObject roadLeft;
    public GameObject roadRight;
    public GameObject roadDowLeft;
    public GameObject roadDowRight;
    public GameObject roadSplitUp;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {

    }


    public void AddToMapArray()
    {
        isSelected = false;
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
            }
        }
    }

    public void RoadType()
    {
        if (up || down)
        {
            if (left == false && right == false)
            {
                Instantiate(roadDown, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadDown.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 4;
            }

            if (left && right && up)
            {
                Instantiate(roadSplitUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadSplitUp.transform.rotation);
            }
            else if (left && up)
            {
                Instantiate(roadLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadLeft.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 2;
            }
            else if (right && up)
            {
                Instantiate(roadRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadRight.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 3;
            }
        }

        if (left || right)
        {
            if (up == false && down == false)
            {
                Instantiate(roadStr, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadStr.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
            }

            if (right && down)
            {
                Instantiate(roadDowLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadDowLeft.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 5;
            }

            if (left && down)
            {
                Instantiate(roadDowRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadDowRight.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 6;
            }
        }
       
    }
}
