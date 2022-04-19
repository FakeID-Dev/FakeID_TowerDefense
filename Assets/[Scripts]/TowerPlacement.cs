//############################################################################################################
// TowerPlacement.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<Material> met;
    public List<Color> originalMet;
    public Collider box;

    public bool canBePlaced = false;
    public bool holding = true;

    public bool tileBool = false;
    public bool roadBool = false;

    public List<GameObject> objects;
    //Game Manager 
    public GameObject gameManger; //Sam added

    //public MeshCollider mesh;




    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 3; x++)
        {
            originalMet[x] = GetComponent<Renderer>().materials[x].color;
            met[x] = GetComponent<Renderer>().materials[x];
        }

        gameManger = GameObject.Find("GameManager");//Sam add

    }

    // Update is called once per frame
    void Update()
    {
        if (tileBool && roadBool)
        {
            canBePlaced = false;
        }
        else if (tileBool)
        {
            canBePlaced = true;
        }

        if (tileBool == false)
        {
            canBePlaced = false;
        }

        if (holding)
        {
            
            if (canBePlaced)
            {
                met[0].color = Color.green;
                met[1].color = Color.green;
                met[2].color = Color.green;
            }
            else
            {
                met[0].color = Color.red;
                met[1].color = Color.red;
                met[2].color = Color.red;
            }
        }
        else
        {
           
            for (int x = 0; x < 3; x++)
            {
                met[x].color = originalMet[x];
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        objects.Add(collision.gameObject);

        for (int x = 0; x < objects.Count; x++)
        {
            if (objects[x].gameObject.tag == "Road" || objects[x].gameObject.tag == "Enemy")
            {
                roadBool = true;
            }
        }


    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Road" || other.gameObject.tag == "Enemy")
        {
            objects.Remove(other.gameObject);
        }

        if (other.gameObject.tag == "Tile")
        {
            objects.Remove(other.gameObject);
        }

        tileBool = true;
        roadBool = false;

        for (int x = 0; x < objects.Count; x++)
        {
            if (objects[x].gameObject.tag == "Road" || objects[x].gameObject.tag == "Enemy")
            {
                roadBool = true;
            }
        }

    }


    public void PlacedTower()
    {
        holding = false;
        gameManger.GetComponent<ToggleMapCamera>().ToggleActiveCameraMove();
        gameManger.GetComponent<Inventory>().isOpen = false;
        gameManger.GetComponent<Initialize>().toggleTiles();

    }

    public void LoadPlacedTower()
    {
        Start();
        holding = false;
        for (int x = 0; x < 3; x++)
        {
            met[x].color = originalMet[x];
        }
    }
}
