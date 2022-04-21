using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileOptions : MonoBehaviour
{
    public int posX;
    public int posY;
    public bool up = false, down = false, left = false, right = false;
    public bool corner = false;

    public bool canBuild = false;
    public bool isSelected = false;
    public bool UIcover = false;

    public Material matFoliage;
    public Material matDirt;

    public GameObject gameManager;

    public GameObject roadDown;
    public GameObject roadStr;
    public GameObject roadLeft;
    public GameObject roadRight;
    public GameObject roadDowLeft;
    public GameObject roadDowRight;
    public GameObject roadCrossing;
    public GameObject roadSplitRight;
    public GameObject roadSplitLeft;
    public GameObject roadSplitDown;
    public GameObject roadSplitUp;

    private GameObject temp; 



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

       
        if (corner)
        {
            gameObject.GetComponentInChildren<Renderer>().materials[2].color = matFoliage.color;
            gameObject.GetComponentInChildren<Renderer>().materials[1].color = matDirt.color;
        }
        else
        {
            gameObject.GetComponentInChildren<Renderer>().materials[1].color = matFoliage.color;
        }
               
        
      
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

        gameManager = GameObject.Find("GameManager");

        if (up || down)
        {
            if (left && right && up && down)
            {
                temp = Instantiate(roadCrossing, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadCrossing.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (left == false && right == false)
            {
                temp = Instantiate(roadDown, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadDown.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (right && left && up)
            {
                temp = Instantiate(roadSplitUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadSplitUp.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (right && left && down)
            {
                temp = Instantiate(roadSplitDown, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadSplitDown.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (right && up && down)
            {
                temp = Instantiate(roadSplitRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadSplitRight.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (left && up && down)
            {
                temp = Instantiate(roadSplitLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadSplitLeft.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (left && up)
            {
                temp = Instantiate(roadLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadLeft.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (right && up)
            {
                temp = Instantiate(roadRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadRight.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (right && down)
            {
                temp = Instantiate(roadDowLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadDowLeft.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }
            else if (left && down)
            {
                temp = Instantiate(roadDowRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadDowRight.transform.rotation);
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
                gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
                gameManager.GetComponent<Initialize>().tileList.Add(temp);
                temp.GetComponent<TileOptions>().up = up;
                temp.GetComponent<TileOptions>().down = down;
                temp.GetComponent<TileOptions>().left = left;
                temp.GetComponent<TileOptions>().right = right;
            }


        }
        else if (up == false && down == false)
        {
            temp = Instantiate(roadStr, new Vector3(transform.position.x, transform.position.y, transform.position.z), roadStr.transform.rotation);
            gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
            gameManager.GetComponent<Initialize>().Tiles2D[posX, posY] = temp;
            gameManager.GetComponent<Initialize>().tileList.Add(temp);
            temp.GetComponent<TileOptions>().up = up;
            temp.GetComponent<TileOptions>().down = down;
            temp.GetComponent<TileOptions>().left = left;
            temp.GetComponent<TileOptions>().right = right;
        }


        temp.GetComponentInChildren<RoadCord>().PosX = posX;
        temp.GetComponentInChildren<RoadCord>().PosY = posY;
        temp.GetComponentInChildren<TileOptions>().posX = posX;
        temp.GetComponentInChildren<TileOptions>().posY = posY;
        

    }

}
